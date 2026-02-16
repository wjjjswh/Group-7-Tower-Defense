using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    public int Health = 3;
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int patrolDestination = 0;
    private GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    void Update()
    { 
        // Chacks enemy health per frame
        if (Health <= 0)
        {
            Destroy(gameObject);
            gameManager.AddScore(10);
        }

        // Checkpoint logic
        if (patrolDestination >= patrolPoints.Length)
        {
            Destroy(gameObject);
            gameManager.LoseLife();
        }

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < .2f)
        {
                patrolDestination++; 
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage();
        }

        // Destroy enemy when it reaches end
        if (collision.gameObject.tag == "PlayerBase")
        {
            Destroy(gameObject);
            
        }
    }

    // Damage function
    public void TakeDamage()
    {
        Health -= 1;
    }
}
