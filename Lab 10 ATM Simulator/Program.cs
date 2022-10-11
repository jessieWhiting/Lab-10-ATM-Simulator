using System.Security.Cryptography.X509Certificates;

namespace Lab_10_ATM_Simulator
{

    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Welcome to the ATM: ");
            
            //List some users to test with:
            List<User> users = new List<User>();
            users.Add(new User("jessieAndTyr", "CatNip66!", 1234));
            users.Add(new User("MarioLuigi64", "w3ar3st@rdust", 99));

            String userName = " ";
            User currentUser;

            String newUser = " ";
            String newPassword = " ";
            double newBalance;
            //////////////////////////////////////////////////////////////////
            int input = 0;
            do
            {
                PrintOpenOptions();
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch { }
                if (input == 1)
                {
                    Console.WriteLine("Welcome New User: ");
                    Console.WriteLine("============================================");
                    Console.WriteLine("Enter new User Name: ");
                    Console.WriteLine("============================================");
                    newUser = Console.ReadLine();

                    Console.WriteLine("Enter new Password: ");
                    newPassword = Console.ReadLine();
                    while (true)
                    {
                        Console.WriteLine("Enter initial Deposit amount: ");
                        string nBalance = Console.ReadLine();
                        if(Double.TryParse(nBalance, out newBalance))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Invalid");
                        }
                    }

                    users.Add(new User(newUser, newPassword, newBalance));
                    Console.WriteLine("============================================");
                    Console.WriteLine("Account Added:\n Please Login to view Account Information.\n");
                }
                else if (input == 2)
                {
                    Console.WriteLine("Please Enter your Username: ");
                    break;
                }
                else if (input == 3)
                {
                    Console.WriteLine("Exit Successful.");
                    return;
                }
                else
                {
                    input = 0;
                }
            }
            while (input != 3);

            while (true)
            {
                try
                {
                    userName = Console.ReadLine();
            //Check to see if username in list
                    currentUser = users.First(x => x.UserName == userName);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("User Name not recognized. Please enter a valid Username. ");
                    }
                }
                catch
                {
                    Console.WriteLine("User Name not recognized. Please enter a valid UserName. ");
                }
            }
            Console.WriteLine("Enter Password (case sensitive): ");

            while (true)
            {
                try
                {
                    String password = Console.ReadLine();
                    currentUser = users.First(x => x.Password == password);
                    if (currentUser.GetPassword() == password)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password not recognized. Please enter a valid password");
                    }
                }
                catch
                {
                    Console.WriteLine("Password not recognized. Please enter a valid password");
                }
            }
            Console.WriteLine($"\nHello, {userName} Your beginning balance is: ${currentUser.OriginBalance}");
            //Create a loop for user options.
            //Do:choice registration by number. Use if/else -While:Choices are not 5(Log off)


            static void PrintOpenOptions()
            {
                Console.WriteLine("============================================");
                Console.WriteLine("(MAIN PAGE) Choose one of the following:");
                Console.WriteLine("============================================");
                Console.WriteLine("1: Create new Username and Password");
                Console.WriteLine("2: Login");
                Console.WriteLine("3: Exit");
                Console.WriteLine();
            }

            int choice = 0;
            do
            {
                PrintLoggedChoices();
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch { }
                if (choice == 1)
                {
                    Balance(currentUser);
                }
                else if (choice == 2)
                {
                    Deposit(currentUser);
                }
                else if (choice == 3)
                {
                    Withdraw(currentUser);
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    choice = 0;
                }
            }
            while (choice != 4);

            Console.WriteLine($"Transaction Complete: {userName} Successfully logged out. ");

            static void PrintLoggedChoices()
            {
            //Print general console message + choices
                Console.WriteLine("============================================");
                Console.WriteLine("(USER PAGE) Make a selection: ");
                Console.WriteLine("============================================");
                Console.WriteLine("1.) Check Balance: ");
                Console.WriteLine("2.) Deposit: ");
                Console.WriteLine("3.) Withdraw: ");
                Console.WriteLine("4.) Log Off: ");
            }

            static void Deposit(User currentUser)
            {
                Console.WriteLine("Deposit Amount?: \n");
                double deposit = Double.Parse(Console.ReadLine());
                if( deposit < 0)
                {
                    Console.WriteLine("Not a valid deposit amount.");
                    return;
                }
                currentUser.Deposit(deposit);
                Console.WriteLine($"Deposit Amount: ${deposit} New Balance: ${currentUser.GetBalance()}");
            }
            //Make a Withdraw, Link to current balance
            static void Withdraw(User currentUser)
            {
                Console.WriteLine("Withdrawal Amount?: \n");
                double withdrawal = Double.Parse(Console.ReadLine());
                //Check if user has enough money
                if (currentUser.GetBalance() < withdrawal)
                {
                    Console.WriteLine("Insufficient Funds.");
                }
                else if (withdrawal < 0)
                {
                    Console.WriteLine("Not a valid withdrawal amount.");
                    return ;
                }
                else
                {
                    currentUser.Withdraw(withdrawal);
                    Console.WriteLine($"Withdrawal Amount: ${withdrawal} New Balance: ${currentUser.GetBalance()} \n ");

                }
            }
            //Create initial balance for User
            static void Balance(User currentUser)
            {
                Console.WriteLine("Available Balance: $" + currentUser.GetBalance());
            }
        }
    }
}