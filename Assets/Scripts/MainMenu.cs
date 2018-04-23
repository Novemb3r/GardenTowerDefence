using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string mainScene = "MainScene";
    public string infoScene = "InfoMenu";
    public Scene MainScene;
    public void Play()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void Info()
    {
        SceneManager.LoadScene(infoScene);
    }
}
