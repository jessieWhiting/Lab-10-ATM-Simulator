using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_ATM_Simulator
{
    public class User
    {
        //Set to public to use throughout program
        public String UserName;
        public String Password;
        public int Balance;
        public int OriginBalance;


        public User(string userName, string password, int balance)
        {
            this.UserName = userName;
            this.Password = password;   
            this.Balance = balance;
            this.OriginBalance = balance;
        }
        //Gets Password from list. Sets to Password/password
        public String GetPassword()
        {
            return Password;
        }
        //Gets initial balance. Sets to Balance/balance
        public double GetBalance()
        {
            return Balance;
        }
       
        public void Deposit(int deposit)
        {
            OriginBalance = Balance;
            Balance += deposit;
        }

        public void Withdraw(int withdraw)
        {
            OriginBalance = Balance;
            Balance -= withdraw;
        }
    }
}


