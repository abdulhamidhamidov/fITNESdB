﻿using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Dtos.TrainerDtos;

public class CreateTrainerDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Experience { get; set; }
    public TrainerStatus Status { get; set; }
    public string Specialization { get; set; }
}