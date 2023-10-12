using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.UserViewModels
{
    public class BaseUserViewModel
    {
        public string Name { get; set;}
        public string Email { get; set;}
        public int PhoneNumber { get; set;}
        public string Role { get; set;}
        public string Status { get; set;}
    }
}
