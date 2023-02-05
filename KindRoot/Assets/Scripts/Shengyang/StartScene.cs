using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void StartGame()
    {
        SceneManager.LoadScene("intro");
    }
}
