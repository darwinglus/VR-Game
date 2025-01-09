using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<string> inventoryItems = new List<string>();

    public void AddItem(string itemName)
    {
        inventoryItems.Add(itemName);
        Debug.Log($"Item {itemName} added to inventory.");
    }

    public void RemoveItem(string itemName)
    {
        if (inventoryItems.Remove(itemName))
        {
            Debug.Log($"Item {itemName} removed from inventory.");
        }
        else
        {
            Debug.Log($"Item {itemName} not found in inventory.");
        }
    }

    public void ListItems()
    {
        Debug.Log("Inventory items:");
        foreach (var item in inventoryItems)
        {
            Debug.Log(item);
        }
    }
}