﻿namespace CustoMate.entity
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }   

        public string LastName { get; set; } 
        public DateTime CreatedDate { get; set; } 

        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
