using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton_casque_lumiere : MonoBehaviour
{
    public GameObject lampe;
    private void OnMouseDown() {
        if (lampe.GetComponent<Light>().intensity == 0){
            lampe.GetComponent<Light>().intensity = 10;
            gameObject.GetComponent<Animator>().SetTrigger("trig_lum_casque");
        }
        else {
            lampe.GetComponent<Light>().intensity = 0;
            gameObject.GetComponent<Animator>().SetTrigger("trig_lum_casque");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //lampe = GameObject.Find("lumière_casque");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
