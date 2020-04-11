using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject Player;
    public Vector3 offset;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
//        Camera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Niemaoczu");
    }


    void Update()
    {
 //       Camera.transform.SetParent(Player.transform.parent);
        transform.position = new Vector3(Player.transform.position.x + offset.x, Player.transform.position.y + offset.y,0); // Camera follows the player with specified offset position
    }
}

