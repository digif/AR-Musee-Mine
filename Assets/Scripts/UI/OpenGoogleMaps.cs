using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class OpenGoogleMaps : MonoBehaviour
{
    public Text LogField;                                       // Text field use for debug.

    public static string log = "";                              // Text which will appear in LogField.

   protected void Start()
    {
        LogField.text = "";
    }

    protected void Update()
    {   // In each update, the script will add the log string in the log field and clean the log string.
        if (log != "")
        {
            LogField.text += log;
            log = "";
        }
    }
    public void Test(){
        StartCoroutine(Open());
    }

    IEnumerator Open(){

        if(!Permission.HasUserAuthorizedPermission(Permission.FineLocation)){
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        //yield return new WaitForSeconds(3);

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser){
            Debug.Log("User has not enabled GPS");
            log += "User has not enabled GPS\n";
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            log += "Timed out\n";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            log += "Unable to determine device location\n";
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            log += "Works\n";
            //Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            Application.OpenURL("https://www.google.com/maps?saddr="+Input.location.lastData.latitude+","+Input.location.lastData.longitude+"&daddr=Arenberg+Creative+Mine");
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }

    IEnumerator StartLocationService()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser){
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
        
    }
}
