using System.Collections.Generic;

namespace MenuSumIdsApi
{
    public class MenuModel
    {
        public MenuDetailsModel Menu { get; set; }
    }

    public class MenuDetailsModel
    {
        public string Header { get; set; }

        public IEnumerable<ItemModel> Items {get; set;}
    }

    public class ItemModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}