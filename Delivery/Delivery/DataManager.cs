using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    class DataManager
    {
        public static List<User> users = new List<User>();
        public static List<Restaurant> restaurants = new List<Restaurant>();
        public static List<Favorite> favorites = new List<Favorite>();
        public static List<Review> reviews = new List<Review>();
        public static List<Comment> comments = new List<Comment>();
    }
}
