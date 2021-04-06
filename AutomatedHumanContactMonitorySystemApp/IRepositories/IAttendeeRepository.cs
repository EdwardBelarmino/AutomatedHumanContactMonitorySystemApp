using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.SearchDtos;

namespace AutomatedHumanContactMonitorySystemApp.IRepositories
{
    public interface IAttendeeRepository
    {
        List<Attendee> GetAttendees();
        Attendee GetAttendee(int id);
        void PostAttendee(Attendee attendee);
        void DeleteAttendee(int id);
        void PutAttendee(Attendee attendee);
        List<Attendee> GetAttendeeBySearchParameter(SearchDto searchParameter);
    }
}
