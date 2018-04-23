using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WoofPug : MonoBehaviour {

    protected Enemy targetEnemy;

    [Header("Property")]
    public float range = 15f;
    public int cost = 10;

    [Header("Animation")]
    public GameObject SpriteObject;
    private Animator objAnim;

    public int damageOverTime = 30;

    [Header("Use Pizza (default)")]
    public GameObject bulletPrefab;
    //public AudioSource shootSound;
    public float slowPct = .5f;
    
    [Header("Unity Setup Fields")]
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public string enemyTag = "Enemy";
    public Transform firePoint;
    
    private bool haveTarget;
    private GameObject platform;
    private SimpleSonarShader_Object sonar;
    // Use this for initialization
    void Start()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Grass");
        float shortest = Mathf.Infinity;
        foreach (GameObject p in platforms)
        {
            float distanceToP = Vector3.Distance(transform.position, p.transform.position);
            if (distanceToP < shortest)
            {
                shortest = distanceToP;
                platform = p;
            }
        }
        //platform.AddComponent<SimpleSonarShader_Object>();
        sonar = platform.GetComponent<SimpleSonarShader_Object>();
        objAnim = SpriteObject.GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        haveTarget = false;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < range)
            {
                DoSlowDamage(enemy);
                haveTarget = true;
            }
        }
        if (haveTarget)
        {
            //shootSound.Play();
        }
    }

    void Update()
    {
        if (!haveTarget)
        {
            return;
        }
        if (!objAnim.GetBool("Attack2"))
        {
            sonar.StartSonarRing(platform.transform.position, 30 / 10.0f);
            objAnim.SetBool("Attack2", true);
        }
    }
    void DoSlowDamage(GameObject enemy)
    {
        Enemy t = enemy.GetComponent<Enemy>();
        t.Slow(slowPct, 1);
        t.TakeDamage(damageOverTime * Time.deltaTime);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
