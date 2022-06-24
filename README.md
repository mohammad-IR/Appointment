# project university of vru 
## Project Appointment with dot net mvc 6

this project is for University of Vru and writed in 24 june 2022.
this project have 5 part 
### parts
* services 
* main project(web)
* models
* DataAccess
* Utilities

## Start up project
this project when runs sql server is a server of database and Host is IIS Expertion
and by file DbInitilizer run the initial data
``
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
``
the role is Admin and User we can any thing but i did 'nt have time and decided to write a little project.


## Descriptions
when you are in admin role you access the all appointments and all users but if you are user you only access to your appointment i write the infrastructure of search for users and admin but don't write front.
every user can order our appointment but can not write for another person. 