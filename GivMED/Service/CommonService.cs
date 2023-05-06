using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GivMED.Service
{
    public class CommonService
    {

        public List<ComboDTO> GetItemCat()
        {
            List<ComboDTO> records = new List<ComboDTO>();
            records.Add(new ComboDTO { DataValueField = "", DataTextField = "-- Select --" });
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/GetItemCat";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    records.AddRange(JsonConvert.DeserializeObject<List<ComboDTO>>(value));
                }
            }
            return records;
        }
        public List<ComboDTO> GetTemplate(int HospitalID)
        {
            List<ComboDTO> records = new List<ComboDTO>();
            records.Add(new ComboDTO { DataValueField = "", DataTextField = "-- Select --" });
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/GetTemplate/" + HospitalID;
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    records.AddRange(JsonConvert.DeserializeObject<List<ComboDTO>>(value));
                }
            }
            return records;
        }

        public List<ComboDTO> GetAllItems()
        {
            List<ComboDTO> records = new List<ComboDTO>();
            records.Add(new ComboDTO { DataValueField = "", DataTextField = "-- Select --" });
            using (HttpClient client = new HttpClient())
            {
                string path = "Supply/GetAllItems";
                client.BaseAddress = new Uri(GlobalData.BaseUri);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    records.AddRange(JsonConvert.DeserializeObject<List<ComboDTO>>(value));
                }
            }
            return records;
        }

        public List<ComboDTO> GetEnumComboWithSelect<T>()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            oData.Add(new ComboDTO { DataValueField = "", DataTextField = "-Select-" });
            try
            {
                foreach (T e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = Convert.ToInt32(e).ToString();
                    var attributes = typeof(T).GetField(text).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description;
                    oData.Add(new ComboDTO { DataValueField = value, DataTextField = description });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oData;
        }


        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public bool GetIsDonorAvailability(string UserName)
        {
            try
            {
                bool isAvailable = false;

                using (HttpClient client = new HttpClient())
                {
                    string path = "Authentication/GetIsDonorAvailability/" + UserName;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        isAvailable = JsonConvert.DeserializeObject<bool>(value);
                    }
                }
                return isAvailable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GetIsHospitalAvailability(string UserName)
        {
            try
            {
                bool isAvailable = false;

                using (HttpClient client = new HttpClient())
                {
                    string path = "Authentication/GetIsHospitalAvailability/" + UserName;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        isAvailable = JsonConvert.DeserializeObject<bool>(value);
                    }
                }
                return isAvailable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GetIsUserAvailability(string Email)
        {
            try
            {
                bool isAvailable = false;

                using (HttpClient client = new HttpClient())
                {
                    string path = "Authentication/GetIsUserAvailability/" + Email;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        isAvailable = JsonConvert.DeserializeObject<bool>(value);
                    }
                }
                return isAvailable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmailConfiguration GetEmailConfiguration()
        {
            try
            {
                EmailConfiguration isSettings = new EmailConfiguration();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Authentication/GetEmailConfiguration/";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        isSettings = JsonConvert.DeserializeObject<EmailConfiguration>(value);
                    }
                }
                return isSettings;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EmailUsers> GetAllActiveEmailUsers()
        {
            try
            {
                List<EmailUsers> record = new List<EmailUsers>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Registration/GetAllActiveEmailUsers";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<EmailUsers>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DeliveryDataDto> GetDoantionEmailUsersbySupplyID(string SupplyID)
        {
            try
            {
                List<DeliveryDataDto> record = new List<DeliveryDataDto>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Registration/GetDoantionEmailUsersbySupplyID/" + SupplyID;
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalData.Token);
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        record = JsonConvert.DeserializeObject<List<DeliveryDataDto>>(value);
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VolunteerMaster> GetAllAssignVolunteers(List<DonationVolunteer> oDonationVolunteer)
        {
            try
            {
                List<VolunteerMaster> record = new List<VolunteerMaster>();

                using (HttpClient client = new HttpClient())
                {
                    string path = "Registration/GetAllAssignVolunteers/" + oDonationVolunteer;
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
    }
}