using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemys : MonoBehaviour {

    public new GameObject DestroyObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "")
        {
            Destroy(gameObject, .5f);
        }
        Destroy(DestroyObject);
    }
}
