using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npctest : MonoBehaviour
{

    [SerializeField] private TalkSystem talkSystem01;

    public string type;
    public GameObject cam;

    public GameObject interactionButton;
    public GameObject canvas;
    public Text text;
    public bool inPlayer = false;
    public PlayerMove playerState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlayer)
        {
            interactionButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.W))
            {
                switch (type)
                {
                    case "test":
                        cam.SetActive(false);
                        break;
                    case "Npc1":
                        //talkSystem01.ResetDialog();
                        canvas.SetActive(true);
                        StartCoroutine("DialogStart");
                        break;
                }
            }
        }
        if (!inPlayer)
        {
            interactionButton.SetActive(false);
            
        }
    }

    private IEnumerator DialogStart()
    {
        yield return new WaitUntil(() => talkSystem01.UpdateDialog());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {inPlayer = true;}
        else
        {inPlayer = false;}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inPlayer = false;
        cam.SetActive(true);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        interactionButton.SetActive(true);

    //    }

    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        interactionButton.SetActive(false);

    //    }
    //}
}
