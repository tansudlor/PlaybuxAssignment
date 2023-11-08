using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using static InventoryManager;


public class InventoryManager : MonoBehaviour
{


    [Serializable]
    public class Item
    {
        public string name;
        public string rarity;
        public string collection;
        public string description;
        public string image;
        public string chain;
        public string type;
    }

    [Serializable]
    public class ItemsList
    {
        public List<Item> items;
    }

    [Serializable]
    public class Category
    {

        public ItemsList Hat { get; set; }
        public ItemsList Head { get; set; }
        public ItemsList Face { get; set; }
        public ItemsList Shirt { get; set; }
        public ItemsList Pants { get; set; }
        public ItemsList Back { get; set; }
        public ItemsList Shoes { get; set; }
        public ItemsList All
        {
            get
            {
                List<Item> allItems = new List<Item>();
                allItems.AddRange(Hat.items);
                allItems.AddRange(Head.items);
                allItems.AddRange(Face.items);
                allItems.AddRange(Shirt.items);
                allItems.AddRange(Pants.items);
                allItems.AddRange(Back.items);
                allItems.AddRange(Shoes.items);

                return new ItemsList { items = allItems };
            }
        }
    }

    [Serializable]
    public class Inventory
    {
        public Category inventory;
    }

    public static InventoryManager _inventoryManager;
    public TextAsset inventoryData;
    public GameObject ItemHolder;
    string jsonText;
    public List<GameObject> ListObjectList;

    Inventory inventory;
    public GameObject InventoryArea;

    public ItemsList itemListType;
    private void Awake()
    {
        _inventoryManager = this;
    }


    private void Start()
    {

        jsonText = inventoryData.text;


        inventory = JsonConvert.DeserializeObject<Inventory>(jsonText);


        Debug.Log(inventory.inventory.All.items.Count);


        Debug.Log(inventory.inventory.Hat.items.Count);


    }





    public void createListOrder(int num)
    {
        ListObjectList.Clear();
        for (int i = 0; i < InventoryArea.transform.childCount; i++)
        {
            Destroy(InventoryArea.transform.GetChild(i).gameObject);
        }
        itemListType = inventory.inventory.Hat;
        

        switch (num)
        {
            case 1: itemListType = inventory.inventory.All; break;
            case 2: itemListType = inventory.inventory.Hat; break;
            case 3: itemListType = inventory.inventory.Head; break;
            case 4: itemListType = inventory.inventory.Face; break;
            case 5: itemListType = inventory.inventory.Shirt; break;
            case 6: itemListType = inventory.inventory.Pants; break;
            case 7: itemListType = inventory.inventory.Back; break;
            case 8: itemListType = inventory.inventory.Shoes; break;
        }
        for (int i = 0; i < itemListType.items.Count; i++)
        {

            ListObjectList.Add(Instantiate(ItemHolder, InventoryArea.transform));

            ListObjectList[i].GetComponent<ImageClick>().SetData(Resources.Load<Sprite>(itemListType.items[i].image), i);
        }

        

    }


    public void LoadSelectData(int id)
    {
        
        var data = itemListType.items[id];
        ShowDescription._showdescription.ShowOnUI(data.name, data.rarity, data.description, data.collection, data.image , data.type);

    }

}


