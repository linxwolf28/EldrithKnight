using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{

    
   public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }


    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}
