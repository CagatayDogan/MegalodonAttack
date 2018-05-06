using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxigenSpawnerScript : MonoBehaviour {

    public GameObject oxygen;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(-4f, 4f);
            whereToSpawn = new Vector2(transform.position.x, randY);
            Instantiate(oxygen, whereToSpawn, Quaternion.identity);
        }
    }
}
