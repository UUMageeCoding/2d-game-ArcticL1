using UnityEngine;

public class checkpoint : MonoBehaviour
{
    TrapTrigger gameController;
    public Transform respawnPoint;
    SpriteRenderer SpriteRenderer;
    public Sprite passive, active;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<TrapTrigger>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.UpdateCheckpoint(transform.position);
            SpriteRenderer.sprite = active;

        }

    }
    
}
