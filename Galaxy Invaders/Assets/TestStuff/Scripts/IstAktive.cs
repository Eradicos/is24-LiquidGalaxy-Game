using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstAktive : MonoBehaviour {

    public GameObject ich;
	// Use this for initialization
	void Start () {
		ich.SetActive(false);
    }

    private void OnEnable()
    {
        print("Ich bin aktiv");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
