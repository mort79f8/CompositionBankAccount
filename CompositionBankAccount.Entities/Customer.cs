using EncapsulationBankAccount.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompositionBankAccount.Entities
{
    class Customer
    {
        #region Fields
        private int id;
        private List<Account> accounts;
        #endregion

        public int Id { get; set; }
        public List<Account> Accounts { get; set; }
        public int Rating { get; }

        public Customer(int id, List<Account> accounts)
        {
            throw new NotImplementedException();
        }

        public Customer(List<Account> accounts)
        {
            throw new NotImplementedException();
        }

        public decimal GetDebts()
        {
            throw new NotImplementedException();
        }

        public decimal GetAssets()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalBalance()
        {
            throw new NotImplementedException();
        }

    }
}
