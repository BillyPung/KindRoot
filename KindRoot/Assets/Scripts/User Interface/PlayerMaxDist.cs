using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
public class PlayerMaxDist : MonoBehaviour
{
    public float maxDistValFloat;
    public Text maxDistVal;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.name == "Player_1")
        {
            maxDistValFloat = player.GetComponent<PlayerCTRL>().rootScript.maxDist;
        }
        else if (player.name == "Player_2")
        {
            maxDistValFloat = player.GetComponent<PlayerTwoCTRL>().rootScript.maxDist;
        }

        maxDistVal.text = maxDistValFloat.ToString();
    }
}
