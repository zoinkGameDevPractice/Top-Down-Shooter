using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVitality : Vitality
{
    public AudioSource deathSource;
    public AudioSource hitSource;
    float deathLength;

    private void Start()
    {
        deathLength = deathSource.clip.length;
    }

    public override void Die()
    {
        //Effect
        deathSource.Play();
        StartCoroutine(DestroyObject());
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        hitSource.Play();
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(deathLength);
        Destroy(gameObject);
    }
}
