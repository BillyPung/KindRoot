using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void QuitGame()
    {
        Application.Quit();
    }
}
