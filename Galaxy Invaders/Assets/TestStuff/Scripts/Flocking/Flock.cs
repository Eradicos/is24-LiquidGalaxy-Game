using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    private float speed;
    public float speed2;
    public float speed3;
    float rotationSpeed = 0.75f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    Vector3 relativePosition;
    float neighbourDistance = 15.0f;
    bool turning = false;
    private GameObject target;


    private bool isThereAnyThing = false;
    private float rotationSpeed2;
    public int range;
    private RaycastHit hitR, hitL;

    void Start () {

        speed = Random.Range(speed2, speed3);
        target = GameObject.Find("Sphere");
        rotationSpeed2 = 30;


    }


    void Update()
    {

        float x = Random.Range(-75, 75);
        float y = Random.Range(-400, 400);
        float z = Random.Range(-75, 75);


        if (!isThereAnyThing)
        {
            if (Vector3.Distance(transform.position, SteeringBehaviour.relativePos) >= GlobalFlock.tanksize)
            {
                turning = true;
            }
            else
            {
                turning = false;
            }

            if (turning)
            {


                relativePosition = new Vector3(x, y, z);

                Vector3 direction = target.transform.position + (SteeringBehaviour.relativePos + relativePosition) - transform.position;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((direction)), rotationSpeed * Time.deltaTime);
                speed = Random.Range(50f, 100);

                transform.Translate(Vector3.forward * Time.deltaTime * speed);

            }
            else
            {
                if (Random.Range(0, 5) < 1)
                {
                    applyRules();

                }

                transform.Translate(0, 0, Time.deltaTime * speed);

            }

        }
        //Ausweichen

        Transform leftRay = transform;
        Transform rightRay = transform;



        //Use Phyics.RayCast to detect the obstacle

        if (Physics.Raycast(leftRay.position + (transform.right * 7), transform.forward, out hitL, range))
        {
            if (hitL.collider.gameObject.CompareTag(Tags.Obstacle))
            {

                //isThereAnyThing = true;
                transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed2);
              
            }
        }
        if (Physics.Raycast(rightRay.position - (transform.right * 7), transform.forward, out hitR, range))
        {
            if (hitR.collider.gameObject.CompareTag(Tags.Obstacle))
            {

                //isThereAnyThing = true;
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed2);
               
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
        //Debug.DrawRay(transform.position + (transform.right * 7), transform.forward * 20, Color.red);
        //Debug.DrawRay(transform.position - (transform.right * 7), transform.forward * 20, Color.red);
        //Debug.DrawRay(transform.position - (transform.forward * 4), -transform.right * 20, Color.yellow);
        //Debug.DrawRay(transform.position - (transform.forward * 4), transform.right * 20, Color.yellow);
    }




    void applyRules()
    {
        GameObject[] gos;
        gos = GlobalFlock.allEnemys;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 4.5f;
        Vector3 goalPos = SteeringBehaviour.relativePos;
        float dist;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
                {
                dist = Vector3.Distance(go.transform.position, this.transform.position);

                if (dist <= neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if (dist < 20.0)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }

            }
        }

        if (groupSize > 0)
        {
            vcenter = vcenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;
            Vector3 direction = (vcenter + vavoid - transform.position);

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }
        }
    }
}
