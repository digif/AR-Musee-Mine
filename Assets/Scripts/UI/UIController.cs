using UnityEngine;
using UnityEngine.SceneManagement;

// controller for UI menus, there's one per menu, situated in that menu's canvas
public class UIController : MonoBehaviour
{
    // activate another menu in the scene and deactivate the current menu
    public void GoToMenu (GameObject targetMenu)
    {
        targetMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
    // load another scene
    public void GoToScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
