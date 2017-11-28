using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {

    public GameObject spawn;
    // Use this for initialization
    

    public override void OnStartServer()
    {
        GameObject obj = (GameObject)Instantiate(spawn, new Vector3(14f, 3f, 105f), transform.rotation);
        NetworkServer.Spawn(obj);
    }
}
