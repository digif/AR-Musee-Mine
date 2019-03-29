using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class QuitApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void QuitApplication()
    {
        Application.Quit();

    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
}
