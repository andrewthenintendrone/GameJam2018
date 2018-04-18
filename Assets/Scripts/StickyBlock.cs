using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StickyBlock : MonoBehaviour
{
    [Tooltip("how long blocks should stick on for")]
    public float stickTime = 3.0f;

    private GameObject stuckObject = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        // don't freeze the player
        if (stuckObject == null && other.tag != "Player")
        {
            stuckObject = other.gameObject;
            stuckObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Invoke("releaseObject", stickTime);
        }
    }

    // releases the object
    void releaseObject()
    {
        stuckObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        stuckObject = null;
    }
}
