using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Security.Principal;
using System.Security.RightsManagement;
using System.Globalization;
using System.Windows.Data;
using log4net.Repository.Hierarchy;

namespace BankingProject
{
    public delegate void DWidnowClose();

    // <summary>
    /// Represents a view model for managing accounts.
    /// </summary>
    public class AccountViewModel : INotifyPropertyChanged
    {
        public DWidnowClose NewWindowClose;
        public DWidnowClose EditWindowClose;


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        /// <summary>
        /// Gets or sets the new account.
        /// </summary>


        private AccountModel _newAccount = null;

        public AccountModel NewAccount
        {
            get { return _newAccount; }
            set
            {
                _newAccount = value;
                OnPropertyChanged(nameof(NewAccount));
            }
        }

        /// <summary>
        /// Gets or sets the selected account.
        /// </summary>

        private AccountModel _selectedAccount = null;
        public AccountModel SelectedAccount
        {
            get => _selectedAccount;
            set { _selectedAccount = value; OnPropertyChanged(nameof(SelectedAccount)); }
        }

        /// <summary>
        /// Gets the accounts repository.
        /// </summary>

        private IAccountRepo _repo =  AccountMemoryRepo.Instance;

        // <summary>
        /// Gets the collection of accounts.
        /// </summary>  
        public ObservableCollection<AccountModel> Accounts
        {
            get
            {
                try
                {
                    return _repo.ReadAllAccount();
                }
                catch (AccountException ae)
                {
                    Logger.log.Error(ae.Message);
                    throw;
                }

            }
        }

        /// <summary>
        /// Gets the command for creating a new account.
        /// </summary>
        public ICommand CreateCommand { get; }

        /// <summary>
        /// Gets the command for updating an existing account.
        /// </summary>
        public ICommand UpdateCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountViewModel"/> class.
        /// </summary>
        public AccountViewModel()
        {
            this.NewAccount = new AccountModel
            {
                AccNo = 00000,
                Name = "",
                Balance = 0,
                AccType = "",
                Email = "",
                PhoneNumber = "",
                Address = "",
                IsActive = false,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,


            };
            CreateCommand = new RelayCommand(Create);
            UpdateCommand = new RelayCommand(Update);
        }

        /// <summary>
        /// Creates a new account.
        /// </summary>

        public void Create()
        {
            AccountModel newAccount = new AccountModel
            {
                AccNo = NewAccount.AccNo,
                Name = NewAccount.Name,
                Balance = NewAccount.Balance,
                AccType = NewAccount.AccType,
                Email = NewAccount.Email,
                PhoneNumber = NewAccount.PhoneNumber,
                Address = NewAccount.Address,
                IsActive = NewAccount.IsActive,
                InterestPercentage = NewAccount.InterestPercentage,
                TransactionCount = NewAccount.TransactionCount,
                LastTransactionDate = NewAccount.LastTransactionDate,
            };
            var result = MessageBox.Show(messageBoxText: "Are you sure to create?",
                    caption: "Confirm",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                _repo.Create(newAccount);

                result = MessageBox.Show(messageBoxText: "Created Successfully",
                        caption: "Alert",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Information);
                Logger.log.Info($"An account with acoount number {newAccount.AccNo} has been created successfully");


                this.NewAccount = new AccountModel { AccNo = 0, Name = "", Balance = 0, AccType = "", Email = "", PhoneNumber = "", Address = "", IsActive = false, InterestPercentage = "0", TransactionCount = 0, LastTransactionDate = DateTime.Now };
            }
            catch (AccountException ae)
            {
                Logger.log.Error(ae.Message);
            }

            if (NewWindowClose != null)
            {
                NewWindowClose();
            }

        }

        /// <summary>
        /// Updates an existing account.
        /// </summary>

        public void Update()
        {
            if (this.SelectedAccount == null)
            {
                return ;
            }

            try
            {

                _repo.UpdateAccount(this.SelectedAccount);
                this.SelectedAccount = this.SelectedAccount;
                var result = MessageBox.Show(messageBoxText: $"Account {SelectedAccount.AccNo} is updated successfully",
                        caption: "Alert",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Information);
                Logger.log.Info($"Account {SelectedAccount.AccNo} is updated successfully");
            }
            catch (AccountException ae)
            {
                Logger.log.Error(ae.Message);
            }


            if (EditWindowClose != null)
            {
                EditWindowClose();
            }
            //        _repo.UpdateAccount(this.SelectedAccount);
            //         this.SelectedAccount = this.SelectedAccount;
            //        var result = MessageBox.Show(messageBoxText: "Updated Successfully",
            //        caption: "Alert",
            //        button: MessageBoxButton.OK,
            //        icon: MessageBoxImage.Information);


            //    if (EditWindowClose != null)
            //{
            //    EditWindowClose();
            //}



        }

    }
}
