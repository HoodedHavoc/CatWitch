using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    Pickups playerPickups;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player" || other.tag == "NPC")
        {
            Pickups key = other.GetComponent<Pickups>();
            if (!key.hasKey && Input.GetKeyDown(KeyCode.E))
            {
                key.hasKey = true;
                //hide the key
                transform.position = new Vector3(0, -666, 0);
                key.thePickUp = transform;

                key.hasKey = true;
                //hide the key
                transform.position = new Vector3(0, -666, 0);
                key.thePickUp2 = transform;
            }
        }
    }
}
