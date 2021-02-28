using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AutomatedHumanContactMonitorySystemApp.IRepositories
{
    public interface IAttendeeRepository
    {
        List<Attendee> GetAttendees();
        Attendee GetAttendee(int id);
    }
}
