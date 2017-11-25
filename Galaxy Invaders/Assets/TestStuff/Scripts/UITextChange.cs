using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextChange : MonoBehaviour {

    Text uiText;
	// Use this for initialization
	void Start () {
        uiText = GetComponent<Text>();
        try
        {
            string[] arguments = System.Environment.GetCommandLineArgs();
            if (arguments.Length > 0)
            {
                uiText.text = arguments[1] + " " + arguments[2];
            }
        }
        catch(System.IndexOutOfRangeException e)
        {

        }
     
	}
}
