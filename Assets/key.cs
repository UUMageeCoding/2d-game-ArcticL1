using UnityEngine;

public class key : MonoBehaviour
{ 
public GameObject gate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gate);
            Destroy(gameObject);
        }
    }

}
