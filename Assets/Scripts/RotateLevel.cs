using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
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
		if(Input.GetKeyDown(KeyCode.Space) && !rotating)
        {
            rotating = true;

            // freeze level objects
            foreach(GameObject currentObject in levelObjects)
            {
                if(currentObject.GetComponent<Rigidbody2D>() != null)
                {
                    currentObject.GetComponent<Rigidbody2D>().simulated = false;
                }
                currentObject.transform.parent = transform;
            }
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.transform.parent = transform;
        }

        if(rotating)
        {
            currentAngle += degreesToRotate * Time.deltaTime;

            if(currentAngle >= (lastAngle + degreesToRotate))
            {
                currentAngle = lastAngle + degreesToRotate;
                rotating = false;
                lastAngle += degreesToRotate;
                if(lastAngle == 270)
                {
                    currentAngle = -90;
                    lastAngle = -90;
                }

                // unfreeze level objects
                foreach (GameObject currentObject in levelObjects)
                {
                    if(currentObject.GetComponent<Rigidbody2D>() != null)
                    {
                        currentObject.GetComponent<Rigidbody2D>().simulated = true;
                        currentObject.transform.parent = null;
                        currentObject.transform.eulerAngles = new Vector3(0, 0, currentAngle);
                    }
                }
                player.GetComponent<Rigidbody2D>().simulated = true;
                player.transform.parent = null;
            }

            if(rotating)
            {
                player.transform.localEulerAngles = new Vector3(0, 0, -currentAngle);
            }
            transform.eulerAngles = new Vector3(0, 0, currentAngle);
        }
	}
}
