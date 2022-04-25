using UnityEngine;

public class CharAnimEventReceiver : MonoBehaviour
{
    public CharacterCombat combat;
public void AttackHit()
    {
        combat.AttackHit_Animation(); 
    }
}
