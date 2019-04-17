FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["test/MSAspNetCoreDemo/MSAspNetCoreDemo.csproj", "test/MSAspNetCoreDemo/"]
COPY ["src/MS.DataAccess/MS.DataAccess.csproj", "src/MS.DataAccess/"]
COPY ["src/MS/MS.csproj", "src/MS/"]
COPY ["src/MS.AspNetCore/MS.AspNetCore.csproj", "src/MS.AspNetCore/"]
COPY ["src/MS.Castle.Log4Net/MS.Castle.Log4Net.csproj", "src/MS.Castle.Log4Net/"]
RUN dotnet restore "test/MSAspNetCoreDemo/MSAspNetCoreDemo.csproj"
COPY . .
WORKDIR "/src/test/MSAspNetCoreDemo"
RUN dotnet build "MSAspNetCoreDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MSAspNetCoreDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MSAspNetCoreDemo.dll"]