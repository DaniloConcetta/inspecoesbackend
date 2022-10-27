using Inspecoes.Models;
using System.Collections.Generic;

namespace Inspecoes.DTOs
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        //public string NormalizedName { get; set; }
   //     public List<Permission> Permissions { get; set; }
    }
}
