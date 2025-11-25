using UnityEngine;
using UnityEngine.Rendering;

public class newplayermov : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;

    
   
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horisontal");
        float vertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2 (horizontal, vertical) *speed;
    }
}
