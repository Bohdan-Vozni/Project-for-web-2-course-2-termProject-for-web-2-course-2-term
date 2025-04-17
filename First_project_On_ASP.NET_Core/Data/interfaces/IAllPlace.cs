using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.interfaces
{
    public interface IAllPlace
    {
        IEnumerable<Place> getAllPlace {  get;}
    }
}
