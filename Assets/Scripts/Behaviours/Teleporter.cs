using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    SceneManagement sm;
    public float teleportDelay = 0.5f;

    private void Start()
    {
        sm = SceneManagement.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sm.Invoke("NextScene", teleportDelay);
        }
    }
}
