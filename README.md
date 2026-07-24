# Employee Management System

## Overview

The **Employee Management System** is a **C# Console Application** designed to practice **.NET Collections** and **Object-Oriented Programming (OOP)** concepts. It simulates a simple employee management workflow where employees are added to an onboarding queue, processed into active employees, assigned to departments, and managed using different collection types.

---

## Objectives

* Practice using C# Collections.
* Apply Object-Oriented Programming (OOP) concepts.
* Build a console-based management system.
* Perform searching and reporting operations.

---

## Technologies

* C#
* .NET Console Application
* Visual Studio

---

## OOP Concepts Used

* Classes
* Objects
* Constructors
* Encapsulation
* Inheritance (`clsManager` inherits from `clsEmployee`)
* Separation of Models and Services

---

## Collections Used

| Collection              | Purpose                                            |
| ----------------------- | -------------------------------------------------- |
| Queue<clsEmployee>      | Stores employees waiting for onboarding.           |
| Stack<clsEmployee>      | Maintains employee action history.                 |
| List<clsEmployee>       | Stores active employees.                           |
| Dictionary<int, string> | Stores departments using Department ID as the key. |
| HashSet<string>         | Stores unique employee skills without duplicates.  |

---

## Project Structure

```text
ConsoleApp4
│
├── Models
│   ├── clsEmployee.cs
│   ├── clsManager.cs
│   └── clsDepartment.cs
│
├── Services
│   └── clsCompany.cs
│
└── Program.cs
```

---

## Features

### Employee Management

* Add employee to onboarding queue.
* Process the next employee into the active employees list.
* Search employee by ID.
* Search employee by name.

### Department Management

* Add new department.
* Display employees belonging to a specific department.

### Reports

* Calculate average employee salary.
* Display the number of employees in each department.
* Print action history.
* Display all unique employee skills.

---

## Main Menu

```text
========== Company Management ==========

1. Add Employee To Onboarding
2. Process Next Employee
3. Add Department
4. Search Employee By ID
5. Search Employee By Name
6. Print Employees By Department
7. Calculate Salary Average
8. Employees Report By Department
9. Print Action History
10. Print Unique Skills
0. Exit
```

---

## Seed Data

The project starts with predefined data including:

* Three Departments

  * HR
  * IT
  * Finance

* Three Employees

  * Ahmed
  * Sara
  * Omar

The seed data allows immediate testing of all project features without entering data manually.

---

## Data Flow

```text
Employee
      │
      ▼
Onboarding Queue
      │
Process Employee
      ▼
Active Employees List
      │
      ├── Search
      ├── Reports
      ├── Salary Average
      └── Department Filtering
```

---

## Validation

The system validates:

* Duplicate employee IDs.
* Duplicate department IDs.
* Duplicate department names.
* Unique employee skills.
* Existing employees before printing search results.

---

## Learning Outcomes

This project demonstrates practical usage of:

* Queue (FIFO)
* Stack (LIFO)
* List
* Dictionary
* HashSet
* Searching
* Reporting
* Console Menu
* Object-Oriented Programming principles

---

## Future Improvements

* Remove employees.
* Update employee information.
* Save and load data from files.
* Exception handling using `TryParse`.
* LINQ-based searching and reporting.
* Generic Repository implementation.

---

## Author

**Rowida Hany**


