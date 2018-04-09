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
[RequireComponent(typeof(Collider2D))]
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
        myCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	void Update ()
    {
        move();
        checkState();
	}

    // move the player
    void move()
    {
        // get inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // update movement
        movement = new Vector2(horizontal * playerSettings.moveSpeed * Time.deltaTime, 0);

        // apply movement to rigidbody
        rb.AddForce(movement, ForceMode2D.Force);
    }

    // check the state of the player
    void checkState()
    {
        // flip sprite if neccesary
        if(movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0;
        }

        // check if the player is walking
        walking = (movement.x != 0);

        // check if the player is standing on something
        hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.25f);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.25f, Color.green);
        jumping = (hitInfo.collider == null);

        // check if the player is pushing a block
        hitInfo = Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(movement.x), 0.25f);
        Debug.DrawLine(transform.position, transform.position + Vector3.right * 0.25f, Color.red);
        pushing = hitInfo.collider != null;

        // update sprite animations
        GetComponent<Animator>().SetBool("jumping", jumping);
        GetComponent<Animator>().SetBool("walking", walking);
        GetComponent<Animator>().SetBool("pushing", pushing);
    }
}
