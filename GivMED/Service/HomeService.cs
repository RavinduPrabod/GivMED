using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GivMED.Service
{
    public class HomeService
    {
        public List<TopTrendingDonorDto> GetTopRateDonors()
        {
            try
            {
                List<TopTrendingDonorDto> record = new List<TopTrendingDonorDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Home/GetTopRateDonors";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<TopTrendingDonorDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TopTrendingDonorDto> GetTopTrendingDonations()
        {
            try
            {
                List<TopTrendingDonorDto> record = new List<TopTrendingDonorDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Home/GetTopTrendingDonations";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<TopTrendingDonorDto>>(value);
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