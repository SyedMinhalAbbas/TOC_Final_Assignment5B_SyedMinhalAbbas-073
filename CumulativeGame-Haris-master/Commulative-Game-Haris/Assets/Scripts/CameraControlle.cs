using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlle : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start() // for camera setting  there is initialize the offset for which used before starting game that helpful for reset the camera position starting the game
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()// It used where the player move get the position of that location ad the offset value and assigned the transform.position. 
    {
        transform.position = offset + player.transform.position;
    }
}
