FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
RUN apk update --no-cache && apk add icu-libs --no-cache
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
RUN apk update --no-cache
WORKDIR /src
COPY ["MdcBlazor/MdcBlazor.csproj", "MdcBlazor/"]
COPY ["MdcBlazor.Tools/MdcBlazor.Tools.csproj", "MdcBlazor.Tools/"]
COPY ["MdcBlazor.ServerDemo/MdcBlazor.ServerDemo.csproj", "MdcBlazor.ServerDemo/"]
RUN dotnet restore "MdcBlazor.ServerDemo/MdcBlazor.ServerDemo.csproj"
COPY . .
WORKDIR "/src/MdcBlazor.ServerDemo"
RUN dotnet build "MdcBlazor.ServerDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MdcBlazor.ServerDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exentials.MdcBlazor.ServerDemo.dll"]