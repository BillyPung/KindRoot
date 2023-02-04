using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button4OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("Button Pressed");
        if (col.gameObject.tag == "Player")
        {
            door.GetComponent<MoveDoor>().doorBeginOpen();
        }
    }
}
