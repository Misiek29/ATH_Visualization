using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp("joystick button 1"))
        {
            StartApp();
        }

    }
    public void StartApp()
    {
        SceneManager.LoadScene("AthVisualisation");
    }
}
