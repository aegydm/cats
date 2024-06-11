using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


public enum GameState
{
    menu,
    inGame,
    gameOver
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public PlayerInfo playerInfo;
    public GameState currentGameState = GameState.menu;
    public float time;

    public GameObject menuUi;
    public GameObject overUi;
    public GameObject stopUi;

    public string scenename;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;    //�̱� �� ����: �̷ν� ��� �ҷ����� �㰡
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }
        One("testScenes");
    }
    void Start()
    {
        //Menu();
        //One("testScenes");
        //playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape)) { StopGame(); }
    }
    public void One(string scen)
    {
        scenename = (scen);
        SceneManager.LoadScene("Loading Scene");
    }
    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //Menu();                     �����Լ������߻� ����
            overUi.SetActive(false);
            //menuUi.SetActive(true);
            stopUi.SetActive(false);
        }
        else if (newGameState == GameState.inGame)
        {
            Ingame();
            overUi.SetActive(false);
            menuUi.SetActive(false);
            stopUi.SetActive(false);
        }
        else if (newGameState == GameState.gameOver)
        {
            //GameOver();;                �����Լ������߻� ����
            overUi.SetActive(true);
            menuUi.SetActive(false);
            stopUi.SetActive(false);
        }
        currentGameState = newGameState;  //���ӻ��� �˻��� ����ϸ� �Ǵ� ����
    }
    //----------------------���� �Է¿� ���� ����---------------------------
    public void Menu()                          //���� ����� ù ȭ��, ���� ��ư�� ����
    {
        
        Time.timeScale = 0;
        SetGameState(GameState.menu);
    }

    public void Ingame()                        //�������λ��� - ��ֻ��� �Ϲ� ��, ������
    {
        Debug.Log("�ΰ��� �����");
        //enemyspawnmanager.pullingenemys();      //���ʹ� Ǯ��
        //enemyspawnmanager.stage1();             //�������� ���� = ���ʹ�s 4���� ���� 
    }

    public void GameOver()                      //�ӽ� ���ӿ��� �ڵ� - �ٸ��ڵ忡�� GameManager.instance.GameOver(); �� ȣ���
    {
        //if (playerinfo._playerhp <= 0)
        //{
        //    time.timescale = 0;
        //    setgamestate(gamestate.gameover);
        //}
        Time.timeScale = 0;
    }
    //----------------------��ư �Է¿� ���� ����---------------------------

    public void StartGame()        //���ӽ��� ��ư ������ ����
    {
        Time.timeScale = 1;
        SetGameState(GameState.inGame);
    }
    public void QuitGame()         //���� �������ư
    {
        Application.Quit();
    }

    public void StopGame()         // �Ͻ����� (ESC)
    {
        Debug.Log ("�Ͻ�������");
        if (currentGameState == GameState.inGame)
        {
            if (Time.timeScale == 0)
            {
                stopUi.SetActive(false);
                Time.timeScale = 1;
            }
            else if (Time.timeScale == 1)
            {
                stopUi.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ResetGame()        //�ٽ��ϱ�
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //--------------------------------------------------------------------

}
