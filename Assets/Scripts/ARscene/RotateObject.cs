using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///<summary>
/// Script allowing to rotate objects by draging on the screen
/// This script should be attached to each object which needs this feature. The object in question should have a collider defined.
/// </summary>
public class RotateObject : MonoBehaviour
{
    // The ARCamera which will give the reference frame for the rotation
    Transform cam;
    // Intensity of rotation
    float rotspeed = 3;

    private void Start()
    {
        cam = Camera.main.transform;
    }


    // Called everytime a click is detected or hold
    void OnMouseDrag()
    {
        // Convert input movement on X and Y into a rotation angle
        float rotX = Input.GetAxis("Mouse X") * rotspeed ;
        float rotY = Input.GetAxis("Mouse Y") * rotspeed ;  
        //Apply the rotation to the object
        transform.Rotate(cam.up, -rotX, Space.World);
        transform.Rotate(cam.right, rotY,Space.World);      
    }
}
