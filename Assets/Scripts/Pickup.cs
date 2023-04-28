using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //theDest short for Destination which is where the object I pick up will transform to
    public Transform theDest;


    //Saying that if I press left mouse button do this:
    void OnMouseDown()
    {
        //Turning off gravity on the objects rigidbody, so object dosent fall down when
        // - placed at the destination, which is infront of the POV as if you were 
        // - holding it in your hands.
        GetComponent<Rigidbody>().useGravity = false;
        
        //Moving the position of the object I pick up to Destination
        this.transform.position = theDest.position;
        
        //Making Destination parent over the object I pick up
        this.transform.parent = GameObject.Find("Destination").transform;
    }


    //When I let go of left mouse button do this:
    void OnMouseUp()
    {
        //Basically saying that Destination is no longer parent over object 
        this.transform.parent = null;

        //Turning gravity back on for the object now that we let it go
        GetComponent<Rigidbody>().useGravity = true;
    }
}