using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimation : MonoBehaviour
{
    public AnimationClip replaceableAttackAnimation;

    public AnimationClip[] defaultAnimation;
    protected AnimationClip[] currentAttackAnimation;

    const float locomotionAnimationSmoothTime = 0.1f;
    NavMeshAgent agent;
    protected Animator animator;
    protected CharacterCombat combat;
    public AnimatorOverrideController overrideController;
    protected virtual void Start() //animation starter, which is to be overwritten by unity
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        if (overrideController == null)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        animator.runtimeAnimatorController = overrideController;

        currentAttackAnimation = defaultAnimation;
        combat.OnAttack += OnAttack;
    }

    protected virtual void Update() //attack speed can be tweaked to be affected by some stats; animations changing based on time
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
        animator.SetBool("inCombat", combat.inCombat);
    }

    protected virtual void OnAttack() //triggering the "damage" at a ceratin point of the attack animations and triggering the damage based on def stat
    {
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0, currentAttackAnimation.Length);
        overrideController[replaceableAttackAnimation.name] = currentAttackAnimation[attackIndex];
    }
}
