using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Text winnerText;
    private bool trigger = false;
    private float timer = 0f;
    void Start()
    {
        winnerText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            timer += Time.deltaTime;
            if(timer > 3f)
            {
                trigger = false;
                SceneManager.LoadScene("ending");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player_1")
        {
            GameObject.Find("Player_1").GetComponent<PlayerCTRL>().canMove = false;
            GameObject.Find("Player_2").GetComponent<PlayerTwoCTRL>().canMove = false;
            winnerText.text = "The Winner Is : Player1";
            winnerText.enabled = true;
            trigger = true;
        }
        else if (col.gameObject.name == "Player_2")
        {
            GameObject.Find("Player_1").GetComponent<PlayerCTRL>().canMove = false;
            GameObject.Find("Player_2").GetComponent<PlayerTwoCTRL>().canMove = false;
            winnerText.text = "The Winner Is : Player2";
            winnerText.enabled = true;
            trigger = true;
        }
    }
}
