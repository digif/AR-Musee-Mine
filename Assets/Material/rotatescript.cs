using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatescript : MonoBehaviour
{
    public Transform cam;
    float rotspeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDrag()
    {
        
        
        
        float rotX = Input.GetAxis("Mouse X") * rotspeed ;
        float rotY = Input.GetAxis("Mouse Y") * rotspeed ;
        //transform.LookAt(ar_camera.transform);
        //transform.RotateAround(Vector3.right, rotX);
        //transform.RotateAround(Vector3.back, rotY);
        transform.Rotate(cam.up, -rotX, Space.World);
        transform.Rotate(cam.right, rotY,Space.World);
        //transform.Rotate(cam.right*rotX);
    }
}
