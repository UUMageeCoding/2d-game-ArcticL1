using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1;

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
    }
    

}
