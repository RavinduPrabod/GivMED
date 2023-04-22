using GivMED.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text;
using GivMED.Models;
using GivMED.Dto;

namespace GivMED.Service
{
    public class RegistrationService
    {
        public bool CheckHospitalMasterAvailability(string UserName)
        {
            bool result = false;
            using (HttpClient client = new HttpClient())
            {
                string path = "Registration/CheckHospitalMasterAvailability/" + UserName;
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(value);
                }
            }
            return result;
        }

        public bool CheckDonorMasterAvailability(string UserName)
        {
            bool result = false;
            using (HttpClient client = new HttpClient())
            {
                string path = "Registration/CheckDonorMasterAvailability/" + UserName;
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(value);
                }
            }
            return result;
        }

        public WebApiResponse PostHospital(HospitalMaster oData)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Registration/PostHospital";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);
            }
            return webApiResponse;
        }

        public WebApiResponse CreateUser(UserDto oUserForRegisterDto)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "User/PostUser";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oUserForRegisterDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Extract the NewDonationID from the response content
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    webApiResponse.Result = responseContent; // Set the NewDonationID as the response data
                }
            }
            return webApiResponse;
        }
    }
}