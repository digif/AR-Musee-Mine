using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    public AudioSource ss;
    private string nom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        nom = gameObject.name;
        
        switch(nom){
            case "bouton1":
                break;
            default:
                break;
        }
        if(gameObject.name == "bouton1"){

        }
        gameObject.GetComponent<Animator>().SetTrigger("btn1_Pushed");
        ss.Play();
    }
}
