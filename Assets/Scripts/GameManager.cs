using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    public Puntos puntos;

    private int vidas = 5;

    public event EventHandler Muerte;

    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de una coas");
        }
    }

    public void SumarPuntos(int puntosSumar)
    {
        puntosTotales += puntosSumar;
        puntos.ActualizarPuntos(PuntosTotales);
    }

    public void PerderVida()
    {
        vidas -= 1;
        if (vidas==0)
        {
            Muerte?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
            
             SceneManager.LoadScene(3);


        }
        puntos.QuitarVida(vidas);
    }
    public bool RecuperarVida()
    {
        if (vidas == 5)
        {
            return false;
        }

        puntos.SubirVida(vidas);
        vidas += 1;
        return true;
       
    }
}
