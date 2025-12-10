using UnityEngine;

public class baraspawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject SpawnToObject;
    public GameObject Baratrigger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BaraTrigger"))
        {
            Instantiate(ObjectToSpawn, SpawnToObject.transform.position, Quaternion.identity);
            Destroy(Baratrigger);
        }
    }

}