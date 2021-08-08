using SampleApp.MVVMLight.Helpers;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.ViewModels
{
    public class FormValidationPageModel : BaseViewModel
    {
        private User _user;

        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }


        private bool errorMessageVisiliby;

        public bool ErrorMessageVisiliby
        {
            get
            {
                return errorMessageVisiliby;
            }
            set
            {
                errorMessageVisiliby = value;
                OnPropertyChanged();
            }
        }

        public ICommand OnValidationCommand { get; set; }
        public FormValidationPageModel()
        {
            User = new User();

            OnValidationCommand = new Command((obj) =>
            {
                User.FirstName.NotValidMessageError = "Name is required";
                User.FirstName.IsNotValid = string.IsNullOrEmpty(User.FirstName.Name);

                User.Email.NotValidMessageError = "Email is required";
                User.Email.IsNotValid = string.IsNullOrEmpty(User.Email.Name);


                if (string.IsNullOrEmpty(User.Password.Name))
                {
                    User.Password.NotValidMessageError = "Password is required";
                    User.Password.IsNotValid = true;
                }
                else if (User.Password.Name.Length < 5)
                {
                    User.Password.NotValidMessageError = "Password must have more than 5 charcteres";
                    User.Password.IsNotValid = true;
                }
                else
                {
                    User.Password.IsNotValid = false;
                }

                OnPropertyChanged();

            });
        }

    }

    public class User : INotifyPropertyChanged
    {
        public Field FirstName { get; set; } = new Field();
        public Field Email { get; set; } = new Field();
        public Field Password { get; set; } = new Field();

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Field : BaseViewModel
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }


        private bool isNotValid;

        public bool IsNotValid
        {
            get
            {
                return isNotValid;
            }
            set
            {
                isNotValid = value;
                OnPropertyChanged();
            }
        }

        private string notValidMessageError;

        public string NotValidMessageError
        {
            get
            {
                return notValidMessageError;
            }
            set
            {
                notValidMessageError = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
