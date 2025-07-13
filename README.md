# سیستم انتخاب واحد دانشگاهی

 وب اپلیکیشنی که با asp.net8 پیاده سازی شده، برای انتخاب واحد دانشجویان که با دریافت گروه های درسی و ساعات کلاس ها تمام اتخاب واحد های ممکن را به کاربر ارائه میدهد   
*وبسایت در حال توسعه میباشد* 

## نیازمندی‌ها (Prerequisites)

برای اجرای این پروژه به موارد زیر نیاز دارید:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  
- دسترسی به NuGet برای دانلود پکیج‌های مورد نیاز (`dotnet restore`)  
- IDE یا ویرایشگر مانند Visual Studio 2022 یا Visual Studio Code  

## نصب و راه‌اندازی (Setup & Installation)

### 1. کلون کردن پروژه

bash  
git clone https://github.com/NimaM83/EntekhabVahed.git 

### 2. ریستور کردن پکیج‌ها

برای بازیابی بسته‌های مورد نیاز پروژه، دستور زیر را در ترمینال داخل ریشه پروژه اجرا کنید:

bash  
dotnet restore

### 3. نصب EF Core CLI (ابزار خط فرمان) 

bash 
dotnet tool install --global dotnet-ef  

### 4. ساخت و به‌روزرسانی دیتابیس با EF Core 

bash
cd EntekhbVahed 
dotnet ef database update --project ./EV.Presistance/EV.Presistance.csproj --startup-project ./EV.Web/EV.Web.csproj  





### 5. اجرای پروژه

برای اجرای پروژه می‌توانید از دستور زیر استفاده کنید(در پوشه EV.Web):

bash  
dotnet run  

پس از اجرای پروژه، مرورگر را باز کرده و وارد آدرس زیر شوید:  
http://localhost:5119 
یا  
https://localhost:7186   



