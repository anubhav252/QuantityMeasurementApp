# 📏 Quantity Measurement Application

## 🚀 Overview

The Quantity Measurement Application is a scalable backend system built using ASP.NET Core (.NET) with a layered architecture.

It supports:
- Unit conversions
- Arithmetic operations (Add, Subtract, Divide, Compare)
- Temperature rules and constraints
- Database persistence using EF Core
- REST APIs with Swagger
- JWT Authentication and Google OAuth login
- Integration testing using MSTest

---

## 🏗️ Architecture

Client → Controller → Service → Data → Model

---

## 📁 Project Structure

- QuantityMeasurementAPI  
- QuantityMeasurementService  
- QuantityMeasurementData  
- QuantityMeasurementModel  
- QuantityMeasurementTest  

---

## 📘 UC1: Compare Same Unit

Goal: Compare two quantities with the same unit.

Example:  
1 ft == 1 ft → true  

---

## 📘 UC2: Compare Different Units

Goal: Compare quantities across different units.

Example:  
1 ft == 12 inch → true  

---

## 📘 UC3: Support Yard Unit

Goal: Extend system to include yard.

Example:  
1 yard == 3 ft → true  

---

## 📘 UC4: Support Centimeter

Goal: Add metric unit support.

Example:  
2.54 cm == 1 inch → true  

---

## 📘 UC5: Unit Conversion

Goal: Convert quantity from one unit to another.

Formula:  
result = value × (sourceFactor / targetFactor)

---

## 📘 UC6: Addition Operation

Goal: Add two quantities with unit conversion.

Example:  
1 ft + 2 inch = 14 inch  

---

## 📘 UC7: Target Unit Conversion

Goal: Return result in user-specified unit.

---

## 📘 UC8: Enum-Based Units

Goal: Replace hardcoded unit logic with enums.

Benefits:
- Type safety  
- Cleaner code  
- Easier extensibility  

---

## 📘 UC9: Generic Quantity System

Goal: Introduce generic quantity handling to reduce duplication.

---

## 📘 UC10: Improved Design

Goal: Refactor system for better flexibility and maintainability.

---

## 📘 UC11: Volume Support

Goal: Add support for volume measurement.

Units:
- Litre  
- Millilitre  
- Gallon  

---

## 📘 UC12: Subtraction & Division

Goal: Support subtraction and division operations.

---

## 📘 UC13: DRY Refactoring

Goal: Remove duplicate logic and centralize arithmetic operations.

Implementation:
Reusable method performBaseArithmetic() introduced.

---

## 📘 UC14: Temperature Handling

Goal: Support temperature units with strict rules.

Units:
- Celsius  
- Fahrenheit  
- Kelvin  

Rules:
- Conversion → Allowed  
- Equality → Allowed  
- Addition → Not allowed  
- Division → Not allowed  

Formulas:
F = (C × 9/5) + 32  
C = (F - 32) × 5/9  
K = C + 273.15  

---

## 📘 UC15: N-Tier Architecture

Goal: Separate application into multiple layers.

Flow:
User → Controller → Service → Repository → Model  

Benefits:
- Loose coupling  
- Testability  
- Scalability  

---

## 📘 UC16: Database Integration (ADO.NET)

Goal: Persist data using SQL Server.

Tables:

Quantities  
Id | Value | Unit | Category  

Operations  
Id | FirstQuantity | SecondQuantity | Operation | Result | ResultUnit | CreatedAt  

Features:
- Save quantities  
- Save operations  
- Retrieve history  
- Delete records  

Challenges:
- Manual SQL handling  
- Complex queries  

---

## 📘 UC17: Web API + EF Core

Goal: Convert system into REST API using ASP.NET Core and EF Core.

Features:
- Controllers and routing  
- DTO-based requests  
- EF Core DbContext  
- LINQ queries  

---

## 📘 UC18: Authentication & Authorization

### 🔐 UC18.1: JWT Authentication

Goal: Secure APIs using JWT tokens.

Flow:
Login → Generate Token → Client stores token → Send token in requests  

Features:
- Stateless authentication  
- Secure API access  
- Claims-based identity  

---

### 🔐 UC18.2: Google Authentication

Goal: Allow login using Google account.

Flow:
Google Login → ID Token → Backend validation → JWT issued  

Benefits:
- No password storage  
- Secure authentication  
- Faster onboarding  

---

### 👤 UC18.3: Get Logged-in User

Goal: Fetch current authenticated user details.

Endpoint:
GET /api/auth/me  

Response:
{
  "username": "user@gmail.com",
  "email": "user@gmail.com"
}

---

### 🔒 UC18.4: Secure APIs

All protected APIs use:
[Authorize]

---

## 🌐 API Endpoints

Public:

POST /api/auth/register  
POST /api/auth/login  
POST /api/auth/google-login  

Protected:

GET /api/auth/me  
POST /api/quantities/convert  
POST /api/quantities/add  
POST /api/quantities/subtract  
POST /api/quantities/divide  
POST /api/quantities/compare  
GET /api/quantities/history  
DELETE /api/quantities/clear  

---

## 🧾 DTO Design

DTOs used:

- ConvertRequest  
- QuantityRequest  
- CompareRequest  
- DivideRequest  
- RegisterRequest  
- LoginRequest  
- GoogleLoginRequest  

Rule:
DTO structure must match JSON request format exactly.

---

## 🧰 Middleware

- Global exception handling  
- Structured JSON error responses  

---

## 📊 Swagger

- API documentation  
- Interactive testing  
- JWT Authorization support  
- Automatic header injection  

---

## 🧪 Testing (MSTest)

Features:
- Integration testing  
- API validation  
- Error handling verification  
- JSON response testing  

---

## 📊 Features Summary

| Feature | Supported |
|--------|----------|
| Equality | Yes |
| Conversion | Yes |
| Arithmetic | Yes |
| Volume | Yes |
| Temperature | Yes |
| Database | Yes |
| REST API | Yes |
| Swagger | Yes |
| JWT Auth | Yes |
| Google Auth | Yes |
| Testing | Yes |

---


## 📌 Future Enhancements
 
- Frontend integration 
- Microservices
- Deployement 

---

## 🧠 Design Principles

- SOLID  
- DRY  
- Separation of Concerns  

---

## 🏗️ Design Patterns

- Dependency Injection  
- Repository Pattern  
- Facade Pattern  
- Middleware Pattern  

---
