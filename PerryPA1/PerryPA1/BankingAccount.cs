using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PerryPA1
{
    class BankingAccount
    {
        private readonly string username;
        private readonly string password;

        public string Username { get => username; }
        public string Password { get => password; }
        public double Balance { get; set; }

        public BankingAccount()
        {
            do
            {
                Console.Write("Create Username: ");
                username = Console.ReadLine();
                Console.Write("Create Password: ");
                password = Console.ReadLine();
                Balance = 0;
            }
            while (username == "" || password == "");

            if (Process.GetProcesses() == null)
                Environment.Exit(0);
        }

        public BankingAccount(string username, string password, double balance )
        {
            this.username = username;
            this.password = password;
            Balance = balance;
        }

        public void Deposit(double depositValue)
        {
            Balance = Balance + depositValue;
        }
        public void Withdraw(double withdrawValue)
        {
            Balance = Balance - withdrawValue;
        }
        public override string ToString()
        {
            return $"Current Bank balance is {Balance:C}";
        }
        public bool[] ValidatePassword(string _username, string _password)
        {
            bool[] validation = new bool[2];
            if (_username == username)
                validation[0] = true;
            else
                validation[0] = false;
            if (_password == password)
                validation[1] = true;
            else
                validation[1] = false;
            return validation;
        }
    }
}
