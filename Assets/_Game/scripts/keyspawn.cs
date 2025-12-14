using UnityEngine;

public class keyspawn : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject SpawnToObject;
    public GameObject SpawnToObject1;
    public GameObject SpawnToObject2;
    public GameObject SpawnToObject3;
    public GameObject SpawnToObject4;
    public GameObject trigger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("keyspawner"))
        {
            Destroy(trigger);
            Instantiate(ObjectToSpawn, SpawnToObject.transform.position, Quaternion.identity);
            Instantiate(ObjectToSpawn, SpawnToObject1.transform.position, Quaternion.identity);
            Instantiate(ObjectToSpawn, SpawnToObject2.transform.position, Quaternion.identity);
            Instantiate(ObjectToSpawn, SpawnToObject3.transform.position, Quaternion.identity);
            Instantiate(ObjectToSpawn, SpawnToObject4.transform.position, Quaternion.identity);
        }
    }

}
