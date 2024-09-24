# Fraud Detection System - Chain of Responsibility Pattern

## Overview

This project demonstrates the **Chain of Responsibility** behavioral design pattern applied to a **Fraud Detection System** for banking transactions. In this system, various checks (e.g., geographical checks, transaction volume checks, account behavior) are carried out in sequence, with each check represented by a handler in the chain. The goal is to flag fraudulent transactions at different levels, making the system flexible, modular, and easy to extend.

## Behavioral Pattern Used: Chain of Responsibility

In this design, a transaction is passed through a chain of fraud handlers, where each handler either processes or forwards the transaction to the next handler in the chain, depending on the check's outcome.

### Example Flow:
1. A transaction is submitted by the user.
2. The transaction is passed to the first handler (geographical check):
   - If the check passes, the transaction is forwarded to the next handler.
   - If the check fails (e.g., suspicious location), the transaction is flagged as fraud and not forwarded further.
3. The second handler (transaction volume check) processes the transaction next.
4. The third handler (account behavior check) performs its check.
5. The transaction passes through all checks, or is flagged as fraud at any step in the chain.

## Use Case: Fraud Detection in Banking Systems

Fraud detection is an essential feature in banking systems to prevent illegal transactions and protect customers. This system simulates how different fraud detection rules can be applied:

- **Geographical Location Check**: Detects if the transaction is happening in an unusual or suspicious location.
- **Transaction Volume Check**: Detects abnormal transaction volumes based on the account's typical transaction patterns.
- **Account Behavior Check**: Analyzes the transaction based on past behavior and history of the account holder.

## Code Explanation

### Core Classes

- **`FraudHandler` (abstract)**: The base handler class, which defines the interface for handling transactions and linking to the next handler in the chain.
- **`GeographicalCheckHandler`**: Checks the geographical location of the transaction.
- **`TransactionVolumeCheckHandler`**: Validates the transaction based on the volume (amount of money).
- **`AccountBehaviorCheckHandler`**: Checks the behavior and history of the account involved in the transaction.
- **`Transaction`**: Represents a banking transaction with attributes like amount, location, and account number.

### FraudDetectionSystem Class
- **`FraudDetectionSystem`**: The main system class that initiates the fraud detection process. It builds the chain of responsibility by linking the fraud checks in order and processes transactions based on user input.

### How it Works

1. The system prompts the user to either enter a new transaction or exit the system.
2. On entering a transaction, the system gathers the transaction amount, location, and account number.
3. The transaction is passed through the chain of fraud handlers:
   - **Geographical Check**
   - **Transaction Volume Check**
   - **Account Behavior Check**
4. If any of the handlers flag the transaction as fraudulent, the transaction is marked as fraud, and the user is informed.
5. The system continues to process transactions until the user chooses to exit.

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
   cd behavioural_design_pattern/FraudDetectionSystem
   ```
3. **Build the project**:
   ```bash
   dotnet build
   ```
4. **Run the application**:
   ```bash
   dotnet run
   ```

## Conclusion

The **Fraud Detection System** showcases how the **Chain of Responsibility** design pattern can be effectively used to handle complex, real-world applications like banking fraud detection. This modular design makes the system highly extensible, maintainable, and scalable, enabling the addition of new fraud checks without affecting existing logic.

---

