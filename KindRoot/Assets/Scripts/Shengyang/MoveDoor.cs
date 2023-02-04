using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    // Start is called before the first frame update
    private bool doorIsOpened = false;
    private bool doorIsOpening = false;
    public float openingTime = 3f;
    [SerializeField] private float timer = 9999f;

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpening && timer <= openingTime)
        {
            timer += Time.deltaTime;
            transform.position += new Vector3(0, 0.4f, 0) * Time.deltaTime;
        }
        else if (doorIsOpening && timer > openingTime)
        {
            doorIsOpened = true;
        }
        
    }
    
    public void doorBeginOpen()
    {
        if(doorIsOpened || doorIsOpening) return;
        //print("timer reset");
        doorIsOpening = true;
        timer = 0f;
        return;
    }
}
