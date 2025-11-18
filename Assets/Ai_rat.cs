using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class AI_Skeleton : MonoBehaviour
{
    public Animator Animation;

    [SerializeField] private Transform _target;
    [SerializeField][Range(0.5f, 2.5f)] private float _attackDistance;
    private NavMeshAgent _navMeshAgent;
    private AI_Rat_StateMC _stateMachine;
    private float _previousXpos;

    private const string _iswalking = "isWalking";
    private const string _isAttacking = "isAttacking";

    private void Awake()
    {
        _stateMachine = GetComponentInChildren<AI_Rat_StateMC>();
        Animation = GetComponent<Animator>();
    }


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _previousXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMovingRight()) GetComponent<SpriteRenderer>().flipX = false;
        else GetComponent<SpriteRenderer>().flipX = true;

        // check current _stateMachine animation state
        AnimatorStateInfo stateInfo = _stateMachine.anim.GetCurrentAnimatorStateInfo(0);

        Debug.Log("Can see player: " + _stateMachine.CanSeePlayer());
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
        }
        _previousXpos = transform.position.x;
    }

    // check direction of movement in the x axis
    public bool IsMovingRight()
    {
        return transform.position.x >= _previousXpos;
    }

    public bool AttackDistCheck()
    {
        return ((_target.position - transform.position).magnitude < _attackDistance);
    }
}

