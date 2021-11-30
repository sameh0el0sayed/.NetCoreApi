using System;
using System.Collections.Generic;

namespace DotNetCoreApi.Models
{
    public partial class User
    {
       
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Username { get; set; }  
        public string? Password { get; set; }
        public int Role { get; set; } = 1;
    }
}
