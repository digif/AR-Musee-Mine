using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.Rendering;


/*       *************************** HOW TO USE **********************************

    Just Attach to your AR camera or Create an empty GameObject in your scene and attach this script
    Most likely you'll have at least one light in your sceen. add your light to the public Light To Effect var in the editor.
    You'll need to modify the code if you have more than one light you'd like to affect. 

    To see get dev/debugging readouts create a screen overlay canvas with a couple of text objects. add them to the lightoutput vars in the editor
    
    Can varify that a this light estimation script works in iphone7, Samsung S6, and pixel
    Should also work in the Unity editor as well.

         ***************************   ENJOY!   **********************************

*/
public class LightMatchingCopie : MonoBehaviour
{
    private bool mAccessCameraImage = true;
    // camera image pixel 
    private PIXEL_FORMAT mPixelFormat = PIXEL_FORMAT.UNKNOWN_FORMAT;// or RGBA8888, RGB888, RGB565, YUV, GRAYSCALE
    // Boolean flag telling whether the pixel format has been registered
    private bool mFormatRegistered = false;
    // during development you might want to set up a couple of text objects in a UI screen overlay for debugging
    public Text colortext;
    // boolean used to start debugging 
    public bool debugging;
    //This is the directional light I was using in my scene. 
    
    // This color variable is being used to change the ambient light in the scene. goes from white to black depending on brightness of lights
    // You might want to thake that out depending on how your scene is looking
    private Color lightColor = new Color(1, 1, 1, 1);
    private float ligtColorNum;
    //Use this to make adjustments if your light estimation is looking too bright or too dark.  I don't know what a double is.
    public double intensityModifier = 10.0;
    //Use this to make light temperature adjustments
    public int temperatureModifier = 3000;
    // To be honest I'm not sure what these are for. I cobbled this code from a bunch of different scripts. It's not messing anything up so I'm leaving in 
    public float? intensity { get; private set; }
    public float? colorTemperature { get; private set; }
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
        mPixelFormat = PIXEL_FORMAT.RGB888;
    }
    /// <summary>
    /// Called when Vuforia is started
    /// </summary>
    private void OnVuforiaStarted()
    {
        // Try register camera image format
        if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
        {
            
            Debug.Log("Successfully registered pixel format " + mPixelFormat.ToString());
            mFormatRegistered = true;
        }
        else
        {
            Debug.LogError("Failed to register pixel format " + mPixelFormat.ToString() +
                "\n the format may be unsupported by your device;" +
                "\n consider using a different pixel format.");
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
    /// <summary>
    /// Called each time the Vuforia state is updated
    /// </summary>
    private void OnTrackablesUpdated()
    {
        
        timer += Time.deltaTime;
        if(timer>waitTime) {
            timer = 0;
            if (mFormatRegistered)
            {
                if (mAccessCameraImage)
                {
                    
                    Vuforia.Image image = CameraDevice.Instance.GetCameraImage(mPixelFormat);
                    if (image != null)
                    {

                        string imageInfo = mPixelFormat + " image: \n";
                        imageInfo += " size: " + image.Width + " x " + image.Height + "\n";
                        imageInfo += " bufferSize: " + image.BufferWidth + " x " + image.BufferHeight + "\n";
                        imageInfo += " stride: " + image.Stride;
                        Debug.Log(imageInfo);

                        byte[] pixels = image.Pixels;
                        if (pixels != null && pixels.Length > 0)
                        {
                            Debug.Log("Image pixels: " + pixels[0] + "," + pixels[1] + "," + pixels[2] + ",...");
                            Color[] colors = new Color[pixels.Length / 2];
                            if (mPixelFormat == PIXEL_FORMAT.RGB565) {
                                

                                for (var i = 0; i<pixels.Length; i += 2)
                                 {
                                    colors[i / 2] = new Color((pixels[0] & 0x1f) / (float)0x1f,
                                        ((pixels[1] & 0x07) | ((pixels[0] & 0xe0) >> 5)) / (float)0x3f,
                                        ((pixels[1] & 0xf8) >> 3) / (float)0x1f);

                                }
                            }
                            else {
                                Color32[] colorArray = new Color32[pixels.Length / 3];
                                for (int i = 0; i < pixels.Length; i += 3)
                                {
                                    Color32 color = new Color32(pixels[i + 0], pixels[i + 1], pixels[i + 2],255);//, pixels[i + 3]
                                    colorArray[i / 3] = color;
                                }
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

                            Color average = new Color(red/255, green/255, blue/255);
                            colortext.text = red + " " + green + " " + blue;
                            RenderSettings.ambientLight = average;
                            }
                            

                            
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// Unregister the camera pixel format (e.g. call this when app is paused)
    /// </summary>
    private void UnregisterFormat()
    {
        Debug.Log("Unregistering camera pixel format " + mPixelFormat.ToString());
        CameraDevice.Instance.SetFrameFormat(mPixelFormat, false);
        mFormatRegistered = false;
    }

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
    /// <summary>
    /// Register the camera pixel format
    /// </summary>
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
