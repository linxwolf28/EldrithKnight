using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;

    [SerializeField] private GameObject bala;

    [SerializeField] private bool powerUp=false;

    [SerializeField] private GameObject bala2;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
      
        if (powerUp == false){
            Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        }
        else
        {
            Instantiate(bala2, controladorDisparo.position, controladorDisparo.rotation);
        }
    }
}
