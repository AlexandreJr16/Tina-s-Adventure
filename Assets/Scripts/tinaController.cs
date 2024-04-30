using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;


public class tinaController : MonoBehaviour
{
    private SpriteRenderer tinaSpriteRenderer;
    private Animator tinaAnimator;
    private Rigidbody2D tinaRigidBody2D;
    private Transform tinaTransform;


    private gameController _gameController = new gameController();

    public float speed;
    public float touchRun;
    private bool run;


    // Pulo
    public bool isGround;
    public Transform groundCheck;
    public bool jump;
    public float jumpForce;


  
    void Start()
    {
        tinaSpriteRenderer = GetComponent<SpriteRenderer>();
        tinaAnimator = GetComponent<Animator>();
        tinaRigidBody2D = GetComponent<Rigidbody2D>();
        tinaTransform = GetComponent<Transform>();
        groundCheck = transform.Find("isGround");

        _gameController = FindObjectOfType(typeof(gameController)) as gameController;
    }


    void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, (1 << LayerMask.NameToLayer("Ground")) | (1 << 6));
        touchRun = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
 

        
    }

    private void FixedUpdate()
    {
        movimentaTina(touchRun);
        animaTina();
        pulaTina();
    }

    void movimentaTina(float movimento)
    {
        if (movimento != 0)
        {
            if (movimento > 0)
            {
                tinaSpriteRenderer.flipX = false;
            }
            else if (movimento < 0)
            {
                tinaSpriteRenderer.flipX = true;
            }
            tinaRigidBody2D.velocity = new Vector2(speed * movimento, tinaRigidBody2D.velocity.y);
            run = true;
        }
        else
        {
            run = false;
        }   

    }

    void animaTina()
    {
        tinaAnimator.SetBool("run", run);
        tinaAnimator.SetBool("jump", jump);
    }

    void pulaTina()
    {
        if (isGround == true && jump == true)
        {
              tinaRigidBody2D.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode2D.Impulse);
              jump = false;
        }
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

     

        if (collision.gameObject.tag == "Heart")
        {
            _gameController.pontuacao(5);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "NormalHeart")
        {
            _gameController.pontuacao(1);
            Destroy(collision.gameObject);
        }
    }

    async void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.layer == 9)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


}
