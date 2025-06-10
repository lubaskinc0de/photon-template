up:
    docker compose up --build

down:
    docker compose down

clear:
    docker compose down -v

migrate:
    docker compose up --build -d
    docker exec -it api dotnet ef database update --project /app/Photon.Infrastructure.dll --startup-project /app/Photon.Web.dll
    just down

makemigration ARG1:
    docker compose up db -d
    dotnet ef database update --project ./src/Photon.Infrastructure --startup-project ./src/Photon.Web --context ApplicationDbContext --connection "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postggpass"
    dotnet ef migrations add {{ARG1}} --project ./src/Photon.Infrastructure --startup-project ./src/Photon.Web --context ApplicationDbContext
    just down
