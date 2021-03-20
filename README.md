# DMS - Document Management System
Application developed to manage PDF document with user detail.

We can implement user management to manage all users, but in current implementation we have provided textbox to enter user name and file selection which needs to upload.

#Functionality:
1. List all uploaded documents (Username and FileName)
2. Add new document
3. Download uploaded document
4. Delete uploaded document.

#Project Structure
--> Web
	--> DMS.Web      -  Front End using .Net Core MVC 
--> Service
	--> DMS.API      -  REST API using .Net Core API 
	--> DMS.Models   -  Shared Model using .Net Core Class Library 
	--> DMS.Services -  Business Service Layer using .Net Core Class Library
	--> DMS.DAL      -  Data access layer using .Net Core Class Library


#Project Implementation Description
--> Web
	--> View Model
		--> View Model created to define view specific structure to get input. It helps if we need to have more parameter which is specific to View.
	--> File Storage
		--> Current implementation storing file into database. We can store the same in File Repository (e.g. Sharepoint) or on server location.
	--> REST API Communication
		--> Created one wrapper class to consume REST API. (Location: DMS.Web.RestClient)
		--> Created UserFileService which consume the API using REST API wrapper (Location: DMS.Web.Service)
--> Service	
	--> API Controller
		--> UserFileController implemented the method for GET (All & By Id), POST, DELETE. It passes/receive data to/from  IUserFileService.
	--> Extension Method
		--> Implemented extension method to Convert DAL models to/from Service models. (DMS.Services.ConverterExtension). We can use Automapper or other tool, but as very small project used extension method to convert object.
		--> Implemented service collection extension method in specific class library. (DMS.Services.Extension.ServiceExtension, DMS.DAL.Extension.DALExtension)
	--> Repository	
		--> Implemented UserFileRepository as independent service. We can have Generic repository with all the implemenation of Add, Update, Delete, GetAll, GetById, & Search.

#How to Run
Config:
	--> Database connection string:
		--> Set database connection string in "DMS.API --> appsettings.json" (Connectionstring -> DefaultConnection)
	--> Set API URL into web:
		--> Run DMS.API and copy the path and set into "DMS.Web --> appsettings.json" (ApiUrl)
Run:
	--> To run we need to run both DMS.Web and DMS.API project simultaneously. Or deployed on IIS and configure the path and run.
		