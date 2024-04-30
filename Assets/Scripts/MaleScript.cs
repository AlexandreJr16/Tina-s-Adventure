using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleScript : MonoBehaviour
{
    public float speed = 2f;
    private int direction = 1;

    private float timer = 0f;
    private Animator animator;
    private bool dead = false;

    private CapsuleCollider2D body;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<CapsuleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (!dead)
        {

            transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
            animator.SetBool("isRun", true);
        }

    }

    async void OnCollisionEnter2D(Collision2D collision)
    {

        if (!dead && collision.gameObject.layer == 8)
        {
            animator.SetBool("isAttack", true);
            speed = 0;
        }
        if (!dead && collision.gameObject.layer == 7)
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isDead", true);
            dead = true;
            Destroy(rigid);
            Destroy(body);
        }
        if (collision.gameObject.layer == 6)
        {
            direction = direction * -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }

  
    void OnCollisionExit2D(Collision2D collision)
    {
        if (!dead && collision.gameObject.layer == 8)
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isRun", true);
            speed = 2f;

        }
       
      
    }
}
