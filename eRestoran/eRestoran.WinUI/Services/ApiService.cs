using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eRestoran.Model;
using eRestoran.WinUI.Properties;
using Flurl.Http;


namespace eRestoran.WinUI.Services
{
    public class ApiService
    {
        private string _resource;
	    public string endpoint = $"{Resources.ApiURL}";

        public static string Username { get; set; }
        public static string Password { get; set; }
        
        public ApiService(string resource)
        {
            _resource = resource;
        }

        public async Task<Model.Korisnik> Authenticate(string korisnickoIme, string lozinka)
        {
            try
            {
                var url = $"{endpoint}{_resource}/Authenticate";
                return await url.WithBasicAuth(korisnickoIme, lozinka).GetJsonAsync<Model.Korisnik>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == 401)
                    MessageBox.Show("Neispravno korisničko ime ili lozinka! ", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Došlo je do greške, pokušajte opet! ", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return default;
            }
        }

        public async Task<T> Get<T>(object search = null)
        {
            var url = $"{endpoint}{_resource}";
            
            if (search != null)
            {
                url += "?";
                url += await search?.ToQueryString();

            }

            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{endpoint}{_resource}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{endpoint}{_resource}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
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
                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
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

        public async Task<bool> Delete<T>(int id)
        {
            try
            {
                var url = $"{endpoint}{_resource}/{id}";


                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
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
                return false;
            }
        }
    }
}
