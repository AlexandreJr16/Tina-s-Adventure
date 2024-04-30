using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float tempoDeVida;


    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    private void FixedUpdate()
    {

        transform.Translate(transform.up * speed * Time.fixedDeltaTime, Space.World);
  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if ( collision.gameObject.layer == 6 || collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }

    }
}
