using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeColliders : MonoBehaviour
{
    List<BoxCollider2D> colliders = new List<BoxCollider2D>();
    public GameObject colliderParent;


	void Start ()
    {
        foreach(BoxCollider2D currentCollider in gameObject.GetComponents<BoxCollider2D>())
        {
            colliders.Add(currentCollider);
        }

        foreach(BoxCollider2D currentCollider in colliders)
        {
            GameObject newColliderObject = Instantiate(new GameObject(), colliderParent.transform);
            newColliderObject.name = "collider";
            BoxCollider2D newBoxCollider2D = newColliderObject.AddComponent<BoxCollider2D>();
            newBoxCollider2D.size = currentCollider.size * 2;
            newBoxCollider2D.offset = currentCollider.offset * 2;
        }
	}
}
