using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public static int lives;
    public int startLives = 10;

    public Text livesText;
    public static bool GameIsOver;
    public GameObject gameOverUI;
    
    void Start () {
        lives = startLives;
        GameIsOver = false;
    }
	
	void Update () {
        if (GameIsOver)
            return;

        livesText.text = lives.ToString() + " LIVES";

        if (lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
