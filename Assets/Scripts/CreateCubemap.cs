using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubemap : MonoBehaviour
{
    public Camera cam;
    private Cubemap cubemap;
    int count=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(count>500)
        {
            count = 0;
            Renderer rend2 = GameObject.Find("BackgroundPlane").GetComponent<Renderer>();

            Texture2D im = (Texture2D) rend2.material.mainTexture;
            Color[] pixels=im.GetPixels();
            Cubemap c = new Cubemap(554, TextureFormat.RGBA32, false);
            c.SetPixels(pixels, CubemapFace.PositiveX);
            c.SetPixels(pixels, CubemapFace.NegativeX);
            c.SetPixels(pixels, CubemapFace.PositiveY);
            c.SetPixels(pixels, CubemapFace.NegativeY);
            c.SetPixels(pixels, CubemapFace.PositiveZ);
            c.SetPixels(pixels, CubemapFace.NegativeZ);
            // we set the cubemap from the texture pixel by pixel
            c.Apply();
            
            RenderSettings.skybox.SetTexture("_Im", c);
            Debug.Log(RenderSettings.skybox.GetTexture("_Im"));
            //GameObject C1 = GameObject.Find("Grisoumetree");

            //Renderer rend = C1.GetComponent<Renderer>();

            //rend.material.mainTexture = im;

        }
        else
        {
            Debug.Log(count);
        }
        count++;
    }
}
