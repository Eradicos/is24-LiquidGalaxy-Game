using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Activater : MonoBehaviour {

    private float dist;
    public GameObject target;
    private GameObject child2;
    private GameObject child3;
    private GameObject child4;
    private GameObject child5;
    private GameObject child6;
    private GameObject child7;
    private GameObject child8;
    private GameObject child9;
    private GameObject child10;
    public GameObject[] Children;
    public float startTime;
    public float spawntime;


    private void Start()
    {
        
        //Children[1] = child1;
        //Children.Add(child2);
        //Children.Add(child3);
        //Children.Add(child4);
        //Children.Add(child5);
        //Children.Add(child6);
        //Children.Add(child7);
        //Children.Add(child8);
        //Children.Add(child9);
        //Children.Add(child10);


        for (int i = 0; i < Children.Length; i++)
        {
            Children[i].SetActive(false);
            print("GameObject: " + Children[i]);
        }

    }

    void Update()
    {

        for (int i = 0; i < Children.Length; i++)
        {

            dist = Vector3.Distance(target.transform.position, Children[i].transform.position);
            Debug.Log("Distance ist: " + dist);

            if (Children[i].activeSelf)
            {
                print("Active");
            }

            if (dist < 100)
            {
                Debug.Log("Distance is: " + dist);
                Children[i].SetActive(true);
            }
            else
            {
                Children[i].SetActive(false);
            }
        }
    }

   

}
