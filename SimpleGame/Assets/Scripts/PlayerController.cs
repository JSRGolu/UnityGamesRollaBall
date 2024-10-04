using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private int scoreCount = 0;

    private InputHandler inputHandler;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        Vector3 horizontalMovement = new Vector3(inputHandler.MoveInput.x, 0f, inputHandler.MoveInput.y);
        horizontalMovement.Normalize();
        characterController.Move(horizontalMovement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            scoreCount++;
        }
    }
}
