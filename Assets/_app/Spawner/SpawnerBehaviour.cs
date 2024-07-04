using System;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private GameObject fxToSpawn;
    [SerializeField] private Transform spawnerOrigin;
    [SerializeField] private bool shouldSpawn;

    void Awake()
    {
    }

    void Update()
    {
        if (shouldSpawn)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        var fx = Instantiate(fxToSpawn, spawnerOrigin.position, spawnerOrigin.rotation);
        Instantiate(prefabToSpawn, spawnerOrigin.position, spawnerOrigin.rotation);
        shouldSpawn = false;

        Destroy(fx, 2f);
    }
}
