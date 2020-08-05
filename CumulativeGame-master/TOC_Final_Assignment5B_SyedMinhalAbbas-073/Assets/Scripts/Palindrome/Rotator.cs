using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    //Update method
    void Update()
    {
        //Rotate the transform
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}