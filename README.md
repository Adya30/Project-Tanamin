# 🚀 How to Run the Program

> Follow these steps to run the application properly.  
> 💡 Make sure all requirements are installed before running the project.

---

## 🐘 Start the Database

> ### **1️⃣ Install & Start PostgreSQL**
> - Ensure PostgreSQL is installed and running on your machine.  
> - *(Optional)* You may use an online PostgreSQL service such as **Neon**.

> ### **2️⃣ Prepare the Database**
> - Create the database manually, or  
> - Import the database structure provided in this project.

---

## 🛠 Open the Project

> ### **1️⃣ Launch Visual Studio**
> Open Visual Studio on your device.

> ### **2️⃣ Load the Project**
> - Open the project folder, or  
> - Load the solution file:
>   ```
>   Project_Tanamin.sln
>   ```

---

## 🔧 Configure the Database Connection

> Go to:
> ```
> app/dbconnect
> ```
> and open:
> ```
> connectdata.cs
> ```

> Update the following configuration values according to your PostgreSQL or Neon setup:

| Config Key     | Description              |
|----------------|--------------------------|
| 🖥 Host/Server  | Your database host       |
| 🗂 Database     | Database name            |
| 👤 Username     | PostgreSQL user          |
| 🔐 Password     | User password            |

---

## ▶️ Run the Application

> ### **1️⃣ Start the App**
> Press **F5** or click the **Start** button in Visual Studio.

> ### **2️⃣ You're Ready! 🎉**
> The application will run using the database configuration you set.

---

