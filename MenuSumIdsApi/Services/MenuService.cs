using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MenuSumIdsApi
{
    public class MenuService : IMenuService
    {
        public IEnumerable<MenuModel> GetMenuServiceModel(string fileContent)
        {
            List<MenuModel> allmenu = null;
            try
            {
                if (!string.IsNullOrEmpty(fileContent))
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    allmenu = JsonSerializer.Deserialize<List<MenuModel>>(fileContent, options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return allmenu;
        }

        public string SumValidMenuIds(IEnumerable<MenuModel> allMenus)
        {
            var allSumIds = new StringBuilder();
            try
            {
                foreach (MenuModel curentMenu in allMenus)
                {
                    int menuSum = SumItemIds(curentMenu.Menu.Items);
                    allSumIds.AppendLine(menuSum.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return allSumIds.ToString().Trim();
        }

        private int SumItemIds(IEnumerable<ItemModel> menuItems)
        {
            int runningSum = 0;
            foreach (ItemModel currentItem in menuItems)
            {
                if (currentItem != null && currentItem.Label != null)
                {
                    runningSum += currentItem.Id;
                }
            }

            return runningSum;
        }
    }
}