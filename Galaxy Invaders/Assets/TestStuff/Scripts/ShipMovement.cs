using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public GameObject target;
    private PlayerMovement_Net player;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Transform from;
    private Transform to;
    private float time;

    private void Start()
    {
        player = target.GetComponent<PlayerMovement_Net>();
        startPoint = new Vector3( 0f, 0f, 0f);
        from = this.transform;
        to = player.transform;
        endPoint = player.position;
    }

    private void Update()
    {
        if (time == 0 || time > 1) {
            startPoint = endPoint;
            endPoint = player.position;
            from.rotation = to.rotation;
            to.rotation = Quaternion.Euler(player.x, player.y, player.z);
            Debug.Log("SEKUNDE");
            time = 0;
        }
        
        transform.position = Vector3.Lerp(startPoint, endPoint, time);
        transform.rotation = Quaternion.Lerp(from.rotation , to.rotation, time);

        time = time + Time.deltaTime;
    }

    //private void FixedUpdate()
    //{
    //    startPoint = endPoint ;
    //    endPoint = player.position;
    //}
}
