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
  public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }

        #region Constructor
        public AddFoodItemData()
        {
            client = new FirebaseClient("https://foodorderingapp-8a46c.firebaseio.com/");

            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductId=1,
                    CategoryId=1,
                    ImageUrl="Burger",
                    Name="Burger",
                    Description="Mouth watering Veg Burger",
                    Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=45
                },
                new FoodItem
                {
                    ProductId=2,
                    CategoryId=1,
                    ImageUrl="Pizza",
                    Name="Cheese Burst Pizza",
                    Description="Small Sized Cheese Burst Pizza",
                    Rating="4.4",
                    RatingDetail="(111 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=100

                },
                new FoodItem
                {
                    ProductId=3,
                    CategoryId=2,
                    ImageUrl="Dosa",
                    Name="Dosa",
                    Description="South India's Famous Tasty Dosa ",
                    Rating="4.6",
                    RatingDetail="(11 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=40
                },
                new FoodItem
                {
                    ProductId=4,
                    CategoryId=2,
                    ImageUrl="",
                    Name="Mendu Vada",
                    Description="Crunchy Hot Mendu Vada",
                    Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="EmptyHeart",
                    Price=30
                },
                new FoodItem
                {
                    ProductId=5,
                    CategoryId=3,
                    ImageUrl="",
                    Name="Fruit Plate",
                    Description="Healthy and Nutritious Fruit Plate",
                    Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=50
                },
                new FoodItem
                {

                    ProductId=5,
                    CategoryId=2,
                    ImageUrl="",
                    Name="Rice",
                    Description="Fresh tasty Plain Rice",
                    Rating="4.8",
                    RatingDetail="(121 ratings)",
                    HomeSelected="CompleteHeart",
                    Price=20
                }
            };
        }
        #endregion

        #region Methods
        public async Task AddFoodItemsAysnc()
        {
            try
            {
                foreach(var item in FoodItems)
                {
                    await client.Child("FoodItem").PostAsync(new FoodItem()
                    {
                        ProductId = item.ProductId,
                        CategoryId=item.CategoryId,
                        Name=item.Name,
                        Price=item.Price,
                        ImageUrl=item.ImageUrl,
                        Description=item.Description,
                        HomeSelected=item.HomeSelected,
                        Rating=item.Rating,
                        RatingDetail=item.RatingDetail
                    }) ;
                                         
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",ex.Message,"OK");
            }
        }

        #endregion
    }
}
