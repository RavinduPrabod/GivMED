using GivMED.Common;
using GivMED.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace GivMED.Service
{
    public class VolunteerService
    {
        public WebApiResponse PostVolunteerMaster(VolunteerMaster oData)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Volunteer/PostVolunteerMaster";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);
            }
            return webApiResponse;
        }

        public List<VolunteerMaster> GetVolunteerMaster(int HospitalID)
        {
            try
            {
                List<VolunteerMaster> record = new List<VolunteerMaster>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Volunteer/GetVolunteerMaster/" + HospitalID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<VolunteerMaster>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VolunteerMaster GetVolunteerMasterbyID(string VolCode)
        {
            try
            {
                VolunteerMaster record = new VolunteerMaster();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Volunteer/GetVolunteerMasterbyID/" + VolCode;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<VolunteerMaster>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WebApiResponse PutVolunteerMaster(VolunteerMaster oData)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Volunteer/PutVolunteerMaster";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);
            }
            return webApiResponse;
        }

        public WebApiResponse DeleteVolunteerMasterbyID(VolunteerMaster VolID)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Volunteer/DeleteVolunteerMasterbyID";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(VolID);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.DeleteAsync(path).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);
            }
            return webApiResponse;
        }
    }
}