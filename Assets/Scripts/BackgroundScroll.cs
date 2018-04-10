using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float startPositionX;
    public float loopPositionX;
    public float scrollSpeedX;

	void Update ()
    {
        transform.Translate(Vector3.right * scrollSpeedX * Time.deltaTime);

        if(transform.localPosition.x <= loopPositionX)
        {
            transform.localPosition = Vector3.right * startPositionX;
        }
	}
}
