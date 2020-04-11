using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class RotateMap : MonoBehaviour
{
    bool isRotatingRight = false;
    bool isRotatingLeft = false;

    public int speed_of_rotation;
    int i = 1;

    GameObject Middle;
    GameObject Map;
    Button buttonTurnRight;
    Button buttonTurnLeft;

    // Start is called before the first frame update
    void Start()
    {
        Middle = GameObject.Find("Centre");
        Map = GameObject.Find("Map");
		
		buttonTurnRight = GameObject.Find("ButtonTurnRight").GetComponent<Button>();
		buttonTurnRight.onClick.AddListener(delegate {SetIsRotating(ref isRotatingRight); });
        buttonTurnLeft = GameObject.Find("ButtonTurnLeft").GetComponent<Button>();
		buttonTurnLeft.onClick.AddListener(delegate {SetIsRotating(ref isRotatingLeft); });
		
        speed_of_rotation = 2;
    }

    // Update is called once per frame
    void Update()
    {
        TurnRight();
        TurnLeft();
    }
	
	void SetIsRotating(ref bool isRotating)
	{
		isRotating = true;
	}
	
    void TurnRight()
    {
        if (!isRotatingLeft && isRotatingRight)
        {
            Turn(1, ref isRotatingRight);
        }
    }

    void TurnLeft()
    {
        if (!isRotatingRight && isRotatingLeft)
        {
            Turn(-1, ref isRotatingLeft);
        }
    }

    void Turn(int direction, ref bool isRotating)
    {
        isRotating = true;
        Map.transform.RotateAround(Middle.transform.position, Vector3.forward, -direction * speed_of_rotation);
        i++;
        //do full 90 degrees rotation
        if (i > 90 / speed_of_rotation)
        {
            i = 1;
            isRotating = false; //leave loop
        }
    }
}