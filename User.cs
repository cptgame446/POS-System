using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } 
        public string Email { get; set; }
        private string _password;

        public string Password
        {
            get 
            {
                string output = new String('*', _password.Length);
                return output;
            }
            private set 
            {
                _password = value; 
            }
        }
        public bool IsAdmin { get; set; }
        public string MasterPassword { get; set; } = "12345";
        public string MasterUser { get; set; } = "Master";
        public bool ContinueBuild { get; set; } = true;



        public void BuildUser(List<User> personList)
    {         
            
        FirstName = DataAggregation.GetInputCapital("Please enter your first name: ");
        LastName = DataAggregation.GetInputCapital("Please enter your last name: ");

        bool emailValid = false;
        do
        {
            Email = DataAggregation.GetInput("Please enter your email address: ");
            emailValid = EmailCheck(Email);
        } while (emailValid == false);

        UserNameCheck(personList);

        bool passwordOk = false;
        do
        {
            _password = DataAggregation.GetInput("Please enter a password: ");
            passwordOk = PasswordCriteriaCheck(_password);
        } while (passwordOk == false);

        bool admin = DataAggregation.AddMore($"Is {FirstName} {LastName} an admin? ");
            if (!admin)
        {
            IsAdmin = false;
        }
        else
        {
                Console.WriteLine("You must be an Admin to make users an admin");
                IsAdmin = AdminCheck(personList);
                Console.WriteLine($"{FirstName} {LastName} set as admin.");

            }
         
    }
        public void UserNameCheck(List<User> personList)
        {

            bool cont = true;
            bool longEnough = false;

            do
            {
                UserName = DataAggregation.GetInput("Please enter your user name.  It must be at least 5 characters: ");
                longEnough = DataAggregation.LengthCheck(5, UserName);

                foreach (var person in personList)
                {
                    if (person.UserName == UserName)
                    {
                        Console.WriteLine("Sorry that username has already been taken, please try again");
                        cont = true;
                    }
                    else
                    {
                        cont = false;
                    }
                }

            } while (longEnough == false && cont == true);

        }

        public bool EmailCheck(string userInput)
        {
            bool period = false;
            bool at = false;
            bool output = false;
            
            if (userInput.Contains("."))
            {
                period = true;
            }
            if (userInput.Contains("@"))
            {
                at = true;
            }
            if (period == true && at == true)
            {
                output = true;
            }
            else
            {
                Console.WriteLine("You didn't enter a proper email.  Please try again.");
                output = false;
            }
            
            

            return output;
        }

        public bool PasswordCriteriaCheck(string userInput)
        {
            string str = userInput;

            char[] one = str.ToCharArray();

            bool capital = false;
            bool lowercase = false;
            bool number = false;
            bool specialCharacter = false;
            bool output = false;

            foreach (char c in userInput)
            {
                if (char.IsDigit(c))
                {
                    number = true;
                }
                if (char.IsUpper(c)) 
                {
                    capital = true;
                }
                if (char.IsLower(c))
                {
                    lowercase = true;
                }
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    specialCharacter = true;
                }
                if (char.IsWhiteSpace(c))
                {
                    Console.WriteLine("Please do not enter spaces!");
                }
            }

            if (capital && lowercase && number && specialCharacter)
            {
                output = true;
            }
            else
            {
                Console.WriteLine("You didn't enter a proper password.  It must contain at least one capital and lowercase letter, " +
                    "one special character, and one number.");
            }

            return output;
        }

        public bool AdminCheck(List<User> personList)
        {
            bool output = false;

            
            string userName = DataAggregation.GetInput("Please enter your user name: ");
            if (userName.ToLower() == MasterUser.ToLower())
            {
                string userPassword = DataAggregation.GetInput("Please enter the master password: ");
                if (userPassword == MasterPassword)
                {
                    output = true;
                }
            }
            else
            {
                foreach (var person in personList)
                {
                    User currentUser;
                    if (userName.ToLower() == person.UserName)
                    {
                        currentUser = person;
                        string userPassword = DataAggregation.GetInput($"Please enter the password for {currentUser.UserName}: ");

                        if (userPassword == currentUser._password)
                        {
                            if (currentUser.IsAdmin == true)
                            {
                                output = true;
                            }
                            else if (currentUser.IsAdmin == false)
                            {
                                Console.WriteLine($"Sorry {currentUser.UserName} is not an admin.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Password incorrect");
                        }
                    }
                }
            }






            //else
            //{
            //    foreach (var user in personList)
            //    {
            //        if (UserName.ToLower() == user.UserName.ToLower())
            //        {
            //            currentUser = user;
            //            string userPassword = DataAggregation.GetInput($"Please enter the password for {user.UserName}: ");

            //            if (userPassword == user.Password || userPassword == MasterPassword)
            //            {
            //                output = true;
            //            }
            //        }
            //    }
            //}
            return output;
        }
        public static void DisplayUser(List<User> personList)
        {
            string userInput = DataAggregation.GetInput("Enter the user's Last Name, or username: ");

            foreach (var user in personList)
            {
                if (userInput.ToLower() == user.LastName.ToLower() || user.UserName.ToLower() == userInput.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine($"{user.FirstName} {user.LastName}:");
                    Console.WriteLine($"Email: {user.Email} Admin: {user.IsAdmin}");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Sorry, user not found");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                }
            }
        }

    }

}
