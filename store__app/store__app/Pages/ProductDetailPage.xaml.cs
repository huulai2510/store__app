using store__app.Models;
using store__app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace store__app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        private int _productId;
        public ProductDetailPage(int productId)
        {
            InitializeComponent();
            GetProductDetails(productId);
            _productId = productId;
        }

        private async void GetProductDetails(int productId)
        {
            var product = await ApiService.GetProductById(productId);
            LblName.Text = product.Name;
            LblDetail.Text = product.Detail;
            LblPrice.Text = product.Price.ToString();
            ImgProduct.Source = product.FullImageUrl;
        }   

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void TapRemove_Tapped(object sender, EventArgs e)
        {
            var i = Convert.ToInt32(LblQty.Text);
            i--;
            if(i < 1)
            {
                return;
            }
            LblQty.Text = i.ToString();
        }

        private async void TapAddToCart_Tapped(object sender, EventArgs e)
        {
            var addToCart = new AddToCart()
            {
                Qty = Convert.ToInt32(LblQty.Text),
                Price = Convert.ToInt32(LblPrice.Text),
                ProductId = _productId,
                CustomerId = Preferences.Get("useId", 0)
            };

            var response = await ApiService.AddItemsInCart(addToCart);
            if (response)
            {
                await DisplayAlert("", "Your item has been added to the cart", "Alright");
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }

        private void TapAdd_Tapped(object sender, EventArgs e)
        {
            var i = Convert.ToInt32(LblQty.Text);
            i++;
            LblQty.Text = i.ToString();
        }
    }
}