using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;

    [SerializeField] private GameObject bala;

    [SerializeField] public bool powerUp=false;

    [SerializeField] private GameObject bala2;
    
    public AudioClip disparo;

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
            AudioManager.Instance.ReproducirSonido(disparo);
            Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
            
        }
        else
        {
            AudioManager.Instance.ReproducirSonido(disparo);
            Instantiate(bala2, controladorDisparo.position, controladorDisparo.rotation);
            
        }
    }
}
