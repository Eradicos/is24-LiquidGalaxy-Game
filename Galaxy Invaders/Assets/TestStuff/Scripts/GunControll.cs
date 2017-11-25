using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControll : MonoBehaviour {

    public float rotSpeed = 20;
	
	// Update is called once per frame
	void Update () {
        /*
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, rotX);
        transform.RotateAround(Vector3.right, -rotY);
        */
        if (Input.GetButtonDown("Fire1"))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray.direction);
            
            Vector3 mousePos = Input.mousePosition;
            Debug.Log("gun pos: " + transform.position);
            Debug.Log("mouse pos: " + mousePos);
            Debug.DrawRay(transform.position, mousePos, Color.blue);
        }
       
    }
}
