
public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        //death animation if needed
        Destroy(gameObject);
    }


}
