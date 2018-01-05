using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour {

    public GameObject target;
    public float speed = 5;
    public static Vector3 relativePos;

    private void Start()
    {
        
    }



    void Update()
    {

       
        relativePos = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }

    

    }
