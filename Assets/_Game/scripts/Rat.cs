
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
public class Rat : MonoBehaviour
{
    public Animator Anim;
    [SerializeField] private Transform target;
    [SerializeField] [Range(0.5f, 2.5f)] private float attackDistance;

    private NavMeshAgent navMeshAgent;

    private AI_Rat_Machine statemachine;

    private float previousXpos;

    private const string isWalking = "iswalking";
    private const string isAttacking = "isAttacking";

    private void Awake()
    {
        statemachine = GetComponentInChildren<AI_Rat_Machine>();
        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.transform.position = transform.position;
    }

    void Update()
    {
        if (IsMovingRight()) GetComponent<SpriteRenderer>().flipX = false;
        else GetComponent<SpriteRenderer>().flipX = true;


        AnimatorStateInfo stateInfo = statemachine.Anim.GetNextAnimatorStateInfo(0);

        Debug.Log("i can see player : " + statemachine.annoyed());
        if (statemachine.annoyed())

        {
            bool isannoyed = stateInfo.IsName("annoyed");
            if (AttackDistancecheck() && isannoyed)
            {
                Anim.SetBool(isAttacking, true);
                navMeshAgent.isStopped = true;
                Anim.SetBool(isWalking, false);
            }

            else

            {
                Anim.SetBool(isAttacking, false);
                navMeshAgent.isStopped = false;
                Anim.SetBool(isWalking, true);
                navMeshAgent.SetDestination(target.position);
            }
        }

        else
        {
            navMeshAgent.isStopped = true;
            Anim.SetBool(isWalking, false);

        }
        previousXpos = transform.position.x;
    }

    public bool IsMovingRight()
    {
        return transform.position.x >= previousXpos;
    }

    
    public bool AttackDistancecheck()
    {
        return ((target.position - transform.position).magnitude < attackDistance);

    }
}
