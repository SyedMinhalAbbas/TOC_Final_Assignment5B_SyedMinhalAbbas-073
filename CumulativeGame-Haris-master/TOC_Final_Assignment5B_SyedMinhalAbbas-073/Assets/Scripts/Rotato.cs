using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotato : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);//Applies a rotation of eulerAngles.z degrees around the z axis, eulerAngles.x degrees around the x axis, and eulerAngles.y degrees around the y axis ,rotation is applied around the transform's local axes.
    }
}
//15 is Degrees to rotate around the X axis.30 Degrees to rotate around the Y axis.45 Degrees to rotate around the Z axis.delta time This property provides the time between the current and previous frame.