using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JumpStrengthUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float playerMaxJumpStren;
    public float playerCurJumpStren;
    public Image strengthBar; 
    void Start()
    {
        strengthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.name == "Player_1")
        {
            playerMaxJumpStren = player.GetComponent<PlayerCTRL>().maxJumpStren;
            playerCurJumpStren = player.GetComponent<PlayerCTRL>().jumpStrength;
        }

        else if (player.name == "Player_2")
        {
            playerMaxJumpStren = player.GetComponent<PlayerTwoCTRL>().maxJumpStren;
            playerCurJumpStren = player.GetComponent<PlayerTwoCTRL>().jumpStrength;
        }
        strengthBar.fillAmount = playerCurJumpStren/playerMaxJumpStren;
    }
}
