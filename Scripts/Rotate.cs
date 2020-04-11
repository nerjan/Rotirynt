using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Collections;


public class Rotate : MonoBehaviour
{
    bool isRotatingRight = false;
    bool isRotatingLeft = false;

    public int speed_of_rotation;
    int i = 1;

    GameObject Middle;
    Rigidbody2D rigidBody;
    Collider2D collider;
    Button buttonTurnRight;
    Button buttonTurnLeft;

    // Start is called before the first frame update
    void Start()
    {
        Middle = GameObject.Find("Centre");
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
		
		buttonTurnRight = GameObject.Find("ButtonTurnRight").GetComponent<Button>();
		buttonTurnRight.onClick.AddListener(delegate {SetIsRotating(ref isRotatingRight); });
        buttonTurnLeft = GameObject.Find("ButtonTurnLeft").GetComponent<Button>();
		buttonTurnLeft.onClick.AddListener(delegate {SetIsRotating(ref isRotatingLeft); });
		
        speed_of_rotation = 2;
    }

    // Update is called once per frame
    public void Update()
    {
        TurnRight();
        TurnLeft();
    }

	void SetIsRotating(ref bool isRotating)
	{
		isRotating = true;
	}
	
    public void TurnRight()
    {
        if (!isRotatingLeft && isRotatingRight)
        {
            Turn(1, ref isRotatingRight);
        }
    }
    
    public void TurnLeft()
    {
        if (!isRotatingRight && isRotatingLeft)
        {
            Turn(-1, ref isRotatingLeft);
        }
    }

    void Turn(int direction, ref bool isRotating)
    {
		buttonTurnRight.enabled = false;
		buttonTurnLeft.enabled = false;
        //freez physics
        rigidBody.Sleep();
        collider.isTrigger = true;
        isRotating = true;
        transform.RotateAround(Middle.transform.position, Vector3.forward, -direction * speed_of_rotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, transform.eulerAngles.z + direction * speed_of_rotation), 1);
        i++;
        //do full 90 degrees rotation
        if (i > 90 / speed_of_rotation)
        {
            i = 1;
            isRotating = false; //leave loop
            //unfreez physics
            rigidBody.WakeUp();
            collider.isTrigger = false;
			buttonTurnRight.enabled = true;
			buttonTurnLeft.enabled = true;
        }
    }
}
