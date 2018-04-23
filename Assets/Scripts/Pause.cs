using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;
    public Text switcher;
    private bool pause = false;
    public void PauseDown()
    {
        if (!pause)
        {
            pause = true;
            switcher.text = "RESUME";
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            pause = false;
            switcher.text = "PAUSE";
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
