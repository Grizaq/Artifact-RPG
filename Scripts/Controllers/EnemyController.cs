using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float agroRadius = 10f; // the distance at which the enemy is triggered by player

    Transform target; // reference to the player character
    NavMeshAgent agent; // start navigation
    CharacterCombat combat; // reference to the character combat script

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position); //targeting the player('s position)

        if (distance <= agroRadius) //in the radius specified
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                FaceTarget();
            }
        }
    }

    void FaceTarget() //smooth target following in attack radius (around)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }
    void OnDrawGizmosSelected() // utility - visibly show the radius of enemy targeting, not affecting the game
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRadius);
    }
}
