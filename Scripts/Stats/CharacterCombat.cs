using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f; // the speed a character can posibly attack, can be individual
    public float attackCooldown = 0f; // counter for the attack timer
    const float combatCooldown = 5;
    float lastAttackTime;

    public float attackDelay = 1f;

    public bool inCombat { get; private set; }
    public event System.Action OnAttack;

    CharacterStats myStats;
    CharacterStats enemyStats;


    private void Start()
    {
        myStats = GetComponent<CharacterStats>();

    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        
        if (Time.deltaTime - lastAttackTime > combatCooldown) //if the comat finished the player will go out of combat stance animation
        {
            inCombat = false;
        }
    }
    public void Attack(CharacterStats targetStats) 
    {
        if (attackCooldown <= 0f)
        {
            enemyStats = targetStats;

            if(OnAttack != null)
            {
                OnAttack();
            }
            attackCooldown = 1f / attackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }
    }


    public void AttackHit_Animation()
    {
        enemyStats.TakeDamage(myStats.damage.GetValue());
        if (enemyStats.currentHp <= 0)
        {
            inCombat = false;
        }
    }
}
