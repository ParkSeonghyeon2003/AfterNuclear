using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    SpriteRenderer spriter;
    Rigidbody2D rigid;
    Animator anim;

    public float maxSpeed; // 최대 속도
    public float jumpPower; // 점프 파워

    float horizontal;

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.TriggerInventory();
        }

        if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJumping"))
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (horizontal != 0.0f)
        {
            spriter.flipX = horizontal > 0;
        }

        if (Mathf.Abs(rigid.velocity.x) < 0.3f || anim.GetBool("IsJumping"))
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * horizontal, ForceMode2D.Impulse);
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        Debug.DrawRay(rigid.position, Vector2.down * 1.3f, new Color(1, 0, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 1.3f, LayerMask.GetMask("Platform"));
        if (rigid.velocity.y < 0.0f)
        {
            if (rayHit.collider != null)
            {
                anim.SetBool("IsJumping", false);
            }
        }
    }
}
