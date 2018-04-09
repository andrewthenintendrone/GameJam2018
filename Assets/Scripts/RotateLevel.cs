using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    public bool rotating = false;

    public float degreesToRotate = 90.0f;
    public float lastAngle = 0.0f;
    public float currentAngle = 0.0f;
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space) && !rotating)
        {
            rotating = true;
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
            }

            transform.eulerAngles = new Vector3(0, 0, currentAngle);
        }
	}
}
