using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] private GameObject espada_azul;
    [SerializeField] private GameObject caballero;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Destroy(this.gameObject);
            


        }

    }
}
