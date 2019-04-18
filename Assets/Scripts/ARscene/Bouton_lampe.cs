using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton_lampe : MonoBehaviour
{
    //Script qui permet d'allumer la lampe du casque.
    public GameObject lumiere;// Il s'agit de la lampe du casque

    // On detecte l'appui sur le bouton à l'aide de la commande OnMouseDown et en fonction de l'état actuel de la lampe, on
    // l'allume ou on l'éteint en faisant varier son intensité. Nous avons également animé le bouton pour que l'utilisateur
    // aie un feedback en cas d'appui. L'animation se gère avec le composant Animator du bouton.
    private void OnMouseDown() {
        if (lumiere.GetComponent<Light>().intensity == 0){
            lumiere.GetComponent<Light>().intensity = 1000;
            gameObject.GetComponent<Animator>().SetTrigger("appui_btn_lampe");//Pour lancer l'animation on trigger la variable préalablement créée appui_btn_lampe.
        }
        else {
            lumiere.GetComponent<Light>().intensity = 0;
            gameObject.GetComponent<Animator>().SetTrigger("appui_btn_lampe");
        }
        
    }
}
