using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {

    [Header("EnemiesStats")]
    public static int enemyStat;
    public int startEnemyStat = 0;
    public Text enemyText;

    [Header("TowersStats")]
    public static int pizzaStat;
    public int startPizzaStat = 0;
    public Text pizzaText;

    public static int fireStat;
    public int startFireStat = 0;
    public Text fireText;

    public static int woofStat;
    public int startWoofStat = 0;
    public Text woofText;

    [Header("FarmStats")]
    public static int tomatoStat;
    public int startTomatoStat = 0;
    public Text tomatoText;

    public static int carrotStat;
    public int startCarrotStat = 0;
    public Text carrotText;

    public static int pumpkinStat;
    public int startPumpkinStat = 0;
    public Text pumpkinText;

    void Start () {
        enemyStat = startEnemyStat;

        pizzaStat = startPizzaStat;
        fireStat = startFireStat;
        woofStat = startWoofStat;

        tomatoStat = startTomatoStat;
        carrotStat = startCarrotStat;
        pumpkinStat = startPumpkinStat;
    }
	
	// Update is called once per frame
	void Update () {
        enemyText.text = enemyStat.ToString() + " ENEMIES";

        pizzaText.text = pizzaStat.ToString() + " PIZZA PUGS";
        fireText.text = fireStat.ToString() + " FIRE PUGS";
        woofText.text = woofStat.ToString() + " WOOF PUGS";

        tomatoText.text = tomatoStat.ToString() + " TOMATOES";
        carrotText.text = carrotStat.ToString() + " CARROTS";
        pumpkinText.text = pumpkinStat.ToString() + " PUMPKINS";
    }
}
