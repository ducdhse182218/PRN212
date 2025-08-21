﻿using System;
using System.Collections.Generic;

namespace PlantNurseryManagement.DAL.Entities;

public partial class SystemUser
{
    public int UserId { get; set; }

    public string UserPassword { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public int? UserRole { get; set; }

    public DateTime? RegistrationDate { get; set; }
}
