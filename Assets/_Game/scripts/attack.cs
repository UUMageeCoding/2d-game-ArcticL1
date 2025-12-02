using UnityEngine;

public class attack : MonoBehaviour
{
  private Animator anim;
  public GameObject Melee;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckMeleeTimer();
       

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0))
        {
            Onattack();
        }
    }

    void Onattack()
    {
        if (!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
            anim.Play("Attack");
        }
    }

    void CheckMeleeTimer()
    {
        if(isAttacking)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= atkDuration)
            {
                atkTimer = 0f;
                isAttacking= false;
                Melee.SetActive(false);
            }
        }
    }
}
