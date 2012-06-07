namespace DemoAgenda.Models
{
    public class UserInfo: IUserInfo
    {
        public const int NEW_OBJECT_ID = -1;

        private string _firstName;
        private string _surname;
        private string _login;
        private string _password;
        private bool _isNew;
        private int _id;

        public UserInfo(string firstName, string surname, string login, string password)
        {
            _firstName = firstName;
            _surname = surname;
            _login = login;
            _password = password;
            _isNew = true;
            _id = NEW_OBJECT_ID;
        }

        public bool IsNew 
        { 
            get { return _isNew; }
            set { _isNew = value;  }
        }
        public int ID 
        { 
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        
        public string Surname 
        { 
            get { return _surname; }
            set { _surname = value; }
        }

        public string Login 
        { 
            get { return _login; }
            set { _login = value; }
        }

        public string Password 
        { 
            get { return _password; }
            set { _password = value; }
        }

        public bool Validate() { return true; }


    }
}
