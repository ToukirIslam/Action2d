using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 4f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D player;
    BoxCollider2D feet;
    SpriteRenderer playersp;
    Animator animat;
    [SerializeField] GameObject bullet;
    public bool grounded = false;
    float gravityScaleAtFirst;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playersp = GetComponentInChildren<SpriteRenderer>();
        animat = GetComponentInChildren< Animator > ();
        feet = GetComponent<BoxCollider2D>();
        gravityScaleAtFirst = player.gravityScale;
    }
    void Update()
    {
        Movement();
        Climb();
        Shoot();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Climb();
    }
    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        SpriteFlipper(horizontal);
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.velocity = new Vector2(player.velocity.x,jumpSpeed);
        }
        player.velocity = new Vector2(horizontal * speed, player.velocity.y);
    }
    void SpriteFlipper(float horizontal)
    {
        if (horizontal > 0)
        {
            playersp.flipX = false;
        }
        if(horizontal < 0)
        {
            playersp.flipX = true;
        }
    }
    void Climb()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ladder"))) 
        {
            player.gravityScale = gravityScaleAtFirst;
            return; 
        }
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * climbSpeed;
        Vector2 climbVelocity = new Vector2(player.velocity.x, vertical);
        player.velocity = climbVelocity;
        player.gravityScale = 0f;
        var newYPos = transform.position.y + vertical;
        transform.position = new Vector2(transform.position.x, newYPos);
    }
    void Shoot()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Backgroung"))) { return; }
        if (Input.GetMouseButtonDown(0))
        {
          GameObject bulletFIred =   Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            bulletFIred.transform.position = new Vector2(bulletSpeed, player.transform.position.y);
        }
    }
}
