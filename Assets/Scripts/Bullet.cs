using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifetime = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = (transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "EnemyBullet(Clone)")
        {
            Destroy(gameObject);
            //Debug.Log("Bullets touched");
        }
    }
}
