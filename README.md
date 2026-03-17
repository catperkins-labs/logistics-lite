# logistics-lite

A lightweight logistics / inventory management system.

**Stack:** .NET 8 Minimal API · EF Core · SQL Server · React + TypeScript (Vite)

---

## Getting Started

### Prerequisites

- [Docker](https://docs.docker.com/get-docker/) & Docker Compose
- [Node.js](https://nodejs.org/) 20+
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (optional, for running the API outside Docker)

### 1 — Configure environment

```bash
cp .env.example .env
# Edit .env and set a strong SA_PASSWORD
```

Copy the frontend env file:

```bash
cp web/.env.example web/.env
# Edit VITE_API_BASE_URL if needed (default: http://localhost:8080)
```

### 2 — Start SQL Server + API

```bash
docker compose up --build
```

This will:
- Start a SQL Server 2022 container with a persisted volume.
- Build and start the .NET API on port **8080**.

Verify the API is running:

```bash
curl http://localhost:8080/health
```

### 3 — Run the Frontend

```bash
cd web
npm install
npm run dev
```

The Vite dev server starts at <http://localhost:5173>.

---

## Project Structure

```
logistics-lite/
├── docker-compose.yml        # SQL Server + API services
├── .env.example              # Root env template
├── api/
│   ├── Dockerfile
│   ├── LogisticsLite.slnx
│   └── src/
│       ├── LogisticsLite.Api/   # .NET 8 Minimal API
│       └── LogisticsLite.Data/  # EF Core DbContext + entities
└── web/                      # React + TypeScript (Vite)
    ├── .env.example
    └── src/
        ├── pages/            # Login, Items, Inventory, ScannerMode
        └── lib/apiConfig.ts  # API base URL config
```

---

## Planned Features

- **Orders management** — Create, fulfil, and track purchase/transfer orders.
- **Inventory management** — Real-time stock levels with full transaction history across locations.
- **Scanner Mode** — Mobile-friendly barcode / QR scanning UI for receiving and picking.
- **Authentication** — JWT-based login with role support (admin, warehouse operator).
- **Reporting** — Inventory snapshots, low-stock alerts, and transaction exports.
