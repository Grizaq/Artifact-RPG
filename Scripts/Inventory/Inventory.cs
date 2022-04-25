using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    void Awake()
    {
        if (instance != null) //debug for extra entities of inventory
        {
            Debug.LogWarning("More than 1 inventory found");
            return;
        }
        instance = this;
    }

    public delegate void OnItemchanged();
    public OnItemchanged OnItemchangedCallback;

    public int space = 20; //inventory space
    
    public List<Item> items = new List<Item>(); //list of items in inventory, to be used for conditional interaction

    public bool Add(Item item) //adding item to inventory (after interaction)
    {
        if (!item.isDefaultItem)
        { 
            if (items.Count >= space) //checking if there's inventory space left
            {
                Debug.Log("Out of space in inventory"); //log for showcase, not implemented in showcase though
                return false;
            }
            items.Add(item);

            if (OnItemchangedCallback != null)
            {
                OnItemchangedCallback.Invoke();
            }
        }
        return true;
    }
    public void Remove(Item item) //"deleting" item from inventory, dropping not implemented/ not needed
    {
        items.Remove(item);

        if (OnItemchangedCallback != null)
        {
            OnItemchangedCallback.Invoke();
        }

    }
}
