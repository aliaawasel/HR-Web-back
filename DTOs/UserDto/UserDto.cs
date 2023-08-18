﻿using System.ComponentModel.DataAnnotations;

namespace HR_System.DTOs.UserDto
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int GroupID { get; set; }
    }
}
