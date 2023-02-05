using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Text winnerText;
    void Start()
    {
        winnerText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player_1")
        {
            GameObject.Find("Player_1").GetComponent<PlayerCTRL>().canMove = false;
            GameObject.Find("Player_2").GetComponent<PlayerTwoCTRL>().canMove = false;
            winnerText.text = "The Winner Is : Player1";
            winnerText.enabled = true;
        }
        else if (col.gameObject.name == "Player_2")
        {
            GameObject.Find("Player_1").GetComponent<PlayerCTRL>().canMove = false;
            GameObject.Find("Player_2").GetComponent<PlayerTwoCTRL>().canMove = false;
            winnerText.text = "The Winner Is : Player2";
            winnerText.enabled = true;
        }
    }
}
