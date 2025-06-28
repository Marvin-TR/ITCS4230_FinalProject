using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject aBullet;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private TextMeshProUGUI aTextMesh;

    private Vector2 mousePos;
    public SpriteRenderer spr;
    public Rigidbody2D rb;
    public float speed = 5;
    bool isGrounded = false;
    public bool canFire = true;
    private float timer = 0;
    public float fireRate;
    private int hitCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        aTextMesh.text = $"Hits: {hitCount}";

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float mouseAngle = MathF.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        
        if (Input.GetKey(KeyCode.D)) 
        {
            rb.linearVelocityX = speed;

        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -speed;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(new Vector2(0,10),ForceMode2D.Impulse);
            //rb.linearVelocityY = speed;
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            speed = 10;
        }
        else 
        {
            speed = 5;
        }
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > fireRate) 
            {
                canFire = true;
                timer = 0;

            }
        }

        if (Input.GetMouseButtonDown(0) && canFire) 
        {
            canFire = false;
            shoot(mouseAngle);
        }


        if (!Input.anyKey) 
        {
            rb.linearVelocityX = 0;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            //Debug.Log("COLLIDED WITH " + collision.collider);
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "EnemyBullet(Clone)")
        {
            updateHits();
        }
    }

    void updateHits() 
    {
        hitCount++;
        aTextMesh.text = $"Hits: {hitCount}";
    }

    public int getHitCount() { return hitCount; }

    public void resetEverything() 
    {
        hitCount = 0;
        aTextMesh.text = $"Hits: {hitCount}";
    }
    private void shoot(float mouseAngle) 
    {
        Instantiate(aBullet, firingPoint.position, Quaternion.Euler(0, 0, mouseAngle));
    }
}
