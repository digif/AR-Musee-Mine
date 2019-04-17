using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton_lampe : MonoBehaviour
{
    public GameObject lumiere;
    private void OnMouseDown() {
        if (lumiere.GetComponent<Light>().intensity == 0){
            lumiere.GetComponent<Light>().intensity = 1000;
            gameObject.GetComponent<Animator>().SetTrigger("appui_btn_lampe");
        }
        else {
            lumiere.GetComponent<Light>().intensity = 0;
            gameObject.GetComponent<Animator>().SetTrigger("appui_btn_lampe");
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
