

using DynamicProxy.DynamicLog;
using DynamicProxy.Interfaces;
using DynamicProxy.Models;
    
    // See https://aka.ms/new-console-template for more information


Console.WriteLine("dynamic proxy bank account example!");

//var bankAccount = new BankAccount();
var bankAccount = Log<BankAccount>.As<IBankAccount>();
bankAccount.Desposit(100);
bankAccount.Desposit(100);
bankAccount.Desposit(100);
bankAccount.Withdraw(50);
bankAccount.Desposit(100);

bankAccount.Withdraw(50);

Console.WriteLine(bankAccount.ToString());

Console.ReadKey();
