using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;

    private Vector3 playerVelocity;
    private bool isGrounded;
    [SerializeField] private float speed = 15;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpPower = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        isGrounded = characterController.isGrounded;
        //Debug.Log(speed);
    }


    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;


        characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0 ) 
        {
            playerVelocity.y = -2f;
        }
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded) 
        {
            playerVelocity.y = Mathf.Sqrt(jumpPower * -3f * gravity);
        }
    }

    public void Sprint()
    {
        speed = speed * 2;
    }

    public void NormalMove()
    {
        speed = 15;
    }


}
