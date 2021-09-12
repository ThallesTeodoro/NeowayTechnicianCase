FROM mcr.microsoft.com/dotnet/sdk:5.0
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
WORKDIR /app

RUN apt-get update && apt-get upgrade -y

RUN apt-get install -y libc6-dev libgdiplus

ENTRYPOINT dotnet --project source/NeowayTechnicianCase.ConsoleApplication run
