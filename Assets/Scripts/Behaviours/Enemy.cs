using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float lookRadius = 5f;
    public float stoppingDistance = 3f;
    public float speed = 5f;

    private bool move = false;
    private Vector2 movement;
    private Vector2 direction;

    public float fireRate = 1f;
    private float fireCooldown = 0;
    public float bulletForce = 15f;

    PlayerManager pm;
    public Rigidbody2D rb;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private void Start()
    {
        pm = PlayerManager.instance;
    }

    private void Update()
    {
        Vector2 playerPos = pm.player.transform.position;
        direction = playerPos - (Vector2)transform.position;
        float playerDistance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        if (playerDistance <= lookRadius)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            move = true;
            if (playerDistance <= stoppingDistance)
            {
                move = false;
                Shoot();
            }
        }
        else
            move = false;
    }

    private void FixedUpdate()
    {
        if (move)
        {
            Move();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }


    void Shoot()
    {
        fireCooldown -= Time.deltaTime;
        if(fireCooldown <= 0)
        {
            fireCooldown = 1f / fireRate;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        direction.Normalize();
        movement = direction;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }
}
