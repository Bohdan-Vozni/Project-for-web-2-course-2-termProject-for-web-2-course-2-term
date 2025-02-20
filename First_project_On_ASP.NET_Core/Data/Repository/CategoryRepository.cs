using Shop.Data.interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCegories => appDBContent.Category;

    }
}
