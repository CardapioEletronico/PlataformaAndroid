using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Json;

namespace ClienteAndroid
{
    [Activity(Label = "ClienteAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private JsonValue aeho;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            LoadContent();
        }

        private async Task<JsonValue> Get()
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://10.21.0.137/20131011110061/api/restaurante"));
            //request.ContentType = "10.21.0.137/20131011110061/api/restaurante";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                    // Return the JSON document:
                    return jsonDoc.ToString();
                }
            }
        }

        //LOAD LISTA E PÁGINA
        public async void LoadContent()
        {
            aeho = await Get();

            List<Models.Restaurante> list = JsonConvert.DeserializeObject<List<Models.Restaurante>>(aeho);
            IList<IDictionary<string, object>> dados = new List<IDictionary<string, object>>();
            foreach (Models.Restaurante r in list)
            {
                IDictionary<string, object> dado = new JavaDictionary<string, object>();
                //dado.Add("Id", r.Id.ToString());
                dado.Add("Descricao", r.Descricao);
                dados.Add(dado);
            }

            string[] from = new String[] {"Descricao" };
            //string[] from = new String[] { "Id", "Descricao" };
            int[] to = new int[] { Resource.Id.descRest };
            int layout = Resource.Layout.listRest;

            // ArrayList for data row
            // SimpleAdapter mapping static data to views in xml file
            SimpleAdapter adapter = new SimpleAdapter(this, dados, layout, from, to);

            ListView.Adapter = adapter;
        }
    }
}

