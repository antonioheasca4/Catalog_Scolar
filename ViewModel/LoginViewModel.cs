﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Input;

namespace Catalog_Scolar_Online.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public string Username 
        {
            get { return _username; }
            set 
            { _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        //Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p=>ExecuteRecoverPasswordCommand("",""));
        }

        private void ExecuteRecoverPasswordCommand(string username,string email)
        {
            throw new NotImplementedException();
        }

        private void ExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrEmpty(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData= true;
            }
            return validData;
        }
    }
}
