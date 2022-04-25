using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //modified on call instances
        //Debug.Log("Using " + name); // can be replaced with floating texts
    }
    public void RemoveFromInventory() //removing item from inventory on deletin/equipping
    {
        Inventory.instance.Remove(this);
    }

}
