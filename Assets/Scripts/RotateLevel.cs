using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    bool clockwise;
    public bool canRotate = true;
    public bool rotating = false;

    public float degreesToRotate = 90.0f;
    public float lastAngle = 0.0f;
    public float currentAngle = 0.0f;

    public List<GameObject> levelObjects;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        if(rotating)
        {
            currentAngle += degreesToRotate * Time.deltaTime * (clockwise ? 1 : -1) * 2.0f;

            if (clockwise && currentAngle >= (lastAngle + degreesToRotate))
            {
                currentAngle = lastAngle + degreesToRotate;
                lastAngle += degreesToRotate;
                if (lastAngle == 270)
                {
                    currentAngle = -90;
                    lastAngle = -90;
                }

                endRotation();
            }
            else if (!clockwise && currentAngle <= (lastAngle - degreesToRotate))
            {
                currentAngle = lastAngle - degreesToRotate;
                lastAngle -= degreesToRotate;
                if (lastAngle == -270)
                {
                    currentAngle = 90;
                    lastAngle = 90;
                }

                endRotation();
            }

            if (rotating)
            {
                player.transform.localEulerAngles = new Vector3(0, 0, -currentAngle);
            }
            transform.eulerAngles = new Vector3(0, 0, currentAngle);
        }
	}

    // attempts to rotate the level
    public void Rotate(bool clockWise)
    {
        if (canRotate)
        {
            clockwise = clockWise;
            rotating = true;

            // freeze level objects
            foreach (GameObject currentObject in levelObjects)
            {
                if (currentObject.GetComponent<Rigidbody2D>() != null)
                {
                    //currentObject.GetComponent<Rigidbody2D>().simulated = false;
                    currentObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                currentObject.transform.parent = transform;
            }
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.transform.parent = transform;
        }
    }

    void enableRotation()
    {
        canRotate = true;
    }

    void endRotation()
    {
        rotating = false;

        // unfreeze level objects
        foreach (GameObject currentObject in levelObjects)
        {
            if (currentObject.GetComponent<Rigidbody2D>() != null)
            {
                //currentObject.GetComponent<Rigidbody2D>().simulated = true;
                currentObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                currentObject.transform.parent = null;
                currentObject.transform.eulerAngles = new Vector3(0, 0, currentAngle);
            }
        }
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.transform.parent = null;

        // disable this script for a while to prevent repeating
        canRotate = false;
        Invoke("enableRotation", 0.85f);
    }
}
