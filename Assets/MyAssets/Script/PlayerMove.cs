using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed; //최대속력
    public float jumpPower;
    public float stopSpeed; //멈춤속도 - 브레이크 (마찰값으로 대체)

    public string onWayPlatformLayerName;
    public string playerLayerName;

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
    private void Start()
    {
        onWayPlatformLayerName = "OneWayPlatform";
        playerLayerName = "Player";
    }
    void FixedUpdate()
    {
        //이동속도
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        { rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); }

        else if (rigid.velocity.x < maxSpeed * -(1))
        { rigid.velocity = new Vector2(maxSpeed * -(1), rigid.velocity.y); }

        //플렛폼감지
        if (rigid.velocity.normalized.y <= 0)
        {
            Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("OneWayPlatform", "Structure", "Npc"));

            if (rayHit.collider != null) //레이케스트에 감지되는게 비어있지 않을 때 아래 지문 실행
            {
                if (rayHit.distance < 0.5f) // 레이히트 거리가 0.5f 이하의 거리일때 아래 지문 실행
                {
                    //Debug.Log(rayHit.collider.name);
                    Debug.Log("착지함");
                    ani.SetBool("isJump", false);
                }

            }

        }
            

    }
    void Update()
    {
        // 점프
        if (Input.GetButtonDown("Jump") && !ani.GetBool("isJump")) 
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            ani.SetBool("isJump", true);
        }

        //아래로이동으로 플렛폼 통과하기
        if (Input.GetAxis("Vertical") < 0)  
        {Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(playerLayerName), LayerMask.NameToLayer(onWayPlatformLayerName), true);}
        else
        {Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(playerLayerName), LayerMask.NameToLayer(onWayPlatformLayerName), false);}

        // 좌우 반전 코드 
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; //플립
        }


        //if (input.getbuttonup("horizontal"))
        //{
        //    //멈춤, 브레이크 속도
        //    rigid.velocity = new vector2(rigid.velocity.normalized.x * stopspeed, rigid.velocity.y);
        //}

        //애니메이션 컨트롤
        if (Mathf.Abs(rigid.velocity.x) < 0.095)  //x축 이동이 0일때
        {
            ani.SetBool("isMove", false);
        }
        else
        {
            ani.SetBool("isMove", true);
        }
    }    
}
