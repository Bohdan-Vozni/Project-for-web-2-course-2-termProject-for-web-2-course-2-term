using Shop.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace Shop.Data.interfaces
{
    public interface ICarsCategory
    {
       public IEnumerable<Category> AllCegories { get; }
    }
}
