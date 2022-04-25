using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots; //list of items in inventory

    void Start()
    {
        
        inventory = Inventory.instance;
        inventory.OnItemchangedCallback += UpdateUi;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Inventory")) //cursor not interacting "through" inventory window
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    void UpdateUi ()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
