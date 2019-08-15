using System;
using Xunit;
using CompositionBankAccount.Entities;
using System.Collections.Generic;

namespace CompositionBankAccount.EntitiesTest
{
    public class CustomerTests
    {
        [Fact]
        public void GetDebts_TrueIfNumberIsNegativeAndWithinLimits()
        {
            //Arrange
            Customer customer = new Customer();
            Account account = new Account(-20_000);
            List<Account> accounts = new List<Account>();
            accounts.Add(account);
            customer.Accounts = accounts;

            //Act
            decimal debt = customer.GetDebts();

            //assert
            Assert.True(debt < 0 && debt > -999_999_999);
        }

        [Fact]
        public void GetAssets_TrueIfNumberIsZeroOrAboveAndWithinLimits()
        {
            //Arrange
            Customer customer = new Customer();
            Account account = new Account(100_000);
            customer.Accounts.Add(account);

            //Act
            decimal asserts = customer.GetAssets();

            //Assert
            Assert.True(asserts >= 0 && asserts < 999_999_999);
        }

        [Fact]
        public void GetTotalBalance_TrueIfTotalIsEqualToDebtPlusAsserts()
        {
            //Arrange
            Customer customer = new Customer();
            Account account1 = new Account(20_000);
            Account account2 = new Account(-1_000);
            customer.Accounts.Add(account1);
            customer.Accounts.Add(account2);

            //Act
            decimal debt = customer.GetDebts();
            decimal asserts = customer.GetAssets();
            decimal total = debt + asserts;

            //Assert
            Assert.Equal(customer.GetTotalBalance(), total);
        }

        [Fact]
        public void RatingOne_TruIfDebtAndAssertIsWithLimits()
        {
            //Arrange
            Customer customer = new Customer();
            Account account1 = new Account(1_300_000);
            Account account2 = new Account(-2_500_999);
            customer.Accounts.Add(account1);
            customer.Accounts.Add(account2);

            //Act
            int rating = customer.Rating;

            //Arrange
            Assert.Equal(1, rating);
        }

        [Fact]
        public void RatingTwo_TruIfDebtAndAssertIsWithLimits()
        {
            //Arrange
            Customer customer = new Customer();
            Account account1 = new Account(1_100_000);
            Account account2 = new Account(-2_500_999);
            customer.Accounts.Add(account1);
            customer.Accounts.Add(account2);

            //Act
            int rating = customer.Rating;

            //Arrange
            Assert.Equal(2, rating);
        }

        [Fact]
        public void RatingThree_TruIfDebtAndAssertIsWithLimits()
        {
            //Arrange
            Customer customer = new Customer();
            Account account1 = new Account(300_000);
            Account account2 = new Account(-2_400_000);
            customer.Accounts.Add(account1);
            customer.Accounts.Add(account2);

            //Act
            int rating = customer.Rating;

            //Arrange
            Assert.Equal(3, rating);
        }

        [Fact]
        public void RatingFour_TruIfDebtAndAssertIsWithLimits()
        {
            //Arrange
            Customer customer = new Customer();
            Account account1 = new Account(40_000);
            Account account2 = new Account(-30_000);
            customer.Accounts.Add(account1);
            customer.Accounts.Add(account2);

            //Act
            int rating = customer.Rating;

            //Arrange
            Assert.Equal(4, rating);
        }

        [Fact]
        public void RatingFive_TruIfDebtAndAssertIsWithLimits()
        {
            //Arrange
            Customer customer = new Customer();
            Account account1 = new Account(48_000);
            Account account2 = new Account(-150_000);
            customer.Accounts.Add(account1);
            customer.Accounts.Add(account2);

            //Act
            int rating = customer.Rating;

            //Arrange
            Assert.Equal(5, rating);
        }


    }
}
