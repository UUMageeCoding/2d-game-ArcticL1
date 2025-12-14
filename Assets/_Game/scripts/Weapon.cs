using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1;
    public float amount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rat rat = collision.GetComponent<Rat>();
        if (rat != null)
        {
            rat.TakeDamage(damage);
        }

        PotBreak  smash = collision.GetComponent<PotBreak>();
        if (smash != null)
        {
            smash.TakeDamage(damage);
        }

        Demonboss boss = collision.GetComponent<Demonboss>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }

        speedyrat speed = collision.GetComponent<speedyrat>();
        if (speed != null)
        {
            speed.TakeDamage(damage);
        }

        tankrat tank = collision.GetComponent<tankrat>();
        if (tank != null)
        {
            tank.TakeDamage(damage);
        }

    }
    

}
