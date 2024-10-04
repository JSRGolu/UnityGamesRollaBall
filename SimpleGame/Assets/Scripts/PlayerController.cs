using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private int scoreCount;
    private int numPickups = 8;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI WinText;

    private InputHandler inputHandler;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = GetComponent<InputHandler>();

        scoreCount = 0;
        WinText.text = "";
        SetCountText();
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
            SetCountText();
        }
    }

    private void SetCountText()
    {
        ScoreText.text = " Score : " + scoreCount.ToString();
        if (scoreCount >= numPickups)
        {
            WinText.text = "Woohoo! You Win";
        }
    }
}
