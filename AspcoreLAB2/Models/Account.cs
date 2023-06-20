﻿using System.ComponentModel.DataAnnotations;

namespace AspcoreLAB2.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
