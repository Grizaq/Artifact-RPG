using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")] //currently used to hold sword and show stats effects
public class Equipment : Item
{
    public EquipmentSlot EquipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions; 

    public int armorModifier; //armor/def decreases damage 1/1
    public int damageModifier; //increases damage 1/1

    public override void Use() //on use the item will be removed from inventory and be on the player (not in effect)
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Chest, Weapon, Shield, Legs, Feet } //not used efficiently, just sword
public enum EquipmentMeshRegion {Legs, Arms, Torso} // same as body blend