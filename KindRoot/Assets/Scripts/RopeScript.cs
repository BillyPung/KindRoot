using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RopeScript : MonoBehaviour
{

    public Vector2 destiny;
    // public float speed;

    public float distance;
    
    public GameObject nodePrefab;
    public GameObject player;
    public GameObject lastNode;

    public int maxNodeNum;
    public int curNodeNum;
    
    public bool done;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        lastNode = transform.gameObject;

        maxNodeNum = (int)Vector2.Distance(player.transform.position, transform.position) - 1;
        maxNodeNum = (int) ((float)maxNodeNum / distance);
    }


    void Update()
    {
        if (curNodeNum < maxNodeNum)
        {
            if (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }
        }
        else if (done == false)
        {
            done = true;
            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            // player.transform.SetParent(transform);
        }
            
    }

    void CreateNode()
    {
        Vector2 pos2Create =  player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;
    
        GameObject go = (GameObject)Instantiate(nodePrefab, pos2Create, Quaternion.identity);
    
        go.transform.SetParent(transform);
        
        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
        lastNode = go;
    
        curNodeNum += 1;
    }
    
    
}
