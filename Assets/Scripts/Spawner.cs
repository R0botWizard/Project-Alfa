using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject entity;
    private GameObject thisEntity;
    private bool canSpawn;
    private void Start()
    {
        thisEntity = null;
        canSpawn = true;
    }
    private void Update()
    {
        SpawnEntity();
        SpawnFrequencyIncrement();
    }

    
    private void SpawnEntity()
    {
        StartCoroutine(RespawnTimer(spawnDelay));
    }

    private IEnumerator RespawnTimer(float delay)
    {
        if (thisEntity == null && canSpawn)
        {
            canSpawn = false;
            yield return new WaitForSeconds(delay);
            thisEntity = Instantiate(entity, this.transform.position, Quaternion.identity);
            canSpawn = true;
        }
    }

    private void SpawnFrequencyIncrement()
    {

    }


}
