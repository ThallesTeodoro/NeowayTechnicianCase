using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using NeowayTechnicianCase.Core.Entities;
using NeowayTechnicianCase.Core.Interfaces.Repositories;
using NeowayTechnicianCase.Core.Interfaces.Services;
using NeowayTechnicianCase.Core.Interfaces.Validations;
using NeowayTechnicianCase.Infrastructure.Validations;

namespace NeowayTechnicianCase.Infrastructure.Services
{
    public class FilePersisting : IFilePersisting
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IPurchaseRepository _purchaseRepository;
        protected readonly IStoreRepository _storeRepository;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="purchaseRepository"></param>
        /// <param name="storeRepository"></param>
        public FilePersisting(
            IUnitOfWork uow,
            IPurchaseRepository purchaseRepository,
            IStoreRepository storeRepository)
        {
            _uow = uow;
            _purchaseRepository = purchaseRepository;
            _storeRepository = storeRepository;
        }

        /// <summary>
        /// Persist the data in database
        /// </summary>
        /// <param name="data"></param>
        public async Task Persist(List<string[]> data)
        {
            List<Purchase> purchases = new List<Purchase>();
            List<Store> stores = new List<Store>();
            IValidator<IRule<string>, string> validator = new Validator<IRule<string>, string>();

            try
            {
                int i = 0;

                foreach (string[] item in data)
                {
                    Purchase purchase = NewPurchase(item);
                    purchase.CPFIsValid = validator.Validate(new CpfRule(), purchase.CPF);
                    purchase.CPF = DataSanitation(purchase.CPF);

                    if (item[6].ToUpper() != "NULL")
                    {
                        string usualStoreCnpj = DataSanitation(item[6]);

                        Store usualStore = stores
                            .Where(s => s.CNPJ == usualStoreCnpj)
                            .FirstOrDefault();

                        if (usualStore == null)
                        {
                            usualStore = new Store
                            {
                                Id = Guid.NewGuid(),
                                CNPJ = usualStoreCnpj,
                            };
                            usualStore.CNPJIsValid = validator.Validate(new CnpjRule(), usualStore.CNPJ);
                            stores.Add(usualStore);
                            await _storeRepository.AddAsync(usualStore);
                        }

                        purchase.UsualStoreId = usualStore.Id;
                    }

                    if (item[7].ToUpper() != "NULL")
                    {
                        string lastStoreCnpj = DataSanitation(item[7]);

                        Store lastStore = stores
                            .Where(s => s.CNPJ == lastStoreCnpj)
                            .FirstOrDefault();

                        if (lastStore == null)
                        {
                            lastStore = new Store
                            {
                                Id = Guid.NewGuid(),
                                CNPJ = lastStoreCnpj,
                            };
                            lastStore.CNPJIsValid = validator.Validate(new CnpjRule(), lastStore.CNPJ);
                            stores.Add(lastStore);
                            await _storeRepository.AddAsync(lastStore);
                        }

                        purchase.LastStoreId = lastStore.Id;
                    }

                    purchases.Add(purchase);

                    i++;
                }

                await _purchaseRepository.AddManyAsync(purchases);
                _uow.Commit();
            }
            catch (Exception)
            {
                _uow.Rollback();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Purchase NewPurchase(string[] data)
        {
            Purchase purchase = new Purchase();
            purchase.Id = Guid.NewGuid();
            purchase.CPF = data[0];
            purchase.Private = Convert.ToBoolean(int.Parse(data[1].ToString()));
            purchase.Unfinished = Convert.ToBoolean(int.Parse(data[2].ToString()));
            purchase.LastPurchase = data[3].ToUpper() != "NULL" ? DateTime.ParseExact(data[3], "yyyy-MM-dd", CultureInfo.InvariantCulture) : null;
            purchase.MediumTicket = data[4].ToUpper() != "NULL" ? Convert.ToDouble(data[4]) : null;
            purchase.LastPurchaseTicket = data[5].ToUpper() != "NULL" ? Convert.ToDouble(data[5]) : null;

            return purchase;
        }

        /// <summary>
        /// Ssnitation the data
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns>Clean string data</returns>
        private string DataSanitation(string value)
        {
            return value
                .Replace(".", "")
                .Replace("-", "")
                .Replace("/", "");
        }
    }
}