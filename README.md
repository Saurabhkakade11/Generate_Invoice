# Inventory Billing System

## Project Overview

The **Inventory Billing System** is a web-based application developed using **ASP.NET MVC** and **Entity Framework** to streamline inventory management and billing processes.
It helps businesses manage customers, products, invoices, and payments efficiently. 
The system automatically updates stock levels after each sale and ensures accurate billing with GST calculations.

## Features

### 1. Customer Management

- Add, update, and delete customer details (name, email, mobile number, city).
- Fetch customer data dynamically for invoice generation.

### 2. Product Management

- Add new products with rate, GST, and available stock.
- Fetch product details dynamically when selected in the invoice form.
- Update stock levels when an invoice is generated.

### 3. Invoice Generation

- Create invoices by selecting a customer and adding multiple products.
- Auto-calculate total amount including GST.
- Display all generated invoices.
- After generating an invoice, the user has two options:
  - **View Invoice:** Allows viewing the generated invoice, where a PDF version can be created.
  - **Pay Remaining Amount:** Enables payment processing for the pending amount.

### 4. Payment Processing

- Record payments for invoices with different payment modes (Cash, Card, UPI, etc.).
- Store payment date, description, and amount paid.

### 5. Reporting & Stock Management

- View generated invoices with customer and product details.
- Display pending payments and transaction history.
- Track stock quantity after each transaction.

---

## Technology Stack

- **Frontend:** HTML, CSS, JavaScript, jQuery, Bootstrap
- **Backend:** ASP.NET MVC, C#
- **Database:** SQL Server with **Entity Framework**
- **Tools:** Visual Studio, SQL Server Management Studio (SSMS)

---

## How It Works

### 1. Adding Customers & Products

- The admin can add customers and products via a simple form.
- Products include rate, GST percentage, and available stock quantity.

### 2. Invoice Generation

- The user selects a customer and adds products to an invoice.
- The system calculates the total amount based on the product price, quantity, and GST.
- The stock quantity is automatically updated after an invoice is created.
- After generating an invoice, the user can either **view the invoice** (where a PDF can be generated) or **pay the remaining amount**.

### 3. Handling Payments

- After generating an invoice, payments can be recorded against it.
- Payments can be made using various modes such as cash, card, or UPI.
- Users can track pending and completed payments.

### 4. Stock Management

- The system tracks product stock and prevents overselling.
- If stock is insufficient, an alert is displayed.

---

## Setup Instructions

### 1. Prerequisites

Ensure you have the following installed on your system:

- **Visual Studio (latest version)** with **.NET framework**
- **SQL Server Management Studio (SSMS)**
- **SQL Server database engine**

### 2. Clone the Repository

```sh
git clone https://github.com/yourusername/inventory-billing-system.git
cd inventory-billing-system
```

### 3. Database Configuration

- Open SSMS and create a new database named `InventoryBillingDB`.
- Execute the provided **SQL script** to create tables.

### 4. Configure Connection String

- Open `Web.config` in the project.
- Update the connection string with your SQL Server details:

```xml
<connectionStrings>
    <add name="InventoryDbContext"
         connectionString="Server=YOUR_SERVER_NAME;Database=InventoryBillingDB;Trusted_Connection=True;"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 5. Run the Application

- Open the project in **Visual Studio**.
- Build and run the application (`Ctrl + F5`).
- The web app will open in a browser where you can start adding customers, products, and invoices.

---

## Future Enhancements

- Implement role-based authentication (Admin, User).
- Generate PDF invoices directly from the invoice page.
- Add a dashboard with sales insights and stock alerts.

---

This **README.md** file provides a detailed overview of your **Inventory Billing System**, making it easy for others (or even yourself) to understand, set up, and use the project. 🚀

