using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Task
{
    internal class User
    {
        #region Properites 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }

        #endregion

        #region Constructors
        public User(string _PhoneNumber)
        {
            PhoneNumber = _PhoneNumber;
        }
        public User(string _Name, string _Email, string _Phone) : this(_Phone)
        {
            Name = _Name;
            Email = _Email;
        }
        #endregion

        public override string ToString() => $"Name: {Name}, Email: {Email}, Phone: {PhoneNumber}";
    }
}
