﻿using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.IRepositories
{
    public interface IAttendanceRepository
    {
        List<AttendanceDto> GetAttendances();
        void PostAttendance(AttendanceDto attendanceDto);
        void DeleteAttendance(int id);
    }
}