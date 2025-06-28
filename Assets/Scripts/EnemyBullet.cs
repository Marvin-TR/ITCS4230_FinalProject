using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 5;

    [Range(1, 10)]
    [SerializeField] private float lifetime = 15;

    private GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y) * speed;
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bullet(Clone)")
        {
            Destroy(gameObject);
            //Debug.Log("Bullets touched");
        }
    }
}
