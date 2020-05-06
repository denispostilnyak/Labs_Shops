using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs_Shops.Controllers;
using Labs_Shops.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Labs_Shops.Testing
{
    public class Categories_tests
    {
        [Fact]
        public void GetCategoriesData() {

            // Arrange
            CategoriesController controller = new CategoriesController();

            // Act
            var result = controller.GetCategories(44) as IEnumerable<Category>;

            // Assert
            Assert.Equal("Test77777", result?.ToList().FirstOrDefault().Name);
        }
        [Fact]
        public void GetCategoriesNotNull () {

            // Arrange
            CategoriesController controller = new CategoriesController();

            // Act
            var result = controller.GetCategories(45) as IEnumerable<Category>;

            // Assert
            Assert.NotNull(result.ToList());
        }


    }
}
