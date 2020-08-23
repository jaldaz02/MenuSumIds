using System.Collections.Generic;

namespace MenuSumIdsApi
{
    public interface IMenuService
    {
        IEnumerable<MenuModel> GetMenuServiceModel(string fileContent);
        string SumValidMenuIds (IEnumerable<MenuModel> allMenus);
    }
}