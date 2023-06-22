using System.Collections.Generic;

namespace RepositoriesManager.Models
{
    public class RepositoriesData
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<Item> items { get; set; }
    }
}
