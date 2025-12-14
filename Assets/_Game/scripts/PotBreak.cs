using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class PotBreak : MonoBehaviour
{
    float health, maxhealth = 3f;
    public Sprite Broken;
    [SerializeField] private ParticleSystem SmashParticles;
    audiomanager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
    }
    private ParticleSystem SmashParticlesInstance;
    void Start()
    {
        health = maxhealth;
    }

    public void TakeDamage(float damage)
    {
        potshards();
        audiomanager.PlaySFX(audiomanager.smash);
        health -= damage;
        if (health <= 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Broken;
            Debug.Log("iam hurt"); 
        }

        if (health <= 0)
        {
            Debug.Log("smash"); 
            Destroy(gameObject);
        }

    }
    
    private void potshards()
    {
        SmashParticlesInstance = Instantiate(SmashParticles, transform.position, quaternion.identity);
    }
}
