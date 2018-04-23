using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoMenu : MonoBehaviour {

    public string menuScene = "MainMenu";

    public void OK()
    {
        SceneManager.LoadScene(menuScene);
    }
}
