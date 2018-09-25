using System.Collections.Generic;

namespace Easv.PetShop.Core.Entity
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}