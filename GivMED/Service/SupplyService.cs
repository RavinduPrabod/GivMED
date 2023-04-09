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
            }
            return webApiResponse;
        }

        public List<SupplyRequestHeader> GetSupplyNeedHeaderlist()
        {
            try
            {
                List<SupplyRequestHeader> record = new List<SupplyRequestHeader>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Supply/GetSupplyNeedHeaderlist";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<SupplyRequestHeader>>(value);
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
    }
}