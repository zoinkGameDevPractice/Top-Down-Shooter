using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandom : MonoBehaviour
{
    public List<GameObject> spawn = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject toSpawn = spawn[Random.Range(0, spawn.Count)];
        Instantiate(toSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
