using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderingApp.Helpers
{
    public class AddCategoryData
    {
        #region Fields and Properties
        public List<Category> Categories { get; set; }

        FirebaseClient client;
        #endregion

        #region Constructor
        public AddCategoryData()
        {
            client = new FirebaseClient("https://foodorderingapp-8a46c.firebaseio.com/");

            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId=1,
                    CategoryName="FastFood",
                    CategoryPoster="Wraps.jpg"
                },
                new Category()
                {
                    CategoryId=2,
                    CategoryName="SouthIndian",
                    CategoryPoster="Southindian"
                 },
                new Category()
                {
                    CategoryId=3,
                    CategoryName="FastFood",
                    CategoryPoster="Burger1.jpg"
                },
                new Category()
                {
                    CategoryId=3,
                    CategoryName="SouthIndian",
                    CategoryPoster="MenduVada.jpg",

                }
            };
        }
        #endregion

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var c in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryId=c.CategoryId,
                        CategoryName=c.CategoryName,
                        CategoryPoster=c.CategoryPoster,
                        ImageUrl=c.ImageUrl
                       
                    });
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

    }
}
