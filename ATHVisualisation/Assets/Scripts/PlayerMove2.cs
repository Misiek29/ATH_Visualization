using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{


    public float speed;
    public bool moveForoward;
    public bool moveHorizontal;
    private CharacterController charController;



    // Use this for initialization
    void Start()
    {

        charController = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Vertical"))
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }


    }
}
