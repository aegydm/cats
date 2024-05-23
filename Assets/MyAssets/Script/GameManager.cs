using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM_Instance;
    public bool GameOver = false;

    public string scenename;
    // Start is called before the first frame update
    void Start()
    {
        if (GM_Instance == null)
        {
            GM_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void One()
    {
        scenename = "MineOne";
        SceneManager.LoadScene("Loading");
    }
}
