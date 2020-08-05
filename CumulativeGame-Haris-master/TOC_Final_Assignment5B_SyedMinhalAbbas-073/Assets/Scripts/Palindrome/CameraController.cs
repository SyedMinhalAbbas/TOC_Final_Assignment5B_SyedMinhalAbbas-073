using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //Decleration
    public GameObject player;
    private Vector3 offset;

    //Start method
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //LateUpdate method
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}