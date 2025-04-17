using Shop.Data.interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public class PlaceRepository : IAllPlace
    {
        private readonly AppDBContent content;

        public  PlaceRepository(AppDBContent content)
        {
            this.content = content;
        }
        public IEnumerable<Place> getAllPlace => content.Places;

    }
}
