using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour {

        public Transform target;
        public Vector3 originalVector;
        public Vector3 reflectedVector;
        public float speed;
        public float dist;
        private Vector3 vec;
        private RaycastHit hit;
        private int rayDistance = 10;

        // Specify the target for the enemy.

        void Update()
        {

            float step = speed * Time.deltaTime;
            Vector3 pos = target.position - transform.position;


            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = rotation;
            transform.LookAt(target.position);

            Debug.DrawLine(transform.position, target.position, Color.yellow);
            
            Distance();
             


            
        if (Physics.Raycast(transform.position, transform.forward, 20, rayDistance))
        {
            Debug.DrawLine(transform.position, target.position, Color.red);
            transform.position += hit.normal;

        }
        }

        void Distance()
        {
            if (target)
            {
                dist = Vector3.Distance(target.position, transform.position);
                print("Distance to other: " + dist);

            }
        }

    }
