using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;

    [SerializeField] private GameObject bala;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
