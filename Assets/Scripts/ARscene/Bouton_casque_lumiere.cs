using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton_casque_lumiere : MonoBehaviour
{
    //Script that turns on or of the light of the

    public GameObject lampe; // This the light source of the helmet.


    // We detect when the user presses the button with the function OnMouseDown. Depending on the actual state of the light,
    // we then light it up or close it by modifying its intensity. The button has two animations : one that corresponds to its
    // normal state (untouched) and a second one that is launched when the user presses the button. Thanks to the GetComponent
    // method, we can have access to the intensity of the light and we can also have acces to the trigger value which allows us 
    // to launch the animation of the button.

    private void OnMouseDown() {
        if (lampe.GetComponent<Light>().intensity == 0){
            lampe.GetComponent<Light>().intensity = 10;
            gameObject.GetComponent<Animator>().SetTrigger("trig_lum_casque");//To launch the animation we trigger trig_lum_casque.
        }
        else {
            lampe.GetComponent<Light>().intensity = 0;
            gameObject.GetComponent<Animator>().SetTrigger("trig_lum_casque");
        }
    }
}
