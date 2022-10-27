using Inspecoes.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspecoes.DTOs
{
    public class User
    {
        protected User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        private string _userName;
        public string UserName { 
            get {
                if(Deleted && _userName.Contains("__"))
                    return _userName.Split("__")[1];
                return _userName;
            }
            set {
                _userName = value;
            }
        }
        public string Name { get; set; }
        private string _email;
        public string Email
        {
            get
            {
                if (Deleted && _email.Contains("__"))
                    return _email.Split("__")[1];
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public UserProfile Profile { get; set; }
        public string ProfileId { get; set; }
    //    public List<Permission> Permissions { get; set; }
    }

    public class UpdateUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //public UserProfile Profile { get; set; }
        public string ProfileId { get; set; }
   //     public List<Permission> Permissions { get; set; }
    }


}
