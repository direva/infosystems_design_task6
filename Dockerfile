FROM mcr.microsoft.com/dotnet/sdk:3.1

WORKDIR /app

COPY /app /app

EXPOSE 5000

CMD ["dotnet", "bin/Debug/netcoreapp3.1/app.dll"]