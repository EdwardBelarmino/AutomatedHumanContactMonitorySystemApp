﻿using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.IRepositories
{
    public interface IPlaceRepository
    {
        List<Place> GetPlaces();


    }
}
