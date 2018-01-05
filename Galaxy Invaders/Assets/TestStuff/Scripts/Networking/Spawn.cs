using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {

    public GameObject spawn;
    public float startTime;
    public float spawntime;
    public float lifeTime;
    private GameObject obj;
    public static GameObject[] allShips = new GameObject[10];




    private void OnEnable()
    {

            InvokeRepeating("SpawnEnemy", startTime, spawntime);

      
    }

    private void OnDisable()
    {
        print("Script Offline");
        CancelInvoke();

    }

    private void Update()
    {
            Destroy(obj, lifeTime);
    
    }

    void SpawnEnemy()
    {
        
            obj = (GameObject)Instantiate(spawn, transform.position, transform.rotation);
            NetworkServer.Spawn(obj);
      
    }
}
