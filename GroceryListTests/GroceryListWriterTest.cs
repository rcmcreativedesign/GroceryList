using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Newtonsoft.Json;
using System.Text;
using GroceryListLibrary;

namespace GroceryListTests
{
    public class GroceryListWriterTest
    {
        private readonly string pathToFile = "C:\\Temp\\GroceryList.json";

        [Fact]
        public void WriteListToDisk()
        {
            var groceryList = new GroceryItemCollection() { new GroceryItem() { Id = 0 } };
            groceryList.SerializeGroceryListToDisk(pathToFile);
            Assert.True(File.Exists(pathToFile));
            File.Delete(pathToFile);
            Assert.False(File.Exists(pathToFile));
        }

        [Fact]
        public void ReadListFromDisk()
        {
            var groceryList = new GroceryItemCollection() { new GroceryItem() { Id = 1 } };
            groceryList.SerializeGroceryListToDisk(pathToFile);

            groceryList.DeserializeGroceryListFromDisk(pathToFile);
            Assert.Single(groceryList);
            Assert.Equal(1, groceryList[0].Id);

            File.Delete(pathToFile);
            Assert.False(File.Exists(pathToFile));
        }

        [Fact]
        public void SerializeGroceryList()
        {
            var groceryList = new GroceryItem() { Id = 1 };
            var serializedGroceryList = JsonConvert.SerializeObject(groceryList);
            Assert.Equal("{\"Id\":1}", serializedGroceryList);
        }


    }
}
