using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{

    public TextMeshProUGUI puntos;
    public GameObject[] vidas;
    
    void Update()
    {
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }

    public void QuitarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void SubirVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
