using DynamicProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy.Models
{
    public class BankAccount : IBankAccount
    {
        private int balance { get; set; }
        private int overdraftlimite = -500;
        public void Desposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount},balance is now {balance}");
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftlimite)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw {amount},balance is now {balance}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}:{balance},{balance}";
        }
    }
}
