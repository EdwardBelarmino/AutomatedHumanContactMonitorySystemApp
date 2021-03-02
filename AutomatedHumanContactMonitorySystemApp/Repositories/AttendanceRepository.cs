using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
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
        public List<AttendanceDto> GetAttendances()
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/attendance/get");
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendances = JsonConvert.DeserializeObject<List<AttendanceDto>>(response.Content);
            return attendances.ToList();
        }

        public void PostAttendance(AttendanceDto attendanceDto)
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/attendance/post", Method.POST);
            request.AddJsonBody(attendanceDto);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }



    }
}
