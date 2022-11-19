using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;// the Position, rotation and scale of an object.


    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y,transform.position.z); // Camera follows the player with specified offset position
    }
}
