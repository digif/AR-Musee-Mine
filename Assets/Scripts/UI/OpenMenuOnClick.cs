using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuOnClick : MonoBehaviour
{
    public Text titre;
    public Text description;

    private void Start()
    {
        ObjectsConstants.Initialize();
    }

    // put the description for the object currently looked at when clicking on the info button
    public void OpenMenu()
    {
        bool found = false;

        // get the name of the object currently on screen 
        string currentObject = ModifiedTrackableEventHandler.lastimagename;

        //check that name against all the descriptions, asign the title and description if a match is found
        foreach ( Info element in ObjectsConstants.infos)
        {
            if (currentObject == element.objectName)
            {
                titre.text = element.title;
                description.text = element.description;
                found = true;
            }
        }

        // if a match isn't found, fill the info menu with an error message instead
        // (this message isn't accessible in normal use as the info button only appear if an item is currently active)
        if(found == false)
        {
            titre.text = "Erreur";
            description.text = "Objet introuvable.";
        }
    }
}
