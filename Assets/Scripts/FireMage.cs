using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMage : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;
    public int cost = 25;
    public GameObject SpriteObject;
    public Sprite NormalForm = null;
    public Sprite AttackForm = null;
    public  GameObject Particles;
    //public AudioSource shootSound;

    [Header("Use FireLaser")]
    public int damageOverTime = 30;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;
    private Transform targetSphere;
    private Transform sourcePosition;
    void Start()
    {
        Particles = Instantiate(Particles);//GameObject.Find("FireMageFire"));
        targetSphere = Particles.transform.Find("target Sphere");
        Particles.transform.Find("Particle attractor").transform.position = firePoint.position;
        sourcePosition = Particles.transform.Find("Particle attractor").transform;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            //shootSound.Play();
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
            //shootSound.Stop();
        }
    }
    Vector3 zeroScale = new Vector3(0.001f, 0.001f, 0.001f);
    Vector3 normScale = new Vector3(1,1,1);
    void Update()
    {
        if (target == null)
        {
            targetSphere.position = sourcePosition.position;
            Particles.transform.localScale = zeroScale;
            SpriteObject.GetComponent<SpriteRenderer>().sprite = NormalForm;
            return;
        }
        Particles.transform.localScale = normScale;
        SpriteObject.GetComponent<SpriteRenderer>().sprite = AttackForm;
        LockOnTarget();
        FireLaser();

    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void FireLaser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetSphere.position = target.position + 2 * target.forward;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
