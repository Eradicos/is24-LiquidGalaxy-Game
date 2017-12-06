using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Follow_Net : NetworkBehaviour
{

    private GameObject target;
    private GameObject startPosition;
    public bool movable;
    private Vector3 offset;
    bool parented = false;
    Transform mainCamera;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        try
        {
            string[] arguments = System.Environment.GetCommandLineArgs();

            startPosition = GameObject.Find(arguments[2]);
        }
        catch (System.IndexOutOfRangeException e)
        {
            startPosition = GameObject.Find("client1");
        }

        target = GameObject.Find("Ship");

        transform.position = startPosition.transform.position;
        transform.rotation = startPosition.transform.rotation;
        //offset = new Vector3((transform.position.x - target.transform.position.x), (transform.position.y - target.transform.position.y), (transform.position.z - target.transform.position.z));
        mainCamera = Camera.main.transform;
        this.transform.SetParent(target.transform);


    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) + offset;
        //transform.rotation = target.transform.rotation;
        if (!parented)
        {
            try {
                target = GameObject.Find("Ship");
                this.transform.SetParent(target.transform);

                parented = true;
            }
            catch (System.NullReferenceException) {
                Debug.Log("no playercontroller");
            }
           
        }

        if (movable) {
            Debug.Log(mainCamera.position);

            float x = Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f;
            float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }

        moveCamera();
    }

    void moveCamera()
    {
        mainCamera.position = transform.position;
        mainCamera.rotation = transform.rotation;
    }

}
