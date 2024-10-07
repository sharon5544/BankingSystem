using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject
{
    /// <summary>
    /// Represents a repository for managing accounts.
    /// </summary>
    public interface IAccountRepo
    {
        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="account">The account to create.</param>

        void Create(AccountModel account);

        /// <summary>
        /// Updates an existing account.
        /// </summary>
        /// <param name="account">The account to update.</param>
        void UpdateAccount(AccountModel account);

        /// <summary>
        /// Deletes an account.
        /// </summary>
        /// <param name="acNo">The account number of the account to delete.</param>
        /// <param name="account">The account to delete.</param>

        void DeleteAccount(int acNo, AccountModel account);

        /// <summary>
        /// Deposits money into an account.
        /// </summary>
        /// <param name="acNo">The account number of the account to deposit into.</param>
        /// <param name="Amount">The amount to deposit.</param>
        void Deposit(int acNo, int Amount);

        /// <summary>
        /// Withdraws money from an account.
        /// </summary>
        /// <param name="acNo">The account number of the account to withdraw from.</param>
        /// <param name="Amount">The amount to withdraw.</param>
        void Withdrw(int acNo, int Amount);

        /// <summary>
        /// Calculates the interest and updates the balance for all accounts.
        /// </summary>
        void CalculateInterestAndUpdateBalance();

        /// <summary>
        /// Retrieves all accounts.
        /// </summary>
        /// <returns>A collection of all accounts.</returns>
        ObservableCollection<AccountModel> ReadAllAccount();


    }
}
