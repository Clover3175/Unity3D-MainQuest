using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity = -9.81f;  //Áß·Â °ª

    private PlayerInput playerInput;
    private PlayerMove playerMove;
    private PlayerAudio playerAudio;
    private PlayerEffect playerEffect;

    private Vector3 inputVector;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMove = GetComponent<PlayerMove>();
        playerAudio = GetComponent<PlayerAudio>();
        playerEffect = GetComponent<PlayerEffect>();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (playerAudio != null)
            {
                playerAudio.SoundNumber(0);
            }
            if(playerEffect != null)
            {
                playerEffect.PlayEffect();
            }
        }
    }

}
