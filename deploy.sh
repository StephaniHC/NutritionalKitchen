cd /var/www/nutritionalKitchen/
git pull
dotnet restore
dotnet-ef database update --project NutritionalKitchen.Infraestructura --startup-project NutritionalKitchen.WebApi --context StoredDbContext
dotnet build
dotnet publish --configuration Release