using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion : MonoBehaviour
{
    public AudioClip pocion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool vidaRecuperada=GameManager.Instance.RecuperarVida();
            AudioManager.Instance.ReproducirSonido(pocion);
            if (vidaRecuperada)
            {
                
                Destroy(this.gameObject);
            }
            
        }

    }
}
