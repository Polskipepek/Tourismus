﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Tourismus.Model.Models
{
    public partial class UserCredential
    {
        public int Id { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}