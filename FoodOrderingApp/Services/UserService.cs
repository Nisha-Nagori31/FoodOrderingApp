using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderingApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApp.Services
{
    public class UserService
    {
        #region Fields,properties and objects
        //creating instance of firebase real time db class
        FirebaseClient client;
        #endregion

        #region Constructor
        //constructor and initialization of instance to end point
        public UserService()
        {
            //copying end point address
            client = new FirebaseClient("https://foodorderingapp-8a46c.firebaseio.com/");
        }
        #endregion

        #region Methods

        //method to check user exists, will return boolean value true/false
        public async Task<bool> IsUserExists(string uname)
        {
            //Users will act as User table inside db parent
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();

            return (user != null);
        }



        //method to register new user, is user doesn't exist.
        public async Task<bool> RegisterUser(string uname, string passwd)
        {

            if(await IsUserExists(uname)==false)
            {
                //post(add) new user

                await client.Child("Users").PostAsync(new User()
                {
                    Username = uname,
                   
                    Password = passwd
                });

                return true;
            }
            else
            {
                return false;
            }   
        }

        //check if user exist in db
        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == uname).Where(u => u.Object.Password == passwd).FirstOrDefault();

            
            return (user != null);
        }
        #endregion
    }
}
