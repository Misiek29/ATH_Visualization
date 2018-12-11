using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    private CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        Vector3 forwardMovement = Camera.main.transform.forward * vertInput;
        Vector3 rightMovement = Camera.main.transform.right * horizInput;
        charController.SimpleMove(forwardMovement + rightMovement);
        //JumpInput();
    }
  
}
