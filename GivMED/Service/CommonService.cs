using GivMED.Common;
using GivMED.Dto;
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

        public static List<ComboDTO> GetEnumCombo<T>()
        {
            List<ComboDTO> oData = new List<ComboDTO>();
            oData.Add(new ComboDTO { DataValueField = "", DataTextField = "-- Select --" });
            try
            {
                foreach (IConvertible e in Enum.GetValues(typeof(T)))
                {
                    string text = e.ToString().Trim();
                    string value = e.ToType(Enum.GetUnderlyingType(typeof(T)), CultureInfo.CurrentCulture).ToString();
                    var attributes = typeof(T).GetField(text.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    string Description = attributes.Length == 0 ? text : ((DescriptionAttribute)attributes[0]).Description.ToString();
                    oData.Add(new ComboDTO { DataValueField = value, DataTextField = Description });
                }
                return oData;
            }
            catch (Exception)
            {
                throw;
            }
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
    }
}