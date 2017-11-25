using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject target;
    private int xOffset;
    private int zOffset;

    Transform mainCamera;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("PlayerController");
        xOffset = (int) (transform.position.x - target.transform.position.x);
        zOffset = (int)(transform.position.z - target.transform.position.z);

        mainCamera = Camera.main.transform;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.transform.position.x + xOffset, target.transform.position.y, target.transform.position.z + zOffset);
        transform.rotation = target.transform.rotation;

        MoveCamera();
	}

    void MoveCamera()
    {
        mainCamera.position = transform.position;
        mainCamera.rotation = transform.rotation;
    }
}
