using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {

    public GameObject spawn;
    public float spawntime;
    public float lifeTime;
    private int counter;
    // Use this for initialization
    

    public override void OnStartServer()
    {
   
            InvokeRepeating("SpawnEnemy", spawntime, spawntime);
      
    }

    void SpawnEnemy()
    {
        GameObject obj = (GameObject)Instantiate(spawn, transform.position, transform.rotation);
        NetworkServer.Spawn(obj);
        Destroy(obj, lifeTime);
    }
}
