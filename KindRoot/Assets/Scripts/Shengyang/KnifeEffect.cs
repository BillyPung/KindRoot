using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.Mathematics;
using UnityEngine;

public class KnifeEffect : MonoBehaviour
{
    public bool gainKnife = false;
    public GameObject opponent;
    private Vector3 opponentPos;
    public float knifeRange = 1f;
    public Vector3 originPos = new Vector3(0, 0, 0);
    public GameObject rope;
    private float timer;
    public float knifeTime = 3f;
    public float knifeDisToMinus = 1f;
    private bool disReduced = false;

    void Start()
    {
        opponentPos = opponent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (knifeInArea() && gainKnife)
        {
            if(disReduced == false)
            {
                rope.GetComponent<NewRopeScript>().maxDist -= knifeDisToMinus;
                disReduced = true;
            }
            if(timer <= knifeTime)
            {
                timer += Time.deltaTime;
                
            }
            else 
            {
                rope.GetComponent<NewRopeScript>().maxDist += knifeDisToMinus;
                gainKnife = false;
                disReduced = false;
                timer = 0;
            }
            
        }
    }
    
    public void gainKnifeItem()
    {
        gainKnife = true;
    }

    private bool knifeInArea()
    {
        float X0 = opponentPos.x;
        float Y0 = opponentPos.y;
        return dis(opponentPos, originPos) > dis(transform.position, originPos)  &&math.abs(Y0/X0 * transform.position.x - transform.position.y )/math.sqrt(1 + Y0/X0 * Y0/X0) < knifeRange;
    }

    private float dis(Vector3 pos, Vector3 point)
    {
        return Mathf.Sqrt((pos.x - point.x) * (pos.x - point.x) + (pos.y - point.y) * (pos.y - point.y));
    }
    
    
}
