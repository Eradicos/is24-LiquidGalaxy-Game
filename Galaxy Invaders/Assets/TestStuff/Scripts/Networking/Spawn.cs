using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {

    public GameObject spawn;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnStartServer()
    {
        GameObject obj = (GameObject)Instantiate(spawn, transform.position, transform.rotation);
        NetworkServer.Spawn(obj);
    }
}
