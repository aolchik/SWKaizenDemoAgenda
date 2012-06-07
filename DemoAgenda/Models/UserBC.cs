namespace DemoAgenda.Models
{
    public class UserBC
    {
        private IUserDao _daoUser;

        public UserBC()
        {
            _daoUser = new UserDao();
        }

        public UserBC(IUserDao daoUser)
        {
            _daoUser = daoUser;
        }

        public void SaveUser(IUserInfo user)
        {
            user.Validate();

            if (user.IsNew)
                _daoUser.Insert(user);
            else
                _daoUser.Update(user);
        }

    }
}

  