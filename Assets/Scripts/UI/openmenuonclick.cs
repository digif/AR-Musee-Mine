using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openmenuonclick : MonoBehaviour
{
    public Text titre;
    public Text description;

    // Méthode qui permet d'afficher une description de l'objet qui est en cours de visualisation. Elle est lancée quand
    // quand un objet apparaît.
    public void openMenu()
    {
        //La méthode switch va vérifier le nom de l'objet affiché et en fonction de ce nom, il va entrer dans la case correspondante
        //Une fois dans la case, le programme choisit le bon titre et la bonne description depuis la classe ObjectsConstants
        //Le break permet ensuite de sortir du switch
        switch(ModifiedTrackableEventHandler.lastimagename)
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
            case "Image Pelle":
                titre.text = ObjectsConstants.PELLE[0];
                description.text = ObjectsConstants.PELLE[1];
                break;
            case "Image Pioche":
                titre.text = ObjectsConstants.PIOCHE[0];
                description.text = ObjectsConstants.PIOCHE[1];
                break;
            case "Image Casque":
                titre.text = ObjectsConstants.CASQUE[0];
                description.text = ObjectsConstants.CASQUE[1];
                break;
            case "Image Bidon1":
                titre.text = ObjectsConstants.BIDON1[0];
                description.text = ObjectsConstants.BIDON1[1];
                break;
            case "Image Bidon2":
                titre.text = ObjectsConstants.BIDON2[0];
                description.text = ObjectsConstants.BIDON2[1];
                break;
            case "Image Burette1":
                titre.text = ObjectsConstants.BURETTE1[0];
                description.text = ObjectsConstants.BURETTE1[1];
                break;
            case "Image Burette2":
                titre.text = ObjectsConstants.BURETTE2[0];
                description.text = ObjectsConstants.BURETTE2[1];
                break;
            case "Image Burin":
                titre.text = ObjectsConstants.BURIN[0];
                description.text = ObjectsConstants.BURIN[1];
                break;
            case "Image Cle":
                titre.text = ObjectsConstants.CLE[0];
                description.text = ObjectsConstants.CLE[1];
                break;
            case "Image Gourde":
                titre.text = ObjectsConstants.GOURDE[0];
                description.text = ObjectsConstants.GOURDE[1];
                break;
            case "Image Lampe":
                titre.text = ObjectsConstants.LAMPE[0];
                description.text = ObjectsConstants.LAMPE[1];
                break;
            case "Image Pot":
                titre.text = ObjectsConstants.POT[0];
                description.text = ObjectsConstants.POT[1];
                break;
            default :
                titre.text = "Erreur";
                description.text = "Objet introuvable.";
                break;
        }
    }
}
