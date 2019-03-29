using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openmenuonclick : MonoBehaviour
{
    private Canvas canvas;
    public Text titre;
    public Text description;
    // Start is called before the first frame update
    void Start()
    {
       canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void openMenu()
    {
        
        switch(DefaultTrackableEventHandler.lastimagename)
        {
            case "Image Briquet":
                titre.text = ObjectsConstants.BRIQUET[0];
                description.text = ObjectsConstants.BRIQUET[1];
                break;
            case "Image Grisoumetre":
                titre.text = ObjectsConstants.GRISOUMETRE[0];
                description.text = ObjectsConstants.GRISOUMETRE[1];
                break;
            case "Image Genephone":
                titre.text = ObjectsConstants.GENEPHONE[0];
                description.text = ObjectsConstants.GENEPHONE[1];
                break;
            case "Image Chaussures":
                titre.text = ObjectsConstants.CHAUSSURES[0];
                description.text = ObjectsConstants.CHAUSSURES[1];
                break;
            case "Image Lampisterie":
                titre.text = ObjectsConstants.LAMPISTERIE[0];
                description.text = ObjectsConstants.LAMPISTERIE[1];
                break;
            


        }
        canvas.enabled=true;
    }
}
