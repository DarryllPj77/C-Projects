//Start
using System;
using System.Net.NetworkInformation;

class Program
{
    static void Main()
    {
        string correctPin = "1234";
        int balance = 0;
        int attempts = 0;
        string pin = "";
        Console.WriteLine("Welcome to the ATM");
        while(attempts < 3)
        {
            Console.Write("Enter Pin: ");
            pin = Console.ReadLine() ?? "";
            if(pin == correctPin)
            {
                break;
            }else{
                attempts = attempts + 1;
                Console.WriteLine("Incorrect PIN. Attempts left: " + (3 - attempts));
            }
        }

        if(attempts == 3)
        {
            Console.WriteLine("Account locked. Too many incorrect attempts.");
            return;
        }

        //Main ATM Menu
        int choice = 0;
        int amount = 0;
        do{
            Console.WriteLine("");
            Console.WriteLine("=====================");
            Console.WriteLine("ATM MENU");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");
            choice = int.Parse(Console.ReadLine() ?? "0");
            switch (choice)
            {
                case 1:
                    Console.Write("Your Balance is: " + balance);
                    break;
                case 2:
                    Console.Write("Enter amount to deposit: ");
                    amount = int.Parse(Console.ReadLine() ?? "0");
                        if(amount > 0)
                        {
                            balance = balance + amount;
                            Console.Write("Deposit successful. New balance: " + balance);
                        }else{
                            Console.WriteLine("Invalid deposit amount.");
                        }
                    break;
                case 3:
                    Console.Write("Enter amount to withdraw: ");
                    amount = int.Parse(Console.ReadLine() ?? "0");
                    if(amount <= 0)
                    {
                        Console.WriteLine("Invalid withdrawal amount.");
                    }
                    else if(amount > balance)
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                    else
                    {
                        balance = balance - amount;
                        Console.Write("Withdrawal successful. New Balance: " + balance);
                    }
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the ATM.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again!");
                    break;
            }
        } while(choice !=4);
    }
}




