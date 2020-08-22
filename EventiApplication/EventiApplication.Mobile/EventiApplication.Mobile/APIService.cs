using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using EventiApplication.Model;
using Xamarin.Forms;

namespace EventiApplication.Mobile
{    
    public class APIService
    {
        private string _route;

        public static string Username { get; set; }
        public static string Password { get; set; }

#if DEBUG
        //uwp
      //  private string _apiUrl = "http://127.0.0.1:65094/api";     // "http://localhost:65094/api"; 
       //android
       private string _apiUrl = "http://10.0.2.2:65094/api";  

#endif
#if RELEASE
        string _apiUrl =    "http://127.0.0.1:65094/api";   //"www.nekiWebSite.com/api";
#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";

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
                   await Application.Current.MainPage.DisplayAlert("Greska", Messages.Unauthorized, "OK");
      

                else if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                    await Application.Current.MainPage.DisplayAlert("Greska", Messages.Forrbiden, "OK");

                else if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    await Application.Current.MainPage.DisplayAlert("Greska", Messages.IntServerErr, "OK");
              //  else
                //    await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "OK");
                throw;
            }

        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            try
            {
                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                    await Application.Current.MainPage.DisplayAlert("Greska", Messages.Forrbiden, "OK");

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    await Application.Current.MainPage.DisplayAlert("Greska", Messages.IntServerErr, "OK");
                throw;
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}";

                var result = await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                /*  if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                      await Application.Current.MainPage.DisplayAlert("Greska", Messages.Forrbiden, "OK");

                  if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                      await Application.Current.MainPage.DisplayAlert("Greska", Messages.IntServerErr, "OK");

                  if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                      await Application.Current.MainPage.DisplayAlert("Greska", Messages.BadRqst, "OK");
                  else
                      await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "OK");
                  // throw;
                  return default(T);  */
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greska", stringBuilder.ToString(), "OK");
                return default(T);

            }
        }

        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                var result = await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                /* if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                     await Application.Current.MainPage.DisplayAlert("Greska", Messages.Forrbiden, "OK");

                 if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                     await Application.Current.MainPage.DisplayAlert("Greska", Messages.IntServerErr, "OK");

                 if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                     await Application.Current.MainPage.DisplayAlert("Greska", Messages.BadRqst, "OK");
                 else
                     await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "OK");  //?  zbog userExceptiona

                 return default(T);  */

                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greska", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }

        public async Task<T> Delete<T>(int id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                var result = await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                    await Application.Current.MainPage.DisplayAlert("Greska", Messages.BadRqst, "OK");

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    await Application.Current.MainPage.DisplayAlert("Greska", Messages.IntServerErr, "OK");
                //else
                //    MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }

        }

        public async Task<T> UpdateAttribute<T>(object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}";

                var result = await url.WithBasicAuth(Username, Password).PatchJsonAsync(request).ReceiveJson<T>(); //?

                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    await Application.Current.MainPage.DisplayAlert("Greska", Messages.IntServerErr, "OK");

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                    await Application.Current.MainPage.DisplayAlert("Greska", Messages.BadRqst, "OK");
                //else 
                //     MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
