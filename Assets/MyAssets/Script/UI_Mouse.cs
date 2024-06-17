using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Mouse : MonoBehaviour
{
    public GameObject onUi;
    public string n;
    public bool click;
    public bool drag;
    public bool on;
    public bool exit;
    Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (click)
        {
            switch (n)
            {
                case "test":
                    Debug.Log("Ŭ�� �׽�Ʈ ��ȣ�ۿ�");
                    break;
            }
            Debug.Log("Ŭ��!");
        }
    }
    void OnMouseOver()
    {
        if (on)
        {
            switch (n)
            {
                case "test":
                    Debug.Log("���콺 �� �׽�Ʈ ��ȣ�ۿ�");
                    break;
            }
            Debug.Log("���콺�ö��");
            onUi.SetActive(true);
            //ani.SetBool("On", true);
        }

    }
    void OnMouseExit()
    {
        if (exit)
        {
            switch (n)
            {
                case "test":
                    Debug.Log("���콺 ���� �׽�Ʈ ��ȣ�ۿ�");
                    break;
            }
            Debug.Log("���콺 ����");
            onUi.SetActive(false);
            //ani.SetBool("On", false);
        }

    }

    float distance = 10;
    void OnMouseDrag() 
    { 
        if (drag)
        {
            print("Drag!!");
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); transform.position = objPosition;
        }
        
    }


    

}
