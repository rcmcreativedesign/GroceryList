using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GroceryListLibrary
{
    public class GroceryItemCollection : CollectionBase, IEnumerable<GroceryItem>
    {
        public GroceryItem this[int index]
        {
            get
            {
                return (GroceryItem)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(GroceryItem groceryItem)
        {
            return List.Add(groceryItem);
        }

        public void SerializeGroceryListToDisk(string pathToFile)
        {
            var serializer = JsonConvert.SerializeObject(List);
            File.WriteAllText(pathToFile, serializer);
        }

        public void DeserializeGroceryListFromDisk(string pathToFile)
        {
            var fileContents = File.ReadAllText(pathToFile);
            List.Clear();
            foreach (var item in JsonConvert.DeserializeObject<List<GroceryItem>>(fileContents))
            {
                List.Add(item);
            }
        }

        IEnumerator<GroceryItem> IEnumerable<GroceryItem>.GetEnumerator()
        {
            foreach (var item in List)
            {
                yield return item as GroceryItem;
            }
        }
    }
}
