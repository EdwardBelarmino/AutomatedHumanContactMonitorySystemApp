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
    public class AttendanceRepository : IAttendanceRepository
    {
        public List<Attendance> GetAttendances()
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/attendance/get");
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendances = JsonConvert.DeserializeObject<List<Attendance>>(response.Content);
            return attendances.ToList();
        }



    }
}
