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
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        var cam = GameObject.Find("Starting Camera");
        if (cam)
            Destroy(cam);
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
                break;
            }
            case PlayerState.walking:
            {
                animator.SetBool("walking", true);

                break;
            }
        }
        if (characterController.velocity.magnitude > 0f)
        {
            print("player is walking");
            state = PlayerState.walking;
        }
        else
        {
            print("player is idle");   
            state = PlayerState.idle;
        }
    }
}
