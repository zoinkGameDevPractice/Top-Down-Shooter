using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Hit effect
        Vitality other = collision.collider.gameObject.GetComponent<Vitality>();
        if (other != null)
            other.TakeDamage(damage);
        Destroy(gameObject);
    }
}
