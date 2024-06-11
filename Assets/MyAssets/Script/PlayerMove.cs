using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed; //�ִ�ӷ�
    public float jumpPower;
    public float stopSpeed; //����ӵ� - �극��ũ (���������� ��ü)
    public bool isJump; // �������� ����
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator ani;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        
        //if (input.getbuttonup("horizontal"))
        //{
        //    //����, �극��ũ �ӵ�
        //    rigid.velocity = new vector2(rigid.velocity.normalized.x * stopspeed, rigid.velocity.y);
        //}

        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; //�ø�
        }

        if (rigid.velocity.normalized.x == 0)  //x�� �̵��� 0�϶�
        {
            ani.SetBool("isMove", false);
        }
        else
        {
            ani.SetBool("isMove", true);
        }

        if (rigid.velocity.normalized.y == 0)  //x�� �̵��� 0�϶�
        {
            ani.SetBool("isJump", false);
        }
        else
        {
            ani.SetBool("isJump", true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�̵��ӵ�
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        { rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); }

        else if (rigid.velocity.x < maxSpeed * -(1)) 
        { rigid.velocity = new Vector2(maxSpeed * -(1), rigid.velocity.y); }

    }
}
