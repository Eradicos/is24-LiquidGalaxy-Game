using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Canvas_Net : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (!isServer)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
