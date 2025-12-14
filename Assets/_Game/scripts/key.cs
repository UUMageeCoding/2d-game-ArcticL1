using UnityEngine;

public class key : MonoBehaviour
{ 
public GameObject gate;
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
            audiomanager.PlaySFX(audiomanager.flame);
            audiomanager.PlaySFX(audiomanager.flame);
            audiomanager.PlaySFX(audiomanager.gate);
            Destroy(gate);
            Destroy(gameObject);
        }
    }

    private void keypoof()
    {
        Keypoofparticlesinstance = Instantiate(Keypoofparticles,  transform.position, Quaternion.identity);
    }
}
