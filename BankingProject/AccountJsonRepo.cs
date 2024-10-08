using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace BankingProject
{
    public class AccountJsonRepo : IAccountRepo
    {
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "accounts.json");
        private ObservableCollection<AccountModel> accounts;

        public AccountJsonRepo()
        {
            LoadAccountsFromJson();
        }

        private void LoadAccountsFromJson()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    var json = File.ReadAllText(_filePath);
                    accounts = JsonConvert.DeserializeObject<ObservableCollection<AccountModel>>(json);
                }
                else
                {
                    accounts = new ObservableCollection<AccountModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveAccountsToJson()
        {
            try
            {
                var json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(AccountModel account)
        {
            try
            {
                accounts.Add(account);
                SaveAccountsToJson();
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error in creating account");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAccount(AccountModel account)
        {
            try
            {
                var existingAccount = accounts.FirstOrDefault(a => a.AccNo == account.AccNo);
                if (existingAccount != null)
                {
                    existingAccount.Address = account.Address;
                    SaveAccountsToJson();
                }
                else
                {
                    throw new AccountException("Account doesn't exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<AccountModel> ReadAllAccount()
        {
            try
            {
                return accounts;
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error reading accounts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAccount(int acNo, AccountModel account)
        {
            try
            {
                var existingAccount = accounts.FirstOrDefault(a => a.AccNo == acNo);
                if (existingAccount != null)
                {
                    accounts.Remove(existingAccount);
                    SaveAccountsToJson();
                }
                else
                {
                    throw new AccountException("Account doesn't exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deposit(int acNo, int Amount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.AccNo == acNo);
                if (account != null)
                {
                    account.Balance = account.Balance + Amount;
                    account.LastTransactionDate = DateTime.Now;
                    account.TransactionCount = account.TransactionCount + 1;
                    SaveAccountsToJson();
                }
                else
                {
                    throw new AccountException("Account Not Found , Please input valid account number");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Withdrw(int acNo, int Amount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.AccNo == acNo);
                if (account != null)
                {
                    if (account.Balance < Amount)
                    {
                        throw new AccountException("Insufficient balance");
                    }
                    account.Balance = account.Balance - Amount;
                    account.LastTransactionDate = DateTime.Now;
                    account.TransactionCount = account.TransactionCount + 1;
                    SaveAccountsToJson();
                }
                else
                {
                    throw new AccountException("Account Not Found , Please input valid account number");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static AccountJsonRepo _instance;
        public static AccountJsonRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountJsonRepo();
                }
                return _instance;
            }
        }

        public void CalculateInterestAndUpdateBalance()
        {
            throw new NotImplementedException();
        }
    }
}