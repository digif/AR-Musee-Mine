using UnityEngine;
using UnityEngine.SceneManagement;


public class GoBack : MonoBehaviour
{
    public bool backChangeScene = false;
    public string targetScene;
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
