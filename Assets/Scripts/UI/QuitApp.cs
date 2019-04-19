using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// handles ways to quit the application
public class QuitApp : MonoBehaviour
{
    // no current use
    // allow the creation of an on-screen quit app button
    public void QuitApplication()
    {
        Application.Quit();
    }
    
    // Update is called once per frame
    // handle quitting app when pressing the hardware back button
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
