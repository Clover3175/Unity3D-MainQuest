using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity = -9.81f;  //Áß·Â °ª

    private PlayerInput playerInput;
    private PlayerMove playerMove;

    private Vector3 inputVector;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
    }
    void Start()
    {

    }

    void Update()
    {
        playerInput.InputKey();
    }
    private void LateUpdate()
    {
        inputVector = playerInput.InputVector;
        playerMove.Move(inputVector);
    }
    
}
