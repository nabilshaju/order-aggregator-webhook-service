- The Problem: Integrating multiple food delivery platforms (Swiggy, Zomato) into a central ERP without manual entry.

- The Solution: A standalone service built with .NET 8 that consumes webhooks and maps external JSON payloads to internal ERP schemas.

- Tech Highlights: * Webhooks: Handling asynchronous POST requests from third parties.

        - Real-time: Use of SignalR (or similar) to push order alerts to the ERP UI.
        
        - Resilience: Implementing a "Retry Logic" for failed syncs.
