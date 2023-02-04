using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems : MonoBehaviour
{

    [Header("所有游戏中道具共用的")] 
    public GameObject player1;
    public GameObject player2;

    public GameObject rope1;
    public GameObject rope2;
    void Awake()
    {
        player1 = GameObject.Find("Player_1");
        player2 = GameObject.Find("Player_2");
        rope1 = GameObject.Find("Rope_1");
        rope2 = GameObject.Find("Rope_2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
