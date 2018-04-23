using UnityEngine;
using UnityEngine.UI;

public class gold_update : MonoBehaviour {

	// Use this for initialization
    private Text text;
    public int startGold = 15;
    public static int gold;

    void Start () {
        gold = startGold;
        text = GameObject.Find("gold_text").GetComponent<Text>();
    }
    
	void Update () {
        text.text = gold.ToString();
    }
}
