using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace MenuSumIdsApi.Tests
{
    public class MenuServiceTest
    {
        [Fact]
        public void Deserialize_Valid_Menu_String()
        {
            List<ItemModel> itemsMenu = new List<ItemModel>();
            itemsMenu.Add(new ItemModel
            {
                Id = 81
            });
            itemsMenu.Add(null);
            itemsMenu.Add(new ItemModel
            {
                Id = 46,
                Label = "Label 46"
            });

            List<MenuModel> expectedMenuModel = new List<MenuModel>();
            expectedMenuModel.Add(new MenuModel
            {
                Menu = new MenuDetailsModel
                {
                    Header = "menu",
                    Items = itemsMenu
                }
            });

            string inputStg = "[{\"menu\": {\"header\": \"menu\",\"items\": [{\"id\": 81},null,{\"id\": 46,\"label\": \"Label 46\"}]}}]";

            IEnumerable<MenuModel> actualMenuModel;

            MenuService service = new MenuService();
            actualMenuModel = service.GetMenuServiceModel(inputStg);

            expectedMenuModel.Should().BeEquivalentTo(actualMenuModel);
        }

        [Fact]
        public void Deserialize_Empty_String()
        {
            string inputStg = "";

            MenuService service = new MenuService();
            var actualMenuModel = service.GetMenuServiceModel(inputStg);

            Assert.Null(actualMenuModel);
        }

        [Fact]
        public void Deserialize_Empty_Menu_String()
        {
            string inputStg = "[]";

            MenuService service = new MenuService();
            var actualMenuModel = service.GetMenuServiceModel(inputStg);

            Assert.Empty(actualMenuModel);
        }

        [Fact]
        public void Zero_Sum_Valid_Menu_String()
        {
            string expectedResult = "0";

            string inputStg = "[{\"menu\": {\"header\": \"menu\",\"items\": [{\"id\": 81}]}}]";

            MenuService service = new MenuService();
            var actualMenuModel = service.GetMenuServiceModel(inputStg);
            string actualResult = service.SumValidMenuIds(actualMenuModel);

            Assert.Equal (expectedResult, actualResult);
        }

        [Fact]
        public void Sum_Two_Valid_Menu_String()
        {
            string expectedResult = "0\r\n46";

            string inputStg = "[{\"menu\": {\"header\": \"menu\",\"items\": [{\"id\": 81}]}},{\"menu\": {\"header\": \"menu\",\"items\": [{\"id\": 81},null,{\"id\": 46,\"label\": \"Label 46\"}]}}]";

            MenuService service = new MenuService();
            var actualMenuModel = service.GetMenuServiceModel(inputStg);
            string actualResult = service.SumValidMenuIds(actualMenuModel);

            Assert.Equal (expectedResult, actualResult);
        }
    }
}
