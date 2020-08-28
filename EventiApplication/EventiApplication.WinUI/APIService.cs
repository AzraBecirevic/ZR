using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using EventiApplication.Model;
using System.Windows.Forms;
using EventiApplication.Model.Request;

namespace EventiApplication.WinUI
{
    public class APIService
    {
        private string _route;

        public static string Username { get; set; }
        public static string Password { get; set; }

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                    MessageBox.Show(Properties.Resources.Unauthorized, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                    MessageBox.Show(Properties.Resources.Forrbiden, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    MessageBox.Show(Properties.Resources.IntServerErr, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            try
            {
                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                    MessageBox.Show(Properties.Resources.Forrbiden, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    MessageBox.Show(Properties.Resources.IntServerErr, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

                var result = await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
               
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {                                         
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }
                MessageBox.Show(stringBuilder.ToString(), "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default(T);
            }
        }

        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                var result = await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            { 
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }
                MessageBox.Show(stringBuilder.ToString(), "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default(T);  
            }
        }

        public async Task<T> Delete<T>(int id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                var result = await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                    MessageBox.Show(Properties.Resources.BadRqst, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    MessageBox.Show(Properties.Resources.IntServerErr, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //else
                //    MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }

        }
                                             
        public async Task<T> UpdateAttribute<T>(object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}";   

                var result = await url.WithBasicAuth(Username, Password).PatchJsonAsync(request).ReceiveJson<T>(); //?

                return result;
            }
            catch(FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    MessageBox.Show(Properties.Resources.IntServerErr, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                    MessageBox.Show(Properties.Resources.BadRqst, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
               //else 
               //     MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
