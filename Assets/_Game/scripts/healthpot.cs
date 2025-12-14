using System;
using System.Collections;
using UnityEngine;

public class healthpot : MonoBehaviour
{

    [SerializeField] private ParticleSystem Keypoofparticles;
    private ParticleSystem Keypoofparticlesinstance;
    audiomanager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            keypoof();
            audiomanager.PlayMusic(audiomanager.easteregg);
            audiomanager.PlayMusic(audiomanager.easteregg);
            audiomanager.PlayMusic(audiomanager.easteregg);
            audiomanager.PlayMusic(audiomanager.easteregg);
            audiomanager.PlayMusic(audiomanager.easteregg);
            Destroy(gameObject);
        }
    }
    private void keypoof()
    {
        Keypoofparticlesinstance = Instantiate(Keypoofparticles, transform.position, Quaternion.identity);
    }
}

