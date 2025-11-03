
🧾 Payroll Management System

## 📘 Overview
Payroll Management System is a **C# (Windows Forms)** application that automates employee payroll processes.  
It connects with **SQL Server** for data storage and supports **data import from Microsoft Excel** for efficient employee data management.  

---

## ⚙️ Key Features
- 👨‍💼 **Employee Management:** Add, update, and search employee records.  
- 💰 **Payroll Calculation:** Automatically calculate salaries, deductions, and bonuses.  
- 🗃️ **SQL Server Integration:** All data is securely stored in a connected SQL Server database.  
- 📊 **Excel Import:** Import bulk employee or salary data directly from Microsoft Excel files.  
- 🔍 **Search & Filter:** Quickly find employees by ID, name, or department.  
- 🧾 **DataGridView Display:** Real-time data view after search or update.  
- ⚠️ **Validation:** Error messages for invalid or missing data.  

---

## 🧩 Technologies Used
- **Language:** C# (.NET Framework / WinForms)  
- **Database:** Microsoft SQL Server  
- **Excel Integration:** Microsoft.Office.Interop.Excel  
- **IDE:** Visual Studio  

---

## 🗄️ Database Setup
1. Create a database in SQL Server named `PayrollDB`.  
2. Run the provided SQL script (`PayrollDB.sql`) to create tables (e.g., `tbl_employee`, `tbl_salary`).  
3. Update your **connection string** in `App.config`:  
   ```xml
   <connectionStrings>
       <add name="PayrollDB" connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=PayrollDB;Integrated Security=True"/>
   </connectionStrings>
