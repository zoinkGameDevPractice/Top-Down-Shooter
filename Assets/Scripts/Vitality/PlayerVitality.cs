using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitality : Vitality
{
    public HealthBar healthBar;
    public AudioSource hitSource;
    public AudioSource deathSource;

    public float deathDelay = 1f;
    SceneManagement scene;

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        scene = SceneManagement.instance;
        TimeManager.instance.onFinishedTimeStop += Restart;
    }

    public override void TakeDamage(int damage)
    {
        hitSource.Play();
        base.TakeDamage(damage);
        healthBar.SetHealth(currentHealth);
    }

    public override void Die()
    {
        base.Die();
        //Effect
        deathSource.Play();
        StartCoroutine(TimeManager.instance.StopTime());
    }

    void Restart()
    {
        scene.RestartScene();
    }
}
