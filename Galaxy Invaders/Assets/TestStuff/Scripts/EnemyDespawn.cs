using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
