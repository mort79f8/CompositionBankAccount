using System;
using System.Collections.Generic;
using System.Text;

namespace CompositionBankAccount.Entities
{
    public class Customer
    {
        #region Fields
        private int id;
        private List<Account> accounts;
        #endregion

        #region Property
        public int Id { get => id; set => id = value; }
        public List<Account> Accounts
        {
            get
            {
                return accounts;
            }
            set
            {
                if (value is null)
                {
                    accounts = new List<Account>();
                }
                else
                {
                    accounts = value;
                }
            }
        }
        public int Rating {
            get
            {
                return 0;
            }
        }

        #endregion

        #region Constuctors
        public Customer(int id, List<Account> accounts)
        {
            Id = id;
            Accounts = accounts;
        }

        public Customer(List<Account> accounts)
        {
            Accounts = accounts;
        }

        public Customer()
        {

        }
        #endregion

        #region Methodes
        public decimal GetDebts()
        {
            decimal debt = 0;
            foreach (var account in accounts)
            {
                debt += account.Balance;
            }

            if (debt >= 0)
            {
                return 0;
            }


            return debt;
        }

        public decimal GetAssets()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalBalance()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
