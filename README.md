# project university of **vru** 
## Project Appointment with  .Net mvc 6

this project is for University of Vru and writed in 24 june 2022.
this project have 5 part 
### parts
* services 
* main project(web)
* models
* DataAccess
* Utilities

### *every part have readme file for that part and classes*

## Start up project
this project when runs sql server is a server of database and Host is IIS Expertion
and by file DbInitilizer run the initial data
```

if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "m.ilaghi5273@gmail.com",
                    FirstName = "mohammad sadegh",
                    LastName = "Ilaghi hoseini",
                    Email = "m.ilaghi5273@gmail.com",
                    PhoneNumber = "09162785273",
                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "m.ilaghi5273@gmail.com");

                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }
```

the role is Admin and User we can any thing but i did 'nt have time and decided to write a little project.


## Descriptions
when you are in admin role you access the all appointments and all users but if you are user you only access to your appointment i write the infrastructure of search for users and admin but don't write front.
every user can order our appointment but can not write for another person. 

# for technology of .Net 6

this stack have many type for web and every type have one structure 
but now i discuss about platform MVC.

## start up file
file **program.cs** have a start up of a project and 
every configuration  for example database has in this file 
on this file i have DbInitializer to migrate automatic files of database and 
all tables are in file *ApplicationDbContext* and *IdentityRole* and *IdentityUser* for Users Table but for 
custom user you must inherite that.
controllers are in file controllers and routes determines by file for example `controller/AccountController/Register` route is
`~/Account.Register`.

## Models
models for mini project can by write in main folder but better write to file by name 
**nameProject.Models** for example File ApplicationUser have entity of user for microsoft and plus two element 
FirstName and Last Name.
## Data
you are tables but must be in one place and place is this part for example we have to table first 
is ApplicationUser and two is AppointmentTime added in this file

```
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers{ get; set; }
        public DbSet<AppointmentTime> AppointmentTimes{ get; set; }

    }
```
and you add this file to program.cs

```
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

migration file is in this part.

## Services
i write services of web in this file and for this project i have only one Class and have this methods

1. StartAndEnd
2. ForOneUser
3. ToDay
4. DateDay
5. CreateAsync
6. RemoveAsync

and this method create or delete or search appointment more of that don't use in web becouse don't 
have time but can by use in search by Ajax.
## Utitlities 
this part is for Enum or Roles for Example *SD* write two role user and admin and use another part
```
    public static class SD
    {
        public const string Role_User = "User";
        public const string Role_Admin = "Admin";
    }
```

## controller

in controller a have three class and every class do one thing. 
### AccountController
part first is AccountController and for Authentication and two method `Register`
and `Login`. 
### HomeController
this class have one method and this name is index and is for route '~/'

### AppointmentController
this class have three route 
1. '~/Appointment' method index
2. '~/Appointment/Create' get and post for create new appointment
### SeachController
this class for search by ajax but don't implement on front.


## View file 
in this file render html and css `share folder` have file main and another file automatic extend this file
but main file is `Layout.cshtml`.

## Json file
config file for example connection to database config is in this file 
and use this config in `program.cs`.
## file root
`css` , `javascripts` , `images`, `libraries` is in this part (*files public*).
 
