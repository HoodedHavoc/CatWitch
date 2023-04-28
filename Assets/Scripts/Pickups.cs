using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    public bool hasKey = false;
    public Transform thePickUp;
    public Transform thePickUp2;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && hasKey)
        {
            //drop the key
            thePickUp.position = transform.position + transform.forward;
            hasKey = false;

            //drop the key
            thePickUp2.position = transform.position + transform.forward;
            hasKey = false;

        }
    }
}
