using GroceryListLibrary;
using System.IO;
using Xunit;

namespace GroceryListTests
{
    public class GroceryListWriterTest
    {
        private readonly string pathToFile = "C:\\Temp\\GroceryList.json";

        [Fact]
        public void WriteListToDisk()
        {
            PopulateAndSerializeGroceryList();
            Assert.True(File.Exists(pathToFile));
            CleanUpGroceryList();
        }

        [Fact]
        public void ReadListFromDisk()
        {
            var groceryList = PopulateAndSerializeGroceryList();

            groceryList.DeserializeGroceryListFromDisk(pathToFile);
            Assert.Single(groceryList);
            Assert.Equal(1, groceryList[0].Id);
            CleanUpGroceryList();
        }

        private GroceryItemCollection PopulateAndSerializeGroceryList()
        {
            var groceryList = new GroceryItemCollection() { new GroceryItem() { Id = 1 } };
            groceryList.SerializeGroceryListToDisk(pathToFile);
            return groceryList;
        }

        private void CleanUpGroceryList()
        {
            File.Delete(pathToFile);
            Assert.False(File.Exists(pathToFile));
        }

    }
}
