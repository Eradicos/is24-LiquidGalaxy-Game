using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidence : MonoBehaviour {

    public int range;
    public float speed;
    private bool isThereAnyThing = false;
    // Specify the target for the enemy.
    private GameObject target;
    private float rotationSpeed;
    private RaycastHit hitR, hitL;
    private Vector3 RotationL;

    

    // Use this for initialization
    void Start()
    {
      
        target = GameObject.Find("PlayerController");
        rotationSpeed = 30;
        print("Target: " + target.name);
        RotationL = Vector3.up * Time.deltaTime * rotationSpeed;
}
    // Update is called once per frame
    void Update()
    {
       
        //Look At Somthly Towards the Target if there is nothing in front.
        if (!isThereAnyThing)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
        // Enemy translate in forward direction.
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //Checking for any Obstacle in front.
        // Two rays left and right to the object to detect the obstacle.
        Transform leftRay = transform;
        Transform rightRay = transform;



        //Use Phyics.RayCast to detect the obstacle

        if (Physics.Raycast(leftRay.position + (transform.right * 7), transform.forward, out hitL, range))
        {
            if (hitL.collider.gameObject.CompareTag(Tags.Obstacle))
            {

                isThereAnyThing = true;
                transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);

            }
        }
        if (Physics.Raycast(rightRay.position - (transform.right * 7), transform.forward, out hitR, range))
        {
            if (hitR.collider.gameObject.CompareTag(Tags.Obstacle))
            {

                isThereAnyThing = true;
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
      
            }
        }

        // Now Two More RayCast At The End of Object to detect that object has already pass the obsatacle.
        // Just making this boolean variable false it means there is nothing in front of object.
        if (Physics.Raycast(transform.position - (transform.forward * 4), transform.right, out hitL, 10) ||
         Physics.Raycast(transform.position - (transform.forward * 4), -transform.right, out hitL, 10))
        {
            if (hitL.collider.gameObject.CompareTag(Tags.Obstacle))
            {
                isThereAnyThing = false;
            }
        }
        // Use to debug the Physics.RayCast.
        Debug.DrawRay(transform.position + (transform.right * 7), transform.forward * 20, Color.red);
        Debug.DrawRay(transform.position - (transform.right * 7), transform.forward * 20, Color.red);
        Debug.DrawRay(transform.position - (transform.forward * 4), -transform.right * 20, Color.yellow);
        Debug.DrawRay(transform.position - (transform.forward * 4), transform.right * 20, Color.yellow);
    }
}
