
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Rat : MonoBehaviour
{
    public Animator Animation;

    [SerializeField] private Transform _target;
    [SerializeField][Range(0.5f, 20.0f)] private float _attackDistance;
    private NavMeshAgent _navMeshAgent;
    private AI_Rat_Machine _stateMachine;
    private float _previousXpos;

    GameObject player;

    private const string _iswalking = "isWalking";
    private const string _isAttacking = "isAttacking";
    float health, maxhealth = 3f;
    [SerializeField] private ParticleSystem Damageparticles; 
    private void Awake()
    {
        _stateMachine = GetComponentInChildren<AI_Rat_Machine>();
        Animation = GetComponent<Animator>();
    }


    void Start()
    {
        health = maxhealth;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _previousXpos = transform.position.x;
        player = GameObject.FindWithTag("Player");
    }

   
    void Update()
    {
        if (IsMovingRight()) GetComponent<SpriteRenderer>().flipX = false;
        else GetComponent<SpriteRenderer>().flipX = true;

       
        AnimatorStateInfo stateInfo = _stateMachine.anim.GetCurrentAnimatorStateInfo(0);

        Debug.Log("Can Attack player: " + _stateMachine.CanSeePlayer());
        if (_stateMachine.CanSeePlayer())
        {
            bool isAngry = stateInfo.IsName("Angry");
            if (AttackDistCheck() && isAngry)
            {
                Animation.SetBool(_isAttacking, true);
                _navMeshAgent.isStopped = true;
                Animation.SetBool(_iswalking, false);
            }
            else
            {
                Animation.SetBool(_isAttacking, false);
                _navMeshAgent.isStopped = false;
                Animation.SetBool(_iswalking, true);
                _navMeshAgent.SetDestination(_target.position);
            }

        }
        else
        {
            _navMeshAgent.isStopped = true;
            Animation.SetBool(_iswalking, false);
            _target = player.transform;
        }
        _previousXpos = transform.position.x;
    }

   
    public bool IsMovingRight()
    {
        return transform.position.x >= _previousXpos;
    }

    public bool AttackDistCheck()
    {
        return ((_target.position - transform.position).magnitude < _attackDistance);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("SQUEAK");
            Destroy(gameObject);
        }
    }
}

