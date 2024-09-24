# Enterprise-Level Report Generator - Builder Pattern

## Overview

This project demonstrates the **Builder Pattern** in the context of an enterprise-level **Report Generator**. In large-scale enterprise applications, generating complex reports from multiple data sources with different formats (PDF, CSV) and layouts (single-page, paginated) is a common requirement. This implementation uses the **Builder Pattern** to assemble reports in a flexible and modular way.

## Creational Pattern Used: Builder Pattern

The **Builder Pattern** allows for step-by-step construction of complex objects (in this case, reports), separating the construction process from the final representation. This ensures flexibility and modularity in generating reports with varying configurations.

### Example Flow:

1. **Client Input**: The user requests a report by selecting the format (PDF or CSV), layout (single-page or paginated), and provides the content.
2. **Director**: The director controls the process, instructing the builder to create the report step by step.
3. **Builder**: The builder constructs the report based on the selected format and layout:
   - Retrieves data (e.g., financial details, logs).
   - Sets up the layout (single-page or paginated).
   - Formats the content (CSV, PDF).
4. **Final Product**: The generated report is assembled and presented to the user.

## Use Case: Configurable Enterprise Report Generator

This system demonstrates how to generate complex reports that can be customized based on user requirements. It supports:
- **Different Formats**: PDF and CSV formats are supported, but more can be easily added.
- **Flexible Layouts**: Reports can be either single-page or paginated.
- **Dynamic Content**: The content of the report is provided by the user at runtime.

## Code Explanation

### Core Components

- **`IReportBuilder` (interface)**: Defines the steps to build a report, such as setting the layout, adding content, and specifying the format.
- **`PdfReportBuilder` and `CsvReportBuilder`**: Concrete implementations of the `IReportBuilder` interface. Each builder creates a report in the respective format.
- **`ReportDirector`**: Orchestrates the building process. It directs the builder on how to assemble the report based on user input.
- **`Report`**: The final product. It stores the report content and layout and can display the generated report.

### How It Works

1. **Client Input**:
   - The user selects the report format (PDF or CSV).
   - The user provides the report content.
   - The user selects the layout (single-page or paginated).

2. **Director**:
   - The `ReportDirector` uses the appropriate builder (`PdfReportBuilder` or `CsvReportBuilder`) to construct the report.
   - The director controls the sequence of building steps:
     1. Sets the layout.
     2. Adds the content.
     3. Formats the report.

3. **Builder**:
   - The selected builder performs the actual report generation:
     - **PDF Builder**: Constructs a PDF report by formatting the content and setting up the layout (paginated or single-page).
     - **CSV Builder**: Creates a CSV report, applying the layout and formatting content into comma-separated values.

4. **Report**:
   - The final report is created by the builder and stored in a `Report` object, which can display or save the report as needed.

### How to Run the Program

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Steps to Run:
1. **Clone the repository**:
   ```bash
   git clone https://github.com/ronit16/Educational-Initiatives
   ```
2. **Navigate to the project directory**:
   ```bash
   cd creational_design_pattern/Enterprise-LevelReportGenerator
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
Select report format (1 for PDF, 2 for CSV):
1
Enter report content:
This is the sales report for Q3.
Enter report layout (Single-Page, Paginated):
Paginated
Processing your report...

Report generated successfully.
Do you want to generate another report? (yes/no)
no
Goodbye!
```

## Conclusion

The **Enterprise-Level Report Generator** project demonstrates how the **Builder Pattern** can be used to construct complex reports step-by-step. By decoupling the construction process from the final report representation, the system is highly flexible and easily extendable. It supports multiple formats and layouts, providing an efficient solution for generating customized reports in an enterprise environment.

---