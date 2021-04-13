using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
using AutomatedHumanContactMonitorySystemApp.Properties;
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
        private readonly string ApiAddress = Settings.Default.ApiAddress;
        public List<AttendanceDto> GetAttendances()
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/get");
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendances = JsonConvert.DeserializeObject<List<AttendanceDto>>(response.Content);
            return attendances.ToList();
        }

        public void PostAttendance(AttendanceDto attendanceDto)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/post", Method.POST);
            request.AddJsonBody(attendanceDto);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        public void DeleteAttendance(int id)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/delete/" + id, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        public void PutAttendance(AttendanceDto attendanceDto)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/put/" + attendanceDto.Id, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(attendanceDto);
            var response = client.Execute(request);
        }

        public List<AttendanceDto> GetAttendanceBySearchParameter(SearchDto searchDto)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/GetAttendanceBySearchParameter", Method.POST);
            request.AddJsonBody(searchDto);
            var response = client.Execute(request);
            var attendances = JsonConvert.DeserializeObject<List<AttendanceDto>>(response.Content);
            return attendances.ToList();
        }


    }
}
