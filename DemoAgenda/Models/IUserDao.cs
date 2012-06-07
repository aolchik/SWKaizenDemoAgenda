using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAgenda.Models
{
    public interface IUserDao
    {
        void Insert(IUserInfo user);
        void Update(IUserInfo user);
        IUserInfo LastInserted { get;  }
    }
}
