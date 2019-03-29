using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fancyScript : MonoBehaviour
{
    public AudioClip[] merica;
    public AudioSource fuckYeah;
    string btnName;

    // Start is called before the first frame update
    void Start()
    {
        fuckYeah = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit)){
                btnName = hit.transform.name;
                switch(btnName){
                    case "fancyButton":
                        fuckYeah.clip = merica[0];
                        fuckYeah.Play();
                        break;
                    case "fancyButton2":
                        fuckYeah.clip = merica[1];
                        fuckYeah.Play();
                        break;
                    case "fancyButton3":
                        fuckYeah.clip = merica[2];
                        fuckYeah.Play();
                        break;
                    case "fancyButton4":
                        fuckYeah.clip = merica[3];
                        fuckYeah.Play();
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
