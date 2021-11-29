using System;
using System.Collections.Generic;

namespace DotNetCoreApi.Models
{
    public partial class User
    {
       
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }
    }
}
