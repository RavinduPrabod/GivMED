using GivMED.Common;
using GivMED.Dto;
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
    public class SupplyService
    {
        public List<ComboDTO> GetItemCat()
        {
            try
            {
                List<ComboDTO> record = new List<ComboDTO>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetItemCat";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<ComboDTO>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ItemMaster> GetAllItem()
        {
            try
            {
                List<ItemMaster> record = new List<ItemMaster>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetAllItem";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<ItemMaster>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WebApiResponse PostSupplyNeed(SupplyNeedsDto oData)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/PostSupplyNeed";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    webApiResponse.Result = responseContent;
                }
            }
            return webApiResponse;
        }


        public WebApiResponse PostDonation(PublishedNeedsPostDto oData)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/PostDonation";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    // Extract the NewDonationID from the response content
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    webApiResponse.Result = responseContent; // Set the NewDonationID as the response data
                }
            }
            return webApiResponse;
        }

        public WebApiResponse PostTemplate(ManageTemplate oData)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/PostTemplate";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    // Extract the NewDonationID from the response content
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    webApiResponse.Result = responseContent; // Set the NewDonationID as the response data
                }
            }
            return webApiResponse;
        }


        public List<HospitalSupplyNeedsGridDto> GetSupplyNeedHeaderlist(int HospitalID)
        {
            try
            {
                List<HospitalSupplyNeedsGridDto> record = new List<HospitalSupplyNeedsGridDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetSupplyNeedHeaderlist/" + HospitalID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<HospitalSupplyNeedsGridDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<HospitalSupplyNeedsGridDto> GetSupplyNeedHeaderlist2(int HospitalID)
        {
            try
            {
                List<HospitalSupplyNeedsGridDto> record = new List<HospitalSupplyNeedsGridDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetSupplyNeedHeaderlist2/" + HospitalID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<HospitalSupplyNeedsGridDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PublishedNeedsGridDto> GetSupplyNeedHeaderWithDetails()
        {
            try
            {
                List<PublishedNeedsGridDto> record = new List<PublishedNeedsGridDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetSupplyNeedHeaderWithDetails";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<PublishedNeedsGridDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SupplyNeedsDto GetSupplyNeedsForID(string SupplyID)
        {
            try
            {
                SupplyNeedsDto record = new SupplyNeedsDto();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetSupplyNeedsForID/" + SupplyID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<SupplyNeedsDto>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public HospitalMaster GetHospitalMasterForID(int HospitalID)
        {
            try
            {
                HospitalMaster record = new HospitalMaster();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetHospitalMasterForID/" + HospitalID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<HospitalMaster>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DonationFeedback GetFeedBackForID(string DonationID)
        {
            try
            {
                DonationFeedback record = new DonationFeedback();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetFeedBackForID/" + DonationID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<DonationFeedback>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SupplyNeedGridDto> GetSupplyNeedGridForID(string SupplyID)
        {
            try
            {
                List<SupplyNeedGridDto> record = new List<SupplyNeedGridDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetSupplyNeedGridForID/" + SupplyID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<SupplyNeedGridDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SupplyNeedGridDto> GetDonationNeedGridForID(string DonationID)
        {
            try
            {
                List<SupplyNeedGridDto> record = new List<SupplyNeedGridDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetDonationNeedGridForID/" + DonationID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<SupplyNeedGridDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WebApiResponse UseChatGPT(string query)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/UseChatGPT";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(query);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    // Extract the NewDonationID from the response content
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    webApiResponse.Result = responseContent; // Set the NewDonationID as the response data
                }
            }
            return webApiResponse;
        }

       

        public WebApiResponse UseChatGPTFeedBack(string query)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/UseChatGPTFeedBack";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(query);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    // Extract the NewDonationID from the response content
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    webApiResponse.Result = responseContent; // Set the NewDonationID as the response data
                }
            }
            return webApiResponse;
        }


        //donation
        public List<DonationActivityDto> GetDonationHeaderDetails(string username)
        {
            try
            {
                List<DonationActivityDto> record = new List<DonationActivityDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetDonationHeaderDetails/" + username;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<DonationActivityDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ArchivementsDto> GetArchivementsData(string username)
        {
            try
            {
                List<ArchivementsDto> record = new List<ArchivementsDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetArchivementsData/" + username;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<ArchivementsDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HospitalSupplyNeedsGridDto> GetDonationContributeGridData(int HospitalID)
        {
            try
            {
                List<HospitalSupplyNeedsGridDto> record = new List<HospitalSupplyNeedsGridDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetDonationContributeGridData/" + HospitalID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<HospitalSupplyNeedsGridDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DonationContributeGridDto> GetDonorsForID(string SupplyID)
        {
            try
            {
                List<DonationContributeGridDto> record = new List<DonationContributeGridDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetDonorsForID/" + SupplyID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<DonationContributeGridDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WebApiResponse PostFeedBack(DonationFeedback oData)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/PostFeedBack";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    // Extract the NewDonationID from the response content
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    webApiResponse.Result = responseContent; // Set the NewDonationID as the response data
                }
            }
            return webApiResponse;
        }

        public List<DonationReviewFeedbackDto> GetFeedBackForSupplyID(string SupplyID)
        {
            try
            {
                List<DonationReviewFeedbackDto> record = new List<DonationReviewFeedbackDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetFeedBackForSupplyID/" + SupplyID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<DonationReviewFeedbackDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WebApiResponse Delete(DonationActivityDto VolID)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/Delete";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(VolID);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    // Extract the NewDonationID from the response content
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    webApiResponse.Result = responseContent; // Set the NewDonationID as the response data
                }
            }
            return webApiResponse;
        }

        public WebApiResponse PutDonationupdate(DeliveryDataDto oData)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/PutDonationupdate";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                var json = JsonConvert.SerializeObject(oData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(path, content).Result;
                webApiResponse.StatusCode = Convert.ToInt32(response.StatusCode);
            }
            return webApiResponse;
        }

    }
}