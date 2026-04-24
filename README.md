# Food Hub: Real-Time Order Aggregator 🍔

## 🛠 Project Overview
A specialized integration service designed to bridge the gap between third-party food delivery platforms (Swiggy, Zomato) and core ERP systems. This project demonstrates the architectural pattern required to handle high-frequency webhook traffic and real-time data synchronization.

## 🧠 Key Challenges & Solutions
* **The Integration Gap:** Solved the problem of manual order entry by building a standalone .NET 8 service that acts as a "Translator" between external JSON payloads and internal ERP schemas.
* **Data Integrity:** Implemented a validation layer to handle inconsistent data formats from different providers.
* **Real-Time Alerts:** Integrated SignalR to provide instant desktop notifications to restaurant staff the moment a webhook is received.

## 🏗 Architectural Highlights
* **Webhook Listener:** An asynchronous API endpoint designed to handle POST requests with 99.9% uptime.
* **Resilience Pattern:** Uses exponential backoff (Polly) to ensure that if the ERP is temporarily offline, order data is not lost.
* **Security:** HMAC signature verification to ensure incoming webhooks are legitimately from the aggregator.

> **Note:** This repository serves as an architectural case study. Source code is restricted due to NDA, but I am happy to discuss the implementation details.
