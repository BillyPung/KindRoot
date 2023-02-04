using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]

public class NewRopeScript : MonoBehaviour
{
    

    public GameObject player;

    public float dist;

    public float maxDist;
    public float stretchDis;

    public float smallForce;
    public float bigForce;

    public LineRenderer lr;
    public EdgeCollider2D ropeCol;
    // public int vertexCount;
    public GameObject[] nodes;

    // Start is called before the first frame update
    void Start()
    {
        ropeCol = GetComponent<EdgeCollider2D>();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(transform.position, player.transform.position);

        if (dist <= (maxDist))
        {
            // Debug.Log("第一个在的");
        }
        
        else if (dist > (maxDist) && dist < (maxDist + stretchDis))
        {
            Vector2 forceDir = (Vector2)transform.position - (Vector2)player.transform.position;
            forceDir.Normalize();
            forceDir = forceDir * smallForce;
            player.GetComponent<Rigidbody2D>().AddForce(forceDir);
            // Debug.Log("稍微超过了");
        }
        
        else if (dist > (maxDist + stretchDis))
        {
            Vector2 forceDir = (Vector2)transform.position - (Vector2)player.transform.position;
            forceDir.Normalize();
            forceDir = forceDir * bigForce;
            player.GetComponent<Rigidbody2D>().AddForce(forceDir);
            // Debug.Log("超过很多了");
        }

        RenderLine();



    }


    void RenderLine()
    {
        lr.positionCount = 2;

        for (int i = 0; i < nodes.Length; i++)
        {
            lr.SetPosition(i, nodes[i].transform.position);
        }
        SetEdgeCollider(lr);
    }


    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();
        for (int point = 0; point < lineRenderer.positionCount; point++)
        {
            Vector3 lineRenderPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRenderPoint.x, lineRenderPoint.y));
        }

        ropeCol.SetPoints(edges);
        // ropeCol.offset
        // ropeCol.isTrigger = true;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,maxDist);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,maxDist + stretchDis);
    }
}
