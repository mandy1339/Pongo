using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class InventoryManager 
{
    private static HashSet<string> _ownedInventory;
    private static Dictionary<string, int> _fullInventory;
    private static bool _isInitialized = false;
    
    public static HashSet<string> GetInventory()
    {
        if (!_isInitialized)
            Initialize();
        return _ownedInventory;
    }

    private static void Initialize()
    {
        // read Inventory from playerprefs and parse it around | characters
        
        string rawInventory = PlayerPrefs.GetString("Inventory");
        _ownedInventory = GetInventorySetFromRaw(rawInventory);

        _fullInventory = new Dictionary<string, int>();
        _isInitialized = true;

        // Configuration of all inventory items
        _fullInventory.Add("Ball01", 0);
        _fullInventory.Add("Ball02", 0);
        _fullInventory.Add("Ball03", 15);
        _fullInventory.Add("Ball04", 18);
        _fullInventory.Add("Football01", 30);
        _fullInventory.Add("Triangle01", 25);
        _fullInventory.Add("Triangle02", 28);
        _fullInventory.Add("Triangle03", 35);
        _fullInventory.Add("Arrow", 40);
        _fullInventory.Add("Rocket", 75);
    }

    private static HashSet<string> GetInventorySetFromRaw(string rawInventory)
    {
        HashSet<string> inventory = new HashSet<string>();
        string[] parsedItems = rawInventory.Split('|');
        foreach (string item in parsedItems)
        {
            if (item.Length > 0)
                inventory.Add(item);
        }
        return inventory;
    }

    public static void AddToInventory(string newItem)
    {
        if (!_isInitialized)
            Initialize();

        // add new item to the owned inventory hash set
        if(newItem != null && newItem.Length > 0)
            _ownedInventory.Add(newItem);

        // turn _ownedInventory into a list of strings concatenated and with Pipes in between and then PlayerPrefs set string Inventory
        string formattedInventoryString = "";
        foreach(string str in _ownedInventory)
        {
            formattedInventoryString += str + "|";
        }
        PlayerPrefs.SetString("Inventory", formattedInventoryString);
    }

    public static int GetItemCost(string itemToBuy)
    {
        if (!_isInitialized)
            Initialize();
        int cost = 0;
        _fullInventory.TryGetValue(itemToBuy, out cost);
        return cost;
    }

    public static bool DoesPlayerOwnInventoryItem(string itemToCheck)
    {
        if (!_isInitialized)
            Initialize();

        return _ownedInventory.Contains(itemToCheck);
    }
}
