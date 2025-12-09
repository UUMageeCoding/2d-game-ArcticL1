using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject SpawnToObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossTrigger"))
        {
            Instantiate(ObjectToSpawn, SpawnToObject.transform.position, Quaternion.identity);
        }
    }
    
}