using System;
using System.Collections;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    float cathealth, maxhealth = 5f;
    Vector2 checkpointPos;
    Rigidbody2D PlayerRb;
    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        cathealth = maxhealth;
        checkpointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dtrap"))
        {
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        cathealth -= damage;
        if (cathealth <= 0)
        {
            Debug.Log("meow");
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    void Die()
    {
        
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        PlayerRb.simulated = false;
        PlayerRb.linearVelocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
         PlayerRb.simulated = true;
    }
     
}
