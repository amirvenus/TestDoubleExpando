using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDoubleExpando
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            while(true)
            {
                ViewModel.Instance.Username = DateTime.Now.ToLongTimeString();
                
var nameOfExpandoKey = "Dt";
ViewModel.Instance.Expando = new System.Dynamic.ExpandoObject();
(ViewModel.Instance.Expando as IDictionary<string, object>).Add(nameOfExpandoKey, DateTime.Now.ToLongTimeString());
LabelWithExpando.SetBinding(Label.TextProperty, $"Expando[{nameOfExpandoKey}]");
var nameOfNestedExpandoKey = "Nested";
(ViewModel.Instance.Expando as IDictionary<string, object>).Add(nameOfNestedExpandoKey, new ExpandoObject());
var nameOfSecondNestedKey = "Nested2";
((ViewModel.Instance.Expando as IDictionary<string, object>)[nameOfNestedExpandoKey] as IDictionary<string, object>).Add(nameOfSecondNestedKey, DateTime.Now.ToLongTimeString());
LabelWithExpando2.SetBinding(Label.TextProperty, $"Expando[{nameOfExpandoKey}][{nameOfNestedExpandoKey}][{nameOfSecondNestedKey}]");
await Task.Delay(1500);
            }
            
        }
    }
}
