using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePosition : MonoBehaviour {

    public GameObject target;

	void Start () {
        transform.position = target.transform.position;
	}
}
