using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClampNam : MonoBehaviour
{
    public Text nameLabel;
    // Update is called once per frame
    void Update()//This Method is used for UUser interface text placed static when the camera move with the ball basically,It Transforms position from world space into screen space.Screenspace is defined in pixels. The bottom-left of the screen is (0,0); the right-top is (pixelWidth,pixelHeight). The z position is in world units from the camera.
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = namePos;
    }
}
