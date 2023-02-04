using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseText;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Pause);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
        if(Time.timeScale == 0)
        {
            
            pauseText.SetActive(true);
        }
        else
        {
            pauseText.SetActive(false);
        }
        
    }
    void Pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
