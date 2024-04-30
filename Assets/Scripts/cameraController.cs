using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public float offSetX = 1f;  // Distância do eixo X do jogador e da câmera.
    public float smooth = 0.1f; // Controla quão suave a câmera segue o player. Quanto menor melhor.

    // Variáveis para limitar a variação da câmera.
    public float limitedUp = 0f;
    public float limitedDown = 0f;
    public float limitedLeft = -12.62f;
    public float limitedRight = 14.87f;

    private Transform player;
    private float playerX;
    private float playerY;

    void Start()
    {
        player = FindObjectOfType<tinaController>().transform; // Pega o transform do tinaPlayerController
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        {
            if (player != null)
            {
                // player ter valores do transform
                playerX = Mathf.Clamp(player.position.x + offSetX, limitedLeft, limitedRight);
                playerY = Mathf.Clamp(player.position.y, limitedDown, limitedUp);

                transform.position = Vector3.Lerp(transform.position, new Vector3(playerX, playerY, transform.position.z), smooth);

            }
        }

    }
}
