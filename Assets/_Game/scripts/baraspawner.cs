using UnityEngine;

public class baraspawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject SpawnToObject;
    public GameObject Baratrigger;
    audiomanager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BaraTrigger"))
        {
            Instantiate(ObjectToSpawn, SpawnToObject.transform.position, Quaternion.identity);
            audiomanager.PlaySFX(audiomanager.roar);
            audiomanager.PlayMusic(audiomanager.bossbackground);
            Destroy(Baratrigger);
        }
    }

}