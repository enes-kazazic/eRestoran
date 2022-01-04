using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using eProdaja.Model;
using eRestoran.WinUI.Properties;
using Flurl.Http;


namespace eRestoran.WinUI.Services
{
    public class ApiService
    {
        private string _resource;
	    public string endpoint = $"{Resources.ApiURL}";

        public ApiService(string resource)
        {
            _resource = resource;
        }

        public async Task<T> Get<T>(object search = null)
        {
            var url = $"{endpoint}{_resource}";
            
            if (search != null)
            {
                url += "?";
                url += await search?.ToQueryString();

            }

            var result = await url.GetJsonAsync<T>();

            return result;
        }

        public async Task<T> GetById<T>(int id)
        {
            var url = $"{endpoint}{_resource}/{id}";
            return await url.GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{endpoint}{_resource}";

            try
            {
                return await url.PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Update<T>(int id, object request)
        {
            //try
            //{
                var url = $"{endpoint}{_resource}/{id}";
                return await url.PutJsonAsync(request).ReceiveJson<T>();
            //}
            //catch (FlurlHttpException ex)
            //{
            //    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
            //
            //    var stringBuilder = new StringBuilder();
            //    foreach (var error in errors)
            //    {
            //        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
            //    }
            //
            //    MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return default(T);
            //}
        }
    }
}
