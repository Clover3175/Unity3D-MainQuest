using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float acceleration = 10.0f;  //얼마나 빠르게 가감속 할지
    [SerializeField] private float deceleration = 10.0f;  //얼마나 빨리 멈추는지
    [SerializeField] private float jumpForce = 3.0f;
    [SerializeField] private float gravity = -9.81f;  //중력 값

    private float currentSpeed = 0.0f;  //현재속도
    private CharacterController characterController;
    private Animator animator;

    private Vector3 moveMent;

    //애니메이션
    private static readonly int runHash = Animator.StringToHash("Run");
    private static readonly int jumpHash = Animator.StringToHash("Jump");

    public CharacterController CharacterController
    {
        get { return characterController; }
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (CharacterController.isGrounded == false)
        {
            moveMent.y += gravity * Time.deltaTime;
        }
    }

    public void Move(Vector3 inputVector)
    {
        if (inputVector == Vector3.zero)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
            }
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * acceleration);
        }
        
        moveMent = new Vector3( inputVector.x, moveMent.y, inputVector.z);

        CharacterController.Move(moveMent * moveSpeed * Time.deltaTime);

        float speedValue = inputVector.magnitude;

        animator.SetFloat(runHash, speedValue);


    }
    public void Jump()
    {
        if (characterController.isGrounded == true)
        {
            moveMent.y = jumpForce;
            animator.SetBool(jumpHash, true);
        }
    }
    public void JumpOut()
    {
        if (characterController.isGrounded == true && moveMent.y <= 0.05f)
        {
            animator.SetBool(jumpHash, false);
        }
    }
    

}
