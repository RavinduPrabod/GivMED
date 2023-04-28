﻿using GivMED.Common;
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

        public HomeDashLineDto GetHomeDashTopLineData()
        {
            try
            {
                HomeDashLineDto record = new HomeDashLineDto();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Home/GetHomeDashTopLineData";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<HomeDashLineDto>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DonationViewDto> GetDonationView()
        {
            try
            {
                List<DonationViewDto> record = new List<DonationViewDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Home/GetDonationView";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<DonationViewDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WebApiResponse UseChatGPTReport(string query)
        {
            WebApiResponse webApiResponse = new WebApiResponse();
            using (HttpClient client = new HttpClient())
            {
                string path = "Home/UseChatGPTreport";
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
    }
}