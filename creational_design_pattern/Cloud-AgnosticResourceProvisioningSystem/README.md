# Cloud-Agnostic Resource Provisioning System - Abstract Factory Pattern

## Overview

This project demonstrates the use of the **Abstract Factory Pattern** in a **Cloud-Agnostic Resource Provisioning System**. This system allows users to provision cloud resources (such as virtual machines, databases, and storage) across multiple cloud providers (AWS, Azure, Google Cloud) without changing the underlying code. By abstracting cloud-specific details, the system enhances adaptability and scalability.

## Creational Pattern Used: Abstract Factory Pattern

The **Abstract Factory Pattern** provides an interface for creating families of related or dependent objects without specifying their concrete classes. This approach allows the provisioning system to support different cloud providers in a unified way.

## Use Case: Cloud-Agnostic Resource Provisioning

This system allows clients to provision resources in a cloud-agnostic manner. Here's a flow of how it works:

### Example Flow:

1. **Client Input**: The user selects a cloud provider (AWS, Azure, or GCP) for resource provisioning.
2. **Abstract Factory**: Based on user input, the appropriate concrete factory (AWSFactory, AzureFactory, GCPFactory) is instantiated.
3. **Resource Provisioning**: The system provisions resources such as virtual machines and databases using the selected cloud provider's factory.
4. **Logging**: Each provisioning action is logged for tracking and monitoring.

### Code Structure

#### Core Components

- **`ICloudResourceFactory`**: Interface that defines methods for creating cloud resources.
- **`AWSCloudResourceFactory`, `AzureCloudResourceFactory`, `GCPCloudResourceFactory`**: Concrete implementations of the abstract factory that provide methods to create specific cloud resources for AWS, Azure, and Google Cloud.
- **`CloudResourceProvisioner`**: Class responsible for managing the provisioning process using the selected cloud resource factory.

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
   cd creational_design_pattern/Cloud-AgnosticResourceProvisioningSystem
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
Select cloud provider (1 for AWS, 2 for Azure, 3 for GCP):
1
Provisioning resources in AWS...
Resources provisioned successfully.
Do you want to provision more resources? (yes/no):
no
Goodbye!
```

## Conclusion

The **Cloud-Agnostic Resource Provisioning System** showcases how the **Abstract Factory Pattern** can be effectively used to create a scalable, maintainable, and flexible cloud resource provisioning system. By abstracting cloud provider details, the system allows users to provision resources seamlessly across multiple cloud platforms without modifying core logic.