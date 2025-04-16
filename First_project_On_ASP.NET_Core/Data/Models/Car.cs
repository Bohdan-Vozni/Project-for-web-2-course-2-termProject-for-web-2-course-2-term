using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Identity.Client;
using System.Security.Permissions;
using System.Security.Policy;

namespace Shop.Data.Models
{
    public class Car
    {
        public int id { get; set; }

        public string name { get; set; }

        public string shortDesc { get; set; }

        public string longDesc { get; set; }

        public string img {  get; set; }

        public ushort price { get; set; }

        public bool isFavourite { get; set; }

        public bool available { get; set; }

        public int categoryID { get; set; }

        public virtual Category category { get; set; }

        public int placeID { get; set; }
        public virtual Place place { get; set; }

    }
}
