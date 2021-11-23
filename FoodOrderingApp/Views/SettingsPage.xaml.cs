using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodOrderingApp.Helpers;

namespace FoodOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        async void ButtonProducts_clicked(System.Object sender,System.EventArgs e)
        {
            var afd = new AddFoodItemData();
            await afd.AddFoodItemsAysnc();
        }

        async void ButtonCategories_clicked(System.Object sender, System.EventArgs e)
        {
           var  acd = new AddCategoryData();
            await acd.AddCategoriesAsync();
        }
    }
}