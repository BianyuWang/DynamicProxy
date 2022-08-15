using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy.Interfaces
{
    public interface IBankAccount
    {
        void Desposit(int amount);
        bool Withdraw(int amount);

        string ToString();
    }
}
