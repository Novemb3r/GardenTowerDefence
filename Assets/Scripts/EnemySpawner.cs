using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
       public struct WaveDescription
    {
        public float delay;
        public float deltaTime;
        public float speed;
        public int hp;
        public int amount;
        public Transform creep;
    }
    public WaveDescription[] waves;
    public Transform spawnPoint;
    public int hpIncreasePerLoop = 150;
    private float timer = 0;

    private int amountCreepsNow = 0;
    private int waveNumber = 0;
    private int randEnemy;
    private int waveAmount;
    private int loopNum = 1;
    private bool delayLoaded = false;
    void Start()
    {
        waveAmount = waves.Length;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (delayLoaded)
        {
            if (timer >= waves[waveNumber].deltaTime)
            {
                SpawnEnemy();
                timer = 0;
                amountCreepsNow += 1;
                if (amountCreepsNow >= waves[waveNumber].amount)
                {
                    amountCreepsNow = 0;
                    waveNumber += 1;
                    if (waveNumber == waveAmount)
                    {
                        for (int i = 0; i < waveNumber; i++)
                        {
                            if (waves[i].amount == 1)
                                waves[i].hp = (waves[i].hp / 10 + hpIncreasePerLoop* loopNum) * 10;
                            waves[i].hp += hpIncreasePerLoop*loopNum;
                        }
                        waveNumber = 0;
                        loopNum += 1;
                    }
                    timer = 0;
                    delayLoaded = false;
                }
            }
        }
        else
        {
            if (timer > waves[waveNumber].delay)
            {
                delayLoaded = true;
                timer = 0;
            }
        }
    }

    void SpawnEnemy()
    {
        Transform creep = Instantiate(waves[waveNumber].creep, spawnPoint.position, spawnPoint.rotation);
        creep.GetComponent<Enemy>().SetParams(waves[waveNumber].speed, waves[waveNumber].hp);
    }
}