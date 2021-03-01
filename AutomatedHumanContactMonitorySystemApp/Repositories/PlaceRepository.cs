﻿using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        public List<Place> GetPlaces()
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/place/get");
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var places = JsonConvert.DeserializeObject<List<Place>>(response.Content);
            return places.ToList();
        }

        public void PostPlace(Place place)
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/place/post", Method.POST);
            request.AddJsonBody(place);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        public void DeletePlace(int id)
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/place/delete/" + id, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        public void PutPlace(Place place)
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/place/put/" + place.Id, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(place);
            var response = client.Execute(request);
        }


    }
}
