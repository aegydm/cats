using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npctest : MonoBehaviour
{

    [SerializeField] private TalkSystem talkSystem01;

    public GameObject interactionButton;
    public GameObject canvas;
    public Text text;
    bool inPlayer = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlayer == true)
        {
            interactionButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("test!");
                canvas.SetActive(true);
                StartCoroutine ("DialogStart");
            }
        }
        else
        {
            interactionButton.SetActive(false);
        }
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inPlayer = true;
        }
        else
        {
            inPlayer = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inPlayer = false;
    }


    private IEnumerator DialogStart()
    {
        Debug.Log("test!");
        
        yield return new WaitUntil(() => talkSystem01.UpdateDialog());
    }
}
