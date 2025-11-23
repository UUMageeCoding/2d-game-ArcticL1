using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Rat_Machine : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _playerDistance = Mathf.Infinity;
    [SerializeField] private float _distanceToPlayerThreshold = 5f;
    public Animator anim;
    [SerializeField] private float _turnSadChance = 0.001f;
    private const string _isupset = "isUpset";
    private const string _seePlayer = "PlayerVisible";

    private void Awake()
    {

    }

  
    private void Update()
    {
        float invertHappiness = Random.Range(0f, 1f);
        if (invertHappiness > 1 - _turnSadChance)
        {
            anim.SetBool(_isupset, !anim.GetBool(_isupset));
        }
        _playerDistance = (_player.position - transform.position).magnitude;
       
        if (_playerDistance < _distanceToPlayerThreshold)
        {
            anim.SetBool(_seePlayer, true);
        }
        else
        {
            anim.SetBool(_seePlayer, false);
        }
    }

    public bool CanSeePlayer()
    {
        return anim.GetBool(_seePlayer);
    }
}
