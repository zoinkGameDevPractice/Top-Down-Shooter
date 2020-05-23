using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[System.Serializable]
public class Vitality : MonoBehaviour
{
    public int maxHealth = 20;
    protected int currentHealth;
    public CinemachineVirtualCamera cam;
    CameraShake shake;

    void Awake()
    {
        currentHealth = maxHealth;
        shake = cam.GetComponent<CameraShake>();
    }

    public virtual void TakeDamage(int damage)
    {
        //shake.smallShake = true;
        currentHealth = currentHealth - damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        shake.bigShake = true;
    }
}
