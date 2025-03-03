using System;
using Unity.Mathematics;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");
        

        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.Rotate(-verticalInput, horizontalInput, 0);
            print("moving mouse");
        }
    }
}
