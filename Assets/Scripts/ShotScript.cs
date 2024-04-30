using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{

    Vector2 mousePosi;
    Vector2 dirArma;

    float angle;

    [SerializeField] SpriteRenderer srGun;

    [SerializeField] float tempoEntreTiros;
    bool podeAtirar = true;

    [SerializeField] Transform pontoDeFogo;
    [SerializeField] GameObject tiro;



   void Start()
{

    }

    void Update()
    {
        mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (tiro != null && Input.GetMouseButtonDown(0) && podeAtirar)
        {
            
            podeAtirar = false;
            Instantiate(tiro, pontoDeFogo.position, pontoDeFogo.rotation);
            Invoke("CDTiro", tempoEntreTiros);
        

        }


    }

    void CDTiro()
    {
        podeAtirar = true;



    }

    private void FixedUpdate()
    {
        dirArma = mousePosi - new Vector2(transform.position.x, transform.position.y);
        angle = Mathf.Atan2(dirArma.y, dirArma.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
