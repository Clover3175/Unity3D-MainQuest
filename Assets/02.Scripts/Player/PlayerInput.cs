using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode forwardKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode backKey = KeyCode.DownArrow;
    [SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rightKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    private Vector3 inputVector;

    private float inputX;
    private float inputZ;

    private PlayerMove playerMove;

    public Vector3 InputVector
    {
        get { return inputVector; } 
        set { inputVector = value; }
    }
    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }
    private void Update()
    {
        InputKey();
    }
    public void InputKey()
    {
        inputX = 0.0f;
        inputZ = 0.0f;

        if (Input.GetKey(forwardKey)) inputZ++;
        if (Input.GetKey(backKey)) inputZ--;
        if (Input.GetKey(leftKey)) inputX--;
        if (Input.GetKey(rightKey)) inputX++; 

        inputVector = new Vector3 (inputX, 0.0f, inputZ);

        if (inputVector.sqrMagnitude > 0.0f)
        {
            transform.forward = inputVector;
        }

        if (Input.GetKey(jumpKey))
        {
            playerMove.Jump();
        }
        playerMove.JumpOut();
    }
}
