using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody rb;
    Animator animator;
    float walkingSpeed = 1.5f;
    float sprintingSpeed = 3f;
    Transform followTarget;

    enum PlayerState
    {
        idle,
        walking_forward,
        walking_backward,
        strafe_right,
        strafe_left,
        sprint,
        running
    } 
    PlayerState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        followTarget = transform.GetChild(2);
        animator.SetFloat("walk multiplier", 3);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            state = PlayerState.sprint;
            Vector3 move = followTarget.right * x + followTarget.forward * z;
            move = Vector3.ClampMagnitude(move, 1f);
            characterController.Move(move * sprintingSpeed * Time.deltaTime);
        }
        else
        {
            state = PlayerState.walking_forward;
            Vector3 move = followTarget.right * x + followTarget.forward * z;
            move = Vector3.ClampMagnitude(move, 1f);
            characterController.Move(move * walkingSpeed * Time.deltaTime);
        }

        switch (state)
        {
            case PlayerState.idle:
            {
                animator.SetBool("idle", true);
                animator.SetBool("walk forward", false);
                animator.SetBool("walk backward", false);
                animator.SetBool("strafe right", false);
                animator.SetBool("strafe left", false);
                break;
            }
            case PlayerState.walking_forward:
            {
                animator.SetBool("idle", false);
                animator.SetBool("walk forward", true);
                animator.SetBool("walk backward", false);
                animator.SetBool("strafe right", false);
                animator.SetBool("strafe left", false);
                break;
            }
            case PlayerState.walking_backward:
            {
                animator.SetBool("idle", false);
                animator.SetBool("walk backward", true);
                animator.SetBool("walk forward", false);
                animator.SetBool("strafe right", false);
                animator.SetBool("strafe left", false);
                break;
            }
            case PlayerState.strafe_right:
            {
                animator.SetBool("idle", false);
                animator.SetBool("walk backward", false);
                animator.SetBool("walk forward", false);
                animator.SetBool("strafe right", true);
                animator.SetBool("strafe left", false);
                break;
            }
            case PlayerState.strafe_left:
            {
                animator.SetBool("idle", false);
                animator.SetBool("walk backward", false);
                animator.SetBool("walk forward", false);
                animator.SetBool("strafe right", false);
                animator.SetBool("strafe left", true);
                break;
            }
            case PlayerState.sprint:
            {
                animator.SetBool("idle", false);
                animator.SetBool("walk backward", false);
                animator.SetBool("walk forward", false);
                animator.SetBool("strafe right", false);
                animator.SetBool("strafe left", false);
                animator.SetBool("sprint", true);
                break;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            state = PlayerState.walking_forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            state = PlayerState.walking_backward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            state = PlayerState.strafe_right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            state = PlayerState.strafe_left;
        }
        if (characterController.velocity.magnitude <= 0f)
        { 
            state = PlayerState.idle;
        }
    }
}
