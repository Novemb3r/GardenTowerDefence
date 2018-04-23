using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 5f;

    [HideInInspector]
    public float speed;
    public float timeUntilNormSpeed = 0;

    public int startHealth = 100;
    private float health;

    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void SetParams(float startSpeed, int startHealth)
    {
        this.startSpeed = startSpeed;
        this.startHealth = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <=0 )
        {
            Die();
        }
    }

    public void SpeedTick(float deltaTime)
    {
        timeUntilNormSpeed -= deltaTime;
        if (timeUntilNormSpeed<=0)
        {
            speed = startSpeed;
        }
    }
    public void Slow (float pct, float forTime)
    {
        timeUntilNormSpeed = forTime;
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        Destroy(gameObject);
        StatManager.enemyStat++;

    }
}
