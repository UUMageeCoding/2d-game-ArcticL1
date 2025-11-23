using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    private Vector2 input;

    Animator anim;
    private Vector2 lastMoveDirection;
    private bool faceingLeft = true;

    public Transform Aim;
    bool iswalking = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        ProccessInputs();
        Animate();
        if (input.x < 0 && !faceingLeft || input.x > 0 && faceingLeft)
        {
            Flip();
        }
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed * Time.fixedDeltaTime;    
        if (iswalking)
        {

            Vector3 vector3 = Vector3.left * input.x + Vector3.down * input.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    void ProccessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && (input.x !=0 || input.y !=0))
        {
            iswalking = false;
            lastMoveDirection = input;
            Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
        else if (moveX != 0 || moveY != 0)
        {
                iswalking = true;
        }
        

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
    }

    void Animate()
    {
        anim.SetFloat("MoveX", input.x);  
        anim.SetFloat("MoveY", input.y);  
        anim.SetFloat("MoveMagnitude", input.magnitude); 
        anim.SetFloat("LastMoveX", lastMoveDirection.x); 
        anim.SetFloat("LastMoveY", lastMoveDirection.y);    
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        faceingLeft = !faceingLeft;
    }

}
