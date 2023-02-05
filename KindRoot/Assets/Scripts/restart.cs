using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void RestartGame()
    {
        SceneManager.LoadScene("start");
    }
}
