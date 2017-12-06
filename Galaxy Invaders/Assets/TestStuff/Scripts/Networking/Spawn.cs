using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {

    public GameObject spawn;
    public float startTime;
    public float spawntime;
    //public float lifeTime;
    //public float waitForRespawn;
    //private int counter;
    //public static GameObject[] allShips = new GameObject[10];

    // Use this for initialization


    public override void OnStartServer()
    {

            InvokeRepeating("SpawnEnemy", startTime, spawntime);

      
    }

    void SpawnEnemy()
    {
       ////if (counter < 5)
       //// {
       ////     for (int i = 0; i < 10; i++)
       ////     {

                GameObject obj = (GameObject)Instantiate(spawn, transform.position, transform.rotation);
                NetworkServer.Spawn(obj);
                //allShips[i] = obj;

            }
            //Destroy(allShips[counter], lifeTime);
            //counter++;
          
    //    }else
    //    {
    //        new WaitForSeconds(waitForRespawn);
    //        counter = 0;
    //    }
    //}
}
