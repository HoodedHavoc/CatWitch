using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Declares sensitivity for mouse movement
    public float mouseSensitivity = 400f;

    // Declares playerbody to be transformed with camera
    public Transform playerbody;

    //Default rotation on X axis
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Makes mouse cursor dissapear and lock to the middle of the screen when pressing play
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets default inputs for moving on x and y axis (works with mouse and controller)
        // deltaTime makes movement set to declared defualt (400) by mouseSensitivity
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // To not make camera movement in y the same as in x (as it would with just =)
        // -= instead of += as to not invert vertical camera movement on y
        xRotation -= mouseY;
       
        // Limits camera values to not go beyond top or bottom of player
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        // Makes the camera rotate locally and not globaly
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Allows player to be rotated with the camera
        playerbody.Rotate(Vector3.up * mouseX);

    }
}
