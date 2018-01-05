using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    public GameObject enemyPrefab;
    public static int tanksize = 10;
    public static int numEnemys = 25;
    public int randomTanksize;
    public static GameObject[] allEnemys = new GameObject[numEnemys];


	// Use this for initialization
	void Start () {
       
        for(int i = 0; i < numEnemys; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tanksize* randomTanksize, tanksize* randomTanksize),
                                      Random.Range(-tanksize * randomTanksize, tanksize * randomTanksize),
                                      Random.Range(-tanksize * randomTanksize, tanksize * randomTanksize));
            allEnemys[i] = (GameObject)Instantiate(enemyPrefab, transform.position + pos, Quaternion.identity);

        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
