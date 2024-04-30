using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    private int score = 0;
    public Text txtScore;

    public gameController()
    {

    }

    public void pontuacao(int pontos)
    {
        score += pontos;
        txtScore.text = score.ToString();
    }


}
