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
    [Activity(Label = "Cardapio")]
    public class Cardapio : ListActivity
    {
        private JsonValue eae;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Cardapiolay);
            LoadContent();
            // Create your application here
        }

        private async Task<JsonValue> Get()
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://10.21.0.137/20131011110061/api/cardapio"));
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
        public async void LoadContent()
        {
            eae = await Get();

            List<Models.Cardapio> list = JsonConvert.DeserializeObject<List<Models.Cardapio>>(eae);
            IList<IDictionary<string, object>> dados = new List<IDictionary<string, object>>();
            foreach (Models.Cardapio r in list)
            {
                IDictionary<string, object> dado = new JavaDictionary<string, object>();
                //dado.Add("Id", r.Id.ToString());
                dado.Add("Descricao", r.Descricao);
                dados.Add(dado);
            }

            string[] from = new String[] { "Descricao" };
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