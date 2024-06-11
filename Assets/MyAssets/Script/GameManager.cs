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
            Instance = this;    //싱글 톤 선언: 이로써 모든 불러오기 허가
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
            //Menu();                     제귀함수오류발생 방지
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
            //GameOver();;                제귀함수오류발생 방지
            overUi.SetActive(true);
            menuUi.SetActive(false);
            stopUi.SetActive(false);
        }
        currentGameState = newGameState;  //게임상태 검색에 사용하면 되는 변수
    }
    //----------------------상태 입력에 따른 값들---------------------------
    public void Menu()                          //게임 실행시 첫 화면, 시작 버튼이 존재
    {
        
        Time.timeScale = 0;
        SetGameState(GameState.menu);
    }

    public void Ingame()                        //게임중인상태 - 노멀상태 일반 몹, 정예몹
    {
        Debug.Log("인게임 실행됨");
        //enemyspawnmanager.pullingenemys();      //에너미 풀링
        //enemyspawnmanager.stage1();             //스테이지 실행 = 에너미s 4마리 출현 
    }

    public void GameOver()                      //임시 게임오버 코드 - 다른코드에서 GameManager.instance.GameOver(); 로 호출됨
    {
        //if (playerinfo._playerhp <= 0)
        //{
        //    time.timescale = 0;
        //    setgamestate(gamestate.gameover);
        //}
        Time.timeScale = 0;
    }
    //----------------------버튼 입력에 따른 값들---------------------------

    public void StartGame()        //게임시작 버튼 눌리면 실행
    {
        Time.timeScale = 1;
        SetGameState(GameState.inGame);
    }
    public void QuitGame()         //게임 나가기버튼
    {
        Application.Quit();
    }

    public void StopGame()         // 일시정지 (ESC)
    {
        Debug.Log ("일시정지됨");
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

    public void ResetGame()        //다시하기
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //--------------------------------------------------------------------

}
