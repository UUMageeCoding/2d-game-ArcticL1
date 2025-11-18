using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Rat_Machine: MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _playerDistance = Mathf.Infinity;
    [SerializeField] private float _distanceToPlayerThreshold = 5f;
    public Animator Anim;
    [SerializeField] private float _turnSadChance = 0.001f;
    private const string isupset = "Upset";
    private const string isannoyed = "annoyed";

    private void Awake()
    {
        
    }

        private void Update()
    {
        float invertHappiness = Random.Range(0f, 1f);
        if (invertHappiness > 1 - _turnSadChance)
        {
            Anim.SetBool(isupset, !Anim.GetBool(isupset));
        }
        _playerDistance = (_player.position - transform.position).magnitude;
      
        if (_playerDistance < _distanceToPlayerThreshold)
        {
            Anim.SetBool(isannoyed, true);
        }
        else
        {
            Anim.SetBool(isannoyed, false);
        }
    }

    public bool annoyed()
    {
        return Anim.GetBool(isannoyed);
    }
}
