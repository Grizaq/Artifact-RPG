using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp { get; private set; }
    public Stats damage;
    public Stats armor;

    public event System.Action<int, int> OnHealthChange;
    private void Awake()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage) // damage taken by entities, affected by stats, 1 def point reducing damage by 1 point
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHp -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage."); //logs used for unity showcase

        if (OnHealthChange != null)
        {
            OnHealthChange(maxHp, currentHp);
        }

        if (currentHp <= 0)
        {
            Die();
        }

    }
    public virtual void Die()
    {
        //Death info for chosen character, overwritten for each entity, to be shown logs
        Debug.Log(transform.name + " died.");
    }
}
