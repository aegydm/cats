using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed; //최대속력
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        
        if (Input.GetButtonUp("Horizental"))
        {
            //멈춤, 브레이크 속도
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Input.GetButtonDown("Horizental"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizental") == -1;
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //이동속도
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        { rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); }

        else if (rigid.velocity.x < maxSpeed * -(1)) 
        { rigid.velocity = new Vector2(maxSpeed * -(1), rigid.velocity.y); }

    }
}
