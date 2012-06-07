using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoAgenda.Models
{
    public interface IUserInfo
    {
        bool IsNew { get; set; }
        int ID { get; set; }
        bool Validate();
        string FirstName { get; set; }
        string Surname { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}
