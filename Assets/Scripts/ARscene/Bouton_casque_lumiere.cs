using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton_casque_lumiere : MonoBehaviour
{
    //Script qui permet d'allumer la lampe du casque.

    public GameObject lampe; // Il s'agit de la lampe du casque

    // On detecte l'appui sur le bouton à l'aide de la commande OnMouseDown et en fonction de l'état actuel de la lampe du casque,
    // on l'allume ou on l'éteint en faisant varier son intensité. Nous avons également animé le bouton pour que l'utilisateur
    // aie un feedback en cas d'appui. L'animation se gère avec le composant Animator du bouton.

    private void OnMouseDown() {
        if (lampe.GetComponent<Light>().intensity == 0){
            lampe.GetComponent<Light>().intensity = 10;
            gameObject.GetComponent<Animator>().SetTrigger("trig_lum_casque");//Pour lancer l'animation on trigger la variable préalablement créée trig_lum_casque.
        }
        else {
            lampe.GetComponent<Light>().intensity = 0;
            gameObject.GetComponent<Animator>().SetTrigger("trig_lum_casque");
        }
    }
}
