TRANSACTION SYSTEM

STRUCTURE
- A Transaction API that receives incoming transactions.
- A Transaction Processing Queue to manage transaction requests.
- A Background Processor Service to process the queue asynchronously, ensuring thread safety and avoiding deadlocks.
- Docker and Load Balancer configurations for scalability in the cloud environment.

TransactionSystem/
├── TransactionSystem.sln
├── TransactionProcessor/           # Main application folder
│   ├── Controllers/                # Contains API controllers
│   │   └── TransactionController.cs
│   ├── Models/                     # Data models for transactions
│   │   └── Transaction.cs
│   ├── Services/                   # Services for queuing and processing transactions
│   │   ├── ITransactionQueue.cs
│   │   ├── TransactionQueue.cs
│   │   └── TransactionProcessorService.cs
│   ├── Program.cs                  # Main program entry
│   ├── Startup.cs                  # Dependency injection setup
│   └── TransactionProcessor.csproj
└── Dockerfile                      # Dockerfile for containerizing the application
└── docker-compose.yml              # Docker Compose for orchestrating multiple instances


RUN application
docker compose up -d
docker compose down 


SEND test data
curl -X POST http://localhost:5000/api/Transaction/submit -H "Content-Type: application/json" -d '{"Id":"1", "Data":"Sample Transaction"}'