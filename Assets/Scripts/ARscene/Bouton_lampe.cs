using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton_lampe : MonoBehaviour
{
    //Script that turns on or off the light of the lamp
    public GameObject lumiere;// This is the light object oof the lamp

    // We detect when the user presses the button with the function OnMouseDown. Depending on the actual state of the light,
    // we then light it up or close it by modifying its intensity. The button has two animations : one that corresponds to its
    // normal state (untouched) and a second one that is launched when the user presses the button. Thanks to the GetComponent
    // method, we can have access to the intensity of the light and we can also have acces to the trigger value which allows us 
    // to launch the animation of the button.

    private void OnMouseDown() {
        if (lumiere.GetComponent<Light>().intensity == 0){
            lumiere.GetComponent<Light>().intensity = 1000;
            gameObject.GetComponent<Animator>().SetTrigger("appui_btn_lampe");//To launch the animation we trigger the variable "appui_btn_lampe".
        }
        else {
            lumiere.GetComponent<Light>().intensity = 0;
            gameObject.GetComponent<Animator>().SetTrigger("appui_btn_lampe");
        }
        
    }
}
