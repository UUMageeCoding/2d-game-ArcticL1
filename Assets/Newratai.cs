using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Newratai : MonoBehaviour
{
     public float moveSpeed = 2f;
    float health, maxHealth = 3f;

    [SerializeField] Transform target;

    NavMeshAgent agent;

    void Start()
    {
        health = maxHealth; 
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = false;
    }
  
    private void Update()
    {
     agent.SetDestination(target.position);   
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        { 
            Destroy(gameObject);
        }
    }
}