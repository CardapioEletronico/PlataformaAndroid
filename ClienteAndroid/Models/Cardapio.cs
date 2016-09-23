using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ClienteAndroid.Models
{
    public class Cardapio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Restaurante_id { get; set; }
    }
}