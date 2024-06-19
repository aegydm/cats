using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed; //�ִ�ӷ�
    public float jumpPower;
    public float stopSpeed; //����ӵ� - �극��ũ (���������� ��ü)

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
        //�̵��ӵ�
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        { rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); }

        else if (rigid.velocity.x < maxSpeed * -(1))
        { rigid.velocity = new Vector2(maxSpeed * -(1), rigid.velocity.y); }

        //�÷�������
        if (rigid.velocity.normalized.y <= 0)
        {
            Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("OneWayPlatform", "Structure", "Npc"));

            if (rayHit.collider != null) //�����ɽ�Ʈ�� �����Ǵ°� ������� ���� �� �Ʒ� ���� ����
            {
                if (rayHit.distance < 0.5f) // ������Ʈ �Ÿ��� 0.5f ������ �Ÿ��϶� �Ʒ� ���� ����
                {
                    //Debug.Log(rayHit.collider.name);
                    Debug.Log("������");
                    ani.SetBool("isJump", false);
                }

            }

        }
            

    }
    void Update()
    {
        // ����
        if (Input.GetButtonDown("Jump") && !ani.GetBool("isJump")) 
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            ani.SetBool("isJump", true);
        }

        //�Ʒ����̵����� �÷��� ����ϱ�
        if (Input.GetAxis("Vertical") < 0)  
        {Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(playerLayerName), LayerMask.NameToLayer(onWayPlatformLayerName), true);}
        else
        {Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(playerLayerName), LayerMask.NameToLayer(onWayPlatformLayerName), false);}

        // �¿� ���� �ڵ� 
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; //�ø�
        }


        //if (input.getbuttonup("horizontal"))
        //{
        //    //����, �극��ũ �ӵ�
        //    rigid.velocity = new vector2(rigid.velocity.normalized.x * stopspeed, rigid.velocity.y);
        //}

        //�ִϸ��̼� ��Ʈ��
        if (Mathf.Abs(rigid.velocity.x) < 0.095)  //x�� �̵��� 0�϶�
        {
            ani.SetBool("isMove", false);
        }
        else
        {
            ani.SetBool("isMove", true);
        }
    }    
}
