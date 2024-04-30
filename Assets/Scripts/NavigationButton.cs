using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButton : MonoBehaviour
{
    
    public void onNavigation(string screen){
        SceneManager.LoadScene(screen);
        Debug.Log("Clicado em navegar tela");
    }
}
