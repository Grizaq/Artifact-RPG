using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
public override void Interact() //to be completed in calls
    {
        base.Interact();
        PickUp();
        
    }   
    void PickUp()
    {
        Debug.Log("Picked one " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp) //if the item was taken, it disappears
        { 
            Destroy(gameObject);
        }
    }

}
