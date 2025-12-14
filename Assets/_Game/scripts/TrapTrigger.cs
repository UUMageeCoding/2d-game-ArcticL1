using System;
using System.Collections;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{ 
    Vector2 checkpointPos;
    Rigidbody2D PlayerRb;
    float health, maxhealth = 10f;
    
    [SerializeField] healthbar healthbar;

    [SerializeField] private ParticleSystem Damageparticles;
    [SerializeField] private ParticleSystem Deathparticles;
    private ParticleSystem DamageParticlesInstance;
    private ParticleSystem DeathParticlesInstance;

    audiomanager audiomanager;
    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<healthbar>();
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
    }
    private void Start()
    {
        health = maxhealth;
        healthbar.updatehealthbar(health, maxhealth);
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
        health -= damage;
        catblood();
        audiomanager.PlaySFX(audiomanager.hit);
        healthbar.updatehealthbar(health, maxhealth);
        if (health <= 0)
        {
            Debug.Log("meow");
            audiomanager.PlaySFX(audiomanager.death);
            deathsmoke();
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
        health = maxhealth;
        healthbar.updatehealthbar(health, maxhealth);
    }

    private void catblood()
    {
        DamageParticlesInstance = Instantiate(Damageparticles, transform.position, Quaternion.identity);
    }

    private void deathsmoke()
    {
        DeathParticlesInstance = Instantiate(Deathparticles, transform.position, Quaternion.identity);
    }
}
