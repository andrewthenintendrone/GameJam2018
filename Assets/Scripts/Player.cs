using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSettings
{
    public float moveSpeed = 1000;
    public float jumpForce = 100;
    public float health = 5;
}

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    // player settings
    public PlayerSettings playerSettings;

    // component references
    SpriteRenderer spriteRenderer;
    Collider2D myCollider;
    Rigidbody2D rb;
    Animator animator;

    // raycast2d hit info
    private RaycastHit2D hitInfo;

    // current player movement
    private Vector2 movement;

    // is the player walking
    bool walking = false;
    // is the player jumping
    bool jumping = false;
    // is te player pushing
    bool pushing = false;

	void Start ()
    {
        // get references to components
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	void Update ()
    {
        move();
        checkState();
        updateSprite();
    }

    // move the player
    void move()
    {
        // get inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // update movement
        movement = Vector2.zero;
        movement.x = horizontal * playerSettings.moveSpeed * Time.deltaTime;

        if(!jumping && vertical > 0)
        {
            movement.y = playerSettings.jumpForce;
        }

        // apply movement to rigidbody
        rb.AddForce(movement, ForceMode2D.Force);
    }

    // check the state of the player
    void checkState()
    {
        // check if the player is walking
        walking = (movement.x != 0);

        hitInfo = Physics2D.BoxCast(transform.position - Vector3.up * myCollider.bounds.extents.y, new Vector2(myCollider.bounds.size.x, 0.1f), 0, Vector2.zero);
        jumping = hitInfo.collider == null;

        // check if the player is pushing a block
        hitInfo = Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(movement.x), 0.25f);
        Debug.DrawLine(transform.position, transform.position + Vector3.right * 0.25f, Color.red);
        pushing = hitInfo.collider != null && walking;
    }

    // update the player sprite animation
    void updateSprite()
    {
        // flip sprite if neccesary
        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0;
        }

        // jumping takes priority
        if(jumping)
        {
            animator.SetInteger("playerState", 2);
        }
        else
        {
            // pushing > walking
            if(pushing)
            {
                animator.SetInteger("playerState", 3);
            }
            else if(walking)
            {
                animator.SetInteger("playerState", 1);
            }
            else
            {
                animator.SetInteger("playerState", 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Rotate")
        {
            GameObject.FindObjectOfType<RotateLevel>().Rotate();
        }
    }
}
