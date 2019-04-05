using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void GoToMenu (GameObject targetMenu)
    {
        targetMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void GoToScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
