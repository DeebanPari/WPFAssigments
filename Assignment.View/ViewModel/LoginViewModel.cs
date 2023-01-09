using Assignment.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Assignment.View.Repositories;
using System.Net;
using System.Security.Principal;
using System.Threading;
using Assignment.View.View;

namespace Assignment.View.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        //Fields

        private string _userName;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible =true;

        private IUserRepository userRepository;

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set

            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand RegCommand { get; }

        //Constructor
        public LoginViewModel()

        {
            userRepository=new UserRepository();
            LoginCommand = new ViweModelCommand(ExecuteLoginCommand, canExecuteLoginCommand);
            RecoverPasswordCommand = new ViweModelCommand(p=>ExecuteRecoverPassCommand(" ", " "));
            RegCommand = new ViweModelCommand(ExecuteRegCommand);
        }

        private void ExecuteRegCommand(object obj)
        {
            LoginView log = new LoginView();
            log.Close();
            Registration reg = new Registration();
            reg.Show();
        }

        private bool canExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }
        private void   ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(UserName,Password));
            if(isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(UserName),null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid UserName or Password";
            }
        }
        private bool ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
