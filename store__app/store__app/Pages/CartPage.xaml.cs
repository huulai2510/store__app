using store__app.Models;
using store__app.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace store__app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        ObservableCollection<ShoppingCartItem> ShoppingCartCollection;
        public CartPage()
        {
            InitializeComponent();
            ShoppingCartCollection = new ObservableCollection<ShoppingCartItem>();
            GetShoppingCartItems();
        }

        private async void GetShoppingCartItems()
        {
            var shoppingCartItems = await ApiService.GetShoppingCartItems(Preferences.Get("userId", 0));
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                ShoppingCartCollection.Add(shoppingCartItem);
            }
            LvShoppingCart.ItemsSource = ShoppingCartCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}