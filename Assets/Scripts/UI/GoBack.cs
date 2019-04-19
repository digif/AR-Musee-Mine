using UnityEngine;
using UnityEngine.SceneManagement;


// handle going back to the parent menu or scene when pressing the hardware back button
// parent menu or scene must be specified in parameters
// situated on every UI canvas (except the main menu one where it is replaced by QuitApp)
public class GoBack : MonoBehaviour
{
    //is the parent menu in another scene
    public bool backChangeScene = false;

    // if no, activate parent menu and deactivate this one
    public string targetScene;
 
    // if yes, load parent scene
    public GameObject targetMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (backChangeScene)
            {
                SceneManager.LoadScene(targetScene);
            }
            else
            {
                targetMenu.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
