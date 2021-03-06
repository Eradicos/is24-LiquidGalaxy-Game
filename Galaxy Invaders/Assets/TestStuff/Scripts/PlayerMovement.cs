﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public ControllDevice controllDevice;
    public BezierCurve bezier;
    public float curveMovement = 0.001f;
    private float move = 0.001f;
    float time = 0.0005f;
    private Vector3 position;


    public enum ControllDevice
    {
        Keyboard,
        Bezier
    }

    // Use this for initialization
    void Start()
    {

    }

    public bool HorizonLock = true;
    // Update is called once per frame
    void Update()
    {
        if (controllDevice == ControllDevice.Keyboard)
        {
            //float x = Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f;
            //float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            //Debug.Log("Horizontal: " + Input.GetAxis("Horizontal") + "Vertical: " + Input.GetAxis("Vertical"));

            //transform.Rotate(0, x, 0);
            //transform.Translate(0, 0, z);
        }


        if (controllDevice == ControllDevice.Bezier)
        {
            if (time >= 1)
            {
                time = 0;
            }
            else
            {
                position = bezier.GetPointAt(time);

                transform.LookAt(position);
                transform.position = position;
                time += Time.deltaTime * move;
            }
        }
    }

    public void ButtonTest()
    {
        move = curveMovement;
    }
}
