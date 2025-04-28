using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class ReviewForSiteViewModel
    {
        public Reviews Review { get; set; }

        public List<Reviews> listReviews { get; set; }
    }
}
