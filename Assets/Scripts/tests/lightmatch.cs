using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lightmatch : MonoBehaviour
{
    private float timer = 0f;
    public float waitTime = 1f;
    public float intensity = 1f;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = 0;
            Renderer rend2 = GameObject.Find("BackgroundPlane").GetComponent<Renderer>();
            Texture maintex = rend2.material.mainTexture;



            /*byte[] imraw = im.GetRawTextureData();
            Texture2D im2 = new Texture2D(im.width, im.height, TextureFormat.RGBA32,false);
            ImageConversion.LoadImage(im2,imraw,false);
            */

            Texture2D texture2D = new Texture2D(maintex.width, maintex.height, TextureFormat.RGBA32, false);

            RenderTexture currentRT = RenderTexture.active;

            RenderTexture renderTexture = new RenderTexture(maintex.width, maintex.height, 32);
            Graphics.Blit(maintex, renderTexture);

            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();

            RenderTexture.active = currentRT;
            GameObject.Find("Quad").GetComponent<Renderer>().material.mainTexture = texture2D;

            float red = 0;
            float green = 0;
            float blue = 0;
            Color32[] pixels = texture2D.GetPixels32();
            for (int i = 0; i < pixels.Length; i++)
            {
                //Debug.Log(pixels[i].r+", "+pixels[i].g+", "+pixels[i].b);
                red += pixels[i].r;
                green += pixels[i].g;
                blue += pixels[i].b;
            }


            //red += pixels.r;
            //green += pixels.g;
            //blue += pixels.b;


            red /= pixels.Length;
            green /= pixels.Length;
            blue /= pixels.Length;

            Color average = new Color(red/255, green/255, blue/255);
            Debug.Log(red + ", " + green + ", " + blue);
            text.text = texture2D.format+" "+texture2D.filterMode;
            RenderSettings.ambientLight = average;
            RenderSettings.ambientIntensity = intensity;
        }
    }
}
