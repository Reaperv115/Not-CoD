using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody rb;
    Animator animator;
    float speed = 12f;

    enum PlayerState
    {
        idle,
        walking,
        running
    } 
    PlayerState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // rb = GetComponent<Rigidbody>();
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        switch (state)
        {
            case PlayerState.idle:
            {
                animator.SetBool("idle", true);
                animator.SetBool("walk", false);
                break;
            }
            case PlayerState.walking:
            {
                animator.SetBool("walk", true);
                animator.SetBool("idle", false);

                break;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            print("holding w");
            state = PlayerState.walking;
        }
        else
        { 
            state = PlayerState.idle;
        }
    }
}
