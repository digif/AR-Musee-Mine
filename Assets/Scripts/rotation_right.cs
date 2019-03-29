using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class rotation_right : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject trumpy;
    public GameObject buttonlol;
    //private VirtualButtonBehaviour vb;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //trumpy.GetComponent<Transform>().Rotate(0,5,0);
        trumpy.SetActive(true);

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        //vb = buttonlol.GetComponent<VirtualButtonBehaviour>();
        buttonlol.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        trumpy = GameObject.Find("trump_lp_Model_fbx2014");
        trumpy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
