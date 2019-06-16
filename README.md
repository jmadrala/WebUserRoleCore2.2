
# WebUserRoleCore2.2

Example  how to create a project asp.NET CORE 2.2. with Identity and user role

## Step 1 
---
In the first step create in Visual Studio 2019 a New ASP.NEt Web Application with Autentication - Idiwidual USer Account.

## Step 2
---
We want to be able to modify the source code of login registration forms, etc. Therefore, we will add the creation of the identity framework.
We will transfer the base  for in folder App_Data. See you file appsettings.json and change in  "ConnectionStrings": {"DefaultConnection": .... Look this

https://stackoverflow.com/questions/37058684/how-to-set-the-right-attachdbfilename-relative-path-in-asp-net-core

1. 
![NewScaffoldedItem](https://github.com/jmadrala/WebUserRoleCore2.2/tree/Step2/Image/1_NewScaffoldedItem.PNG "1")

2.
![Add_Identity](https://github.com/jmadrala/WebUserRoleCore2.2/tree/Step2/Image/2_Add_Identity.PNG "2")

3.
![Add_Identity Next](https://github.com/jmadrala/WebUserRoleCore2.2/tree/Step2/Image/3_Add_Identity_Next.PNG "3")

4.
![ScaffoldingReadme](https://github.com/jmadrala/WebUserRoleCore2.2/tree/Step2/Image/4_ScaffoldingReadme.png "4")

5.
![PackageManagerConsole](https://github.com/jmadrala/WebUserRoleCore2.2/tree/Step2/Image/5_PackageManagerConsole_Initial.PNG "5")


## Step 3
---
In the third step we will make:
- We will add a technical user with Admin privileges in the file "appsettings.jason" with an overt password - do not forget change it.
Preferably use "dotnet user-secrets" in own project. Use cmd and command

    >dotnet user-secrets set AdminUserPW [Password]
    
    and use in the project

    >var AdminUserPw = config ["AdminUserPW"];

        

- We add the Admin, Manager and Employee roles to the project

Now you can use

    [AllowAnonymous]
    public IActionResult Index()
        {
            //...
        }

    [Authorize(Roles="Manager")]
    public class ManageController : Controller
        {
            //....
        }

You can also use role-based authorization in the action method like so.
Assign multiple roles

    [Authorize(Roles="Admin, Manager")]
    public IActionResult Index()
        {
           //....
        }