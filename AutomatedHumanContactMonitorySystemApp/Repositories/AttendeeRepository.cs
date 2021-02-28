using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        public List<Attendee> GetAttendees()
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/attendee/get");
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendees = JsonConvert.DeserializeObject<List<Attendee>>(response.Content);
            return attendees.ToList();
        }

        public Attendee GetAttendee(int id) 
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/attendee/get"+id);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendee = JsonConvert.DeserializeObject<Attendee>(response.Content);
            return attendee;
        }

        public void PostAttendee(Attendee attendee) 
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/attendee/post", Method.POST);
            request.AddJsonBody(attendee);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        public void DeleteAttendee(int id)
        { 
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/attendee/delete/" + id, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

        }



    }

}
