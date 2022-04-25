
public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }


        void OnEquipmentChanged(Equipment newItem, Equipment oldItem) //changing the stats of player based on items equipped
        {
            if (newItem != null)
            {
                armor.AddModifier(newItem.armorModifier);
                damage.AddModifier(newItem.damageModifier);
            }
            if (oldItem != null)
            {
                armor.RemoveModifier(oldItem.armorModifier);
                damage.RemoveModifier(oldItem.damageModifier);
            }
        }
    public override void Die() //technically just respawning the player
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
