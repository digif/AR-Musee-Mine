using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.Rendering;

///<summary>
/// The goal of this script is to make the objects color match to the ambient lightning captured by camera
/// To do that, we retrieve the average color of the image produced by the camera and apply it as the ambient light of the scene
/// Please note that depending on which device it is used, this script may decrease significantly the framerate of the app.
/// This script has to be attached to the ARCamera.
///</summary>
public class LightMatching : MonoBehaviour
{
    // Camera image pixel 
    private PIXEL_FORMAT mPixelFormat = PIXEL_FORMAT.UNKNOWN_FORMAT;
    // Boolean telling whether the pixel format has been registered or not
    private bool mFormatRegistered = false;
    // Used for debugging to get color values
    public Text colortext;
    // Boolean used to start debugging 
    public bool debugging;
    // Minimum time in second between each update of the light. It has been set to 1 to preserve performances
    public float waitTime = 1.0f;
    private float timer = 0.0f;



  

    void Start()
    {
        
        // Register Vuforia life-cycle callbacks:
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        // not sure if this is really needed but leaving in just to be safe
        VuforiaARController.Instance.RegisterOnPauseCallback(OnPause);
        //This behaves much like Update() - Most of the magic happens in OnTrackablesUpdated
        VuforiaARController.Instance.RegisterTrackablesUpdatedCallback(OnTrackablesUpdated);

        //Set  image format to RGB888 for mobiles, a 1 byte per color format (3byte per pixel)
        mPixelFormat = PIXEL_FORMAT.RGB888;
    }
    
    // Called when Vuforia is started    
    private void OnVuforiaStarted()
    {
        // Try to register camera frame format
        if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
        {           
            Debug.Log("Successfully registered pixel format " + mPixelFormat.ToString());
            mFormatRegistered = true;
        }
        else
        {
            Debug.LogError("Failed to register pixel format " + mPixelFormat.ToString());
            mFormatRegistered = false;
        }
        
    }
    /// <summary>
    /// Called when app is paused / resumed
    /// </summary>
    private void OnPause(bool paused)
    {
        if (paused)
        {
            Debug.Log("App was paused");
            UnregisterFormat();
        }
        else
        {
            Debug.Log("App was resumed");
            RegisterFormat();
        }
    }
   
    // Called each time the Vuforia state is updated
    private void OnTrackablesUpdated()
    {
        
        timer += Time.deltaTime;
        if(timer>waitTime) {
            
            timer = 0;
            // If format has been registered
            if (mFormatRegistered)
            {
                // Get Camera image with the specified pixel format                  
                Vuforia.Image image = CameraDevice.Instance.GetCameraImage(mPixelFormat);
                if (image != null)
                {
                    //Store all the image information in a byte array
                    byte[] pixels = image.Pixels;
                    if (pixels != null && pixels.Length > 0)
                    {
                        
                        /*Color[] colors = new Color[pixels.Length / 2];
                        if (mPixelFormat == PIXEL_FORMAT.RGB565) {
                                

                            for (var i = 0; i<pixels.Length; i += 2)
                                {
                                colors[i / 2] = new Color((pixels[0] & 0x1f) / (float)0x1f,
                                    ((pixels[1] & 0x07) | ((pixels[0] & 0xe0) >> 5)) / (float)0x3f,
                                    ((pixels[1] & 0xf8) >> 3) / (float)0x1f);

                            }*/
                        }
                        if(mPixelFormat==PIXEL_FORMAT.RGB888) {
                            //Create a color array for which its size corresponds to the number of pixel of the image
                            Color32[] colorArray = new Color32[pixels.Length / 3];
                            for (int i = 0; i < pixels.Length; i += 3)
                            {
                                //Group bytes by 3 (R, G and B) and create a new color for each group
                                Color32 color = new Color32(pixels[i + 0], pixels[i + 1], pixels[i + 2], 255);
                                colorArray[i / 3] = color;
                                    
                                    
                            }
                            //This part get the average color for each component
                            float red = 0;
                            float green = 0;
                            float blue = 0;
                            for (int i = 0; i < colorArray.Length; i++)
                            {

                                red += colorArray[i].r;
                                green += colorArray[i].g;
                                blue += colorArray[i].b;
                            }
                            red /= pixels.Length/4;
                            green /= pixels.Length/4;
                            blue /= pixels.Length/4;

                            // Create this average color
                            Color average = new Color(red/255, green/255, blue/255);
                            
                            //Apply this color as the ambient light
                            RenderSettings.ambientLight = average;


                            //Used for debugging  by getting color values
                            if(debugging)
                            {
                                colortext.text = red + " " + green + " " + blue;
                            }
                                
                                
                        }
                            
                            
                    }
                }
                
            }
        }
    
    
    //Unregister the pixel format
    private void UnregisterFormat()
    {
        Debug.Log("Unregistering camera pixel format " + mPixelFormat.ToString());
        CameraDevice.Instance.SetFrameFormat(mPixelFormat, false);
        mFormatRegistered = false;
    }

    //Unregister all pixel formats
    private void DisableAllFormats()
    {
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.RGBA8888, false);
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.GRAYSCALE, false);
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.RGB565, false);
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.NV12, false);
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.RGB888, false);
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.NV21, false);
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.YUV420P, false);
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.YUYV, false);
        CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.YV12, false);
        


    }
    
    //Register the pixel format
    private void RegisterFormat()
    {
        if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
        {
            Debug.Log("Successfully registered camera pixel format " + mPixelFormat.ToString());
            mFormatRegistered = true;
        }
        else
        {
            Debug.LogError("Failed to register camera pixel format " + mPixelFormat.ToString());
            mFormatRegistered = false;
        }
    }
}
