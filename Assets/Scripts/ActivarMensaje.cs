using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMensaje : MonoBehaviour
{

    [SerializeField] private GameObject mensaje;

    
    void Start()
    {
        mensaje.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mensaje.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mensaje.SetActive(false);
        }
    }
}
