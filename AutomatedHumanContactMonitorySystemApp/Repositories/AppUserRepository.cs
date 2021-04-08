using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        public bool IsAuthorized(AppUser appUserLogin)
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/login/authorize", Method.POST);
            request.AddJsonBody(appUserLogin);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var isAuthorized = JsonConvert.DeserializeObject<bool>(response.Content);
            return isAuthorized;
        }
    }
}
