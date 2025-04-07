# 🩸 Blood Donation Management System

A complete ASP.NET Web API-based backend system to manage blood donors and blood requests in a blood donation center. The system allows CRUD operations on donors, handles blood request tracking, and supports image uploads for donor profiles.

---

---

## 💡 Features

- 🧑‍🦱 **Donor Management**: Add, update, delete, view donors with validations.
- 🩸 **Blood Requests**: Track and associate blood requests with donors.
- 📷 **Image Upload**: Upload donor profile pictures using the `/Upload` endpoint.
- 🧠 **Enum Mapping**: Blood types are managed through an enum (`BloodType`) for type safety and clarity.
- 📆 **Donation Tracking**: Maintain the last donation date for each donor.
- 🔄 **Relational Data**: One-to-many relationship between Donors and BloodRequests using Entity Framework.

---

## 🛠 Technologies Used

- ASP.NET Web API
- Entity Framework
- C#
- SQL Server
- LINQ
- Data Annotations (for model validation)

---

## 🧪 API Endpoints

### Donor Controller (`/api/Donors`)
| Method | Route                  | Description                    |
|--------|------------------------|--------------------------------|
| GET    | `/api/Donors`          | Get all donors                 |
| GET    | `/api/Donors/{id}`     | Get donor by ID                |
| POST   | `/api/Donors`          | Add a new donor                |
| PUT    | `/api/Donors/{id}`     | Update an existing donor       |
| DELETE | `/api/Donors/{id}`     | Delete a donor by ID           |

### Upload Endpoint
| Method | Route         | Description              |
|--------|---------------|--------------------------|
| POST   | `/Upload`     | Upload donor image       |

---

## 📸 Sample Image Upload

To upload an image:

```bash
POST /Upload
Content-Type: multipart/form-data
Form-Data:
- File: your_image.jpg

🧩 Entity Relationship
Donor has a collection of BloodRequests

BloodRequest includes a ForeignKey to the Donor
