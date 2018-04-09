using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
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

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector2(horizontal * playerSettings.moveSpeed * Time.deltaTime, 0), ForceMode2D.Force);
	}
}
