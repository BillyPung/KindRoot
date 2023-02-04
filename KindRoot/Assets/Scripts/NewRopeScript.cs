using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRopeScript : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public float dist1;
    public float dist2;

    public float maxDist1;
    public float maxDist2;

    public float stretchDis;

    public float smallForce;
    public float bigForce;

    public LineRenderer lr;
    // public int vertexCount;
    public GameObject[] nodes1;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dist1 = Vector2.Distance(transform.position, player1.transform.position);

        if (dist1 <= (maxDist1))
        {
            Debug.Log("第一个在的");
        }
        
        else if (dist1 > (maxDist1) && dist1 < (maxDist1 + stretchDis))
        {
            Vector2 forceDir = (Vector2)transform.position - (Vector2)player1.transform.position;
            forceDir.Normalize();
            forceDir = forceDir * smallForce;
            player1.GetComponent<Rigidbody2D>().AddForce(forceDir);
            Debug.Log("稍微超过了");
        }
        
        else if (dist1 > (maxDist1 + stretchDis))
        {
            Vector2 forceDir = (Vector2)transform.position - (Vector2)player1.transform.position;
            forceDir.Normalize();
            forceDir = forceDir * bigForce;
            player1.GetComponent<Rigidbody2D>().AddForce(forceDir);
            Debug.Log("超过很多了");
        }

        RenderLine();
        
    }


    void RenderLine()
    {
        lr.SetVertexCount(2);
        // int i;
        
        // for (i = 0; i < nodes1.Length; i++)
        // {
        //     lr.SetPosition(i, nodes1[i].transform.position);
        // }
        lr.SetPosition(0, player1.transform.position);
        lr.SetPosition(1, transform.position);
    }
}
