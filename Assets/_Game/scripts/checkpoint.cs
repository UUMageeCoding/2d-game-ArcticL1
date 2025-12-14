using UnityEngine;

public class checkpoint : MonoBehaviour
{
    TrapTrigger gameController;
    public Transform respawnPoint;
    SpriteRenderer SpriteRenderer;
    public Sprite passive, active;
    audiomanager audiomanager;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<TrapTrigger>();
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.UpdateCheckpoint(transform.position);
            audiomanager.PlaySFX(audiomanager.flame);
            SpriteRenderer.sprite = active;
        }

    }
    
}
