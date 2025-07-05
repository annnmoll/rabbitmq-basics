# RabbitMQ Basics in C#

Welcome to the **RabbitMQ Basics in C#** repository! 🐰📬  
This repository contains simple and clear examples of how to use [RabbitMQ](https://www.rabbitmq.com/) with C# for learning message queue patterns.

---

## 📚 What You'll Learn

This repository will help you understand:

- 📥 What is RabbitMQ and how it works
- 📦 Message Queuing Concepts
- 🧵 Sending and Receiving Messages in C#
- 💼 Work Queues for Load Distribution
- 📢 Publish/Subscribe Pattern
- 🧭 Routing and Topics
- 📃 Headers Exchange (Coming Soon)
- 📡 RPC over RabbitMQ (Coming Soon)

---

## 🔧 Technologies Used

- [.NET](https://dotnet.microsoft.com/)
- [RabbitMQ.Client](https://www.nuget.org/packages/RabbitMQ.Client)
- C#
- Console Applications
- Docker (for running RabbitMQ server locally)

---
🚀 Getting Started

1. Clone the repository

git clone https://github.com/<your-username>/rabbitmq-basics.git
cd rabbitmq-basics

2. Run RabbitMQ locally (optional)

You can run RabbitMQ using Docker:
docker run -d --hostname rabbit-host --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
Access the management UI at: http://localhost:15672Default credentials: guest / guest

3. Open the project in Visual Studio or VS Code and run the examples.

🧠 Concepts Covered
Queues: Buffers that store messages
Exchanges: Route messages to queues
Bindings: Define rules for routing
Consumers/Producers: Apps that send/receive messages
Durability & Acknowledgments: Ensure message delivery

🛠 Prerequisites
.NET 6 SDK
RabbitMQ Server or Docker
Basic knowledge of C# and messaging systems

✍️ Author
Anmol Ahuja📧 anmolahuja250@gmail.com🔗
