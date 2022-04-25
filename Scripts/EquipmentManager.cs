using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;

    }
    #endregion

    public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;


    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;


    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];
        currentMeshes = new SkinnedMeshRenderer[numberOfSlots];

    }

    public void Equip (Equipment newItem) //add item on character (improving stats)
    {
        int slotIndex = (int)newItem.EquipSlot;
        
        Equipment oldItem = Unequip(slotIndex);


        if (onEquipmentChanged != null) //replacing old item with the one in inventory instead of destroying it
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip (int slotindex) //removes equipped item from character, no character equipped items impemented, as not needed for presentation
    {
        if (currentEquipment[slotindex] != null)
        {
            if (currentMeshes[slotindex] != null)
            {
                Destroy(currentMeshes[slotindex].gameObject);
            }
            Equipment oldItem = currentEquipment[slotindex];
            inventory.Add(oldItem);
            currentEquipment[slotindex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            return oldItem;

        }
        return null;
    }
    public void UnequipAll() //removes all items, useful for no equipped item case
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }

    }

}
