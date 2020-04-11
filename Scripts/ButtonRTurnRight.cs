using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonRTurnRight : MonoBehaviour
{
    public GameObject Map;
    public float angle = 90;
    public GameObject Centre;
    public GameObject Player;

    void Start()
    {
        Map = GameObject.Find("Map");
        Centre = GameObject.Find("Centre");
        Player = GameObject.Find("Niemaoczu");
    }

    public void Turnright()
    {
        //     Map.transform.rotation *= Quaternion.AngleAxis(90, Vector3.forward);
        //      Map.transform.RotateAround(Player.transform.position, Vector3.forward * 10 * Time.deltaTime);
        //       Map.transform.RotateAround(Player.transform.position, Vector3.forward, -angle);
        //   Map.transform.rotation = Quaternion.Lerp(Map.transform.rotation, Quaternion.AngleAxis(90, Vector3.forward), 1);
        /*        var newRotation = Quaternion.LookRotation(transform.position - Player.transform.position, Vector3.forward);
                newRotation.x = 0.0f;
                newRotation.y = 0.0f;*/
        //     transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
        Map.transform.RotateAround(Centre.transform.position, Vector3.forward, -angle);
        Player.transform.RotateAround(Centre.transform.position, Vector3.forward, -angle);
        Player.transform.Rotate(Vector3.forward, angle);

    }
    public void Turnleft()
    {
        Map.transform.RotateAround(Centre.transform.position, Vector3.forward, angle);
        Player.transform.RotateAround(Centre.transform.position, Vector3.forward, angle);
        Player.transform.Rotate(Vector3.forward, -angle);
    }
}