using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerSettings
    {
        public float moveSpeed;
        public float jumpForce;
        public float health;
    }

    public PlayerSettings playerSettings;
    private Rigidbody2D rb;
    private RaycastHit2D hitInfo;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontal > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.25f);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.25f, Color.red);

        GetComponent<Animator>().SetBool("jumping", hitInfo.collider == null);

        GetComponent<Animator>().SetBool("walking", (rb.velocity.x != 0));

        rb.AddForce(new Vector2(horizontal * playerSettings.moveSpeed * Time.deltaTime, 0), ForceMode2D.Force);
	}
}
