namespace DemoAgenda.Models
{
    public class UserDao: IUserDao
    {
        static private IUserInfo _lastInserted;

        public UserDao() { _lastInserted = null; }

        public void Insert(IUserInfo user) 
        {
            _lastInserted = user;
            user.IsNew = false;
            user.ID += 1;
        }
        public void Update(IUserInfo user) {}

        public IUserInfo LastInserted
        {
            get { return _lastInserted; }
        }

        static public bool IsUserInsertedInDatabase(string name, string surname, string login, string password)
        {
            if( (name == _lastInserted.FirstName) && 
                (surname == _lastInserted.Surname) &&
                (login == _lastInserted.Login) &&
                (password == _lastInserted.Password))
                return true;
            return false;
        }


    }
}
