using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npctest : MonoBehaviour
{

    public GameObject interactionButton;
    public GameObject sms;
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
                sms.SetActive(true);
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

}
