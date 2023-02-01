using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHook : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hook;
    private GameObject _curHook;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

            _curHook.GetComponent<RopeScript>().destiny = destiny;
        }    
    }
}
