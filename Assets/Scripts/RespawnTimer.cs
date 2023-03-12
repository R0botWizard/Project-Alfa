using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTimer : MonoBehaviour
{
    private Collectable _collectable;

    private IEnumerator Respawn(Collider collider,float time)
    {
        yield return new WaitForSeconds(time);
        collider.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Collectable")
        {
            _collectable = collider.GetComponent<Collectable>();
            StartCoroutine(Respawn(collider, _collectable.respawnTime));
        }
        
    }
}
