using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

    public GameObject spawn;
    public bool TestRun;
    // Use this for initialization
    void Start() {
        if (!TestRun)
        {
            try
            {
                string[] arguments = System.Environment.GetCommandLineArgs();

                if (arguments[1] == "host")
                {
                    StartHost();
                }
                else if (arguments[1] == "client")
                {

                    try {
                        networkAddress = arguments[3];
                        StartClient();
                    }
                    catch (System.IndexOutOfRangeException e) {
                        StartClient();
                    }

                    
                }
            }
            catch (System.IndexOutOfRangeException e)
            {
                Debug.Log("Command line Args out of Index");
                StartHost();
            }
        }
        else
        {
            StartClient();
        }
    }
}
