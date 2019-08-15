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
                if (GetDebts() < -2_500_000 && GetAssets() > 1_250_000)
                {
                    return 1;
                }
                else if (GetDebts() < -2_500_000 && (GetAssets() >= 50_000 && GetAssets() <= 1_250_000))
                {
                    return 2;
                }
                else if ((GetDebts() <= -250_000 && GetDebts() >= -2_500_000) && (GetAssets() >= 50_000 && GetAssets() <= 1_250_000))
                {
                    return 3;
                }
                else if ((GetDebts() < 0 && GetDebts() > -250_000) && (GetAssets() > 0 && GetAssets() <= 50_000) && (GetDebts() * -1) < GetAssets())
                {
                    return 4;
                }
                else if (((GetDebts() < 0 && GetDebts() > -250_000) && (GetAssets() > 0 && GetAssets() <= 50_000)))
                {
                    return 5;
                }
                else
                {
                    return 6;
                }
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
            Accounts = new List<Account>();
        }
        #endregion

        #region Methodes
        public decimal GetDebts()
        {
            decimal debt = 0;
            foreach (var account in accounts)
            {
                if (account.Balance < 0)
                {
                    debt += account.Balance;
                }
            }

            return debt;
        }

        public decimal GetAssets()
        {
            decimal asserts = 0;
            foreach (var account in accounts)
            {
                if (account.Balance >= 0)
                {
                    asserts += account.Balance;
                }
                
            }
                       
            return asserts;
        }

        public decimal GetTotalBalance()
        {
            decimal total = 0;
            foreach (var account in accounts)
            {
                total += account.Balance;
            }

            return total;
        }
        #endregion
    }
}
