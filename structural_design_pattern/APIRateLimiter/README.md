# Distributed API Rate Limiter with Cache - Proxy Pattern

## Overview

This project demonstrates the use of the **Proxy Pattern** in building a **Distributed API Rate Limiter with Cache**. This system is designed to manage external API calls effectively, incorporating essential features like rate limiting, caching, and security. The application aims to ensure compliance with API usage constraints while optimizing performance and providing a secure access layer.

## Structural Pattern Used: Proxy Pattern

The **Proxy Pattern** provides a surrogate or placeholder for another object to control access to it. In this case, the proxy manages external API calls, handling caching and rate limiting, while also ensuring security through logging and authentication.

## Use Case: Distributed API Rate Limiter

The application serves as a middleware between clients and external APIs, allowing efficient retrieval of data such as weather information while adhering to API constraints.

### Example Flow:

1. **Client Request**: A client requests data (e.g., current weather) for a specific location.
2. **Proxy Checks Cache**: The proxy first checks if the requested data is available in the cache and is still fresh. If found, it returns the cached data.
3. **API Call**: If the data is not cached, the proxy calls the real API service, caches the result, and then returns the data to the client.
4. **Rate Limiting**: If the number of API calls exceeds the specified threshold, the proxy returns the most recent cached result or queues the request for later processing.

### Key Classes

- **`APIProxy`**: Acts as an intermediary, handling the logic for caching, rate limiting, and security.
- **`RealApiService`**: The actual implementation of the API that fetches data from the external service.
- **`CacheManager`**: Manages caching of API responses to optimize performance.
- **`RateLimiter`**: Implements logic to manage and enforce API call limits.
- **`ConsoleLogger`**: Handles logging of API requests and errors for monitoring and debugging purposes.

## How to Run the Program

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Steps to Run:
1. **Clone the repository**:
   ```bash
   git clone https://github.com/ronit16/Educational-Initiatives
   ```
2. **Navigate to the project directory**:
   ```bash
   cd structural_design_pattern/APIRateLimiter
   ```
3. **Build the project**:
   ```bash
   dotnet build
   ```
4. **Run the application**:
   ```bash
   dotnet run
   ```

### Example Interaction

```
Enter a location to get weather data (or 'exit' to quit):
New York
Fetching weather data for New York...
Enter a location to get weather data (or 'exit' to quit):
exit
Goodbye!
```

## Conclusion

The **Distributed API Rate Limiter with Cache** application effectively demonstrates how the **Proxy Pattern** can be utilized to create a resilient, scalable, and secure system for managing external API interactions. By abstracting complexity and implementing essential features like caching and rate limiting, the application ensures efficient and reliable access to critical data sources.