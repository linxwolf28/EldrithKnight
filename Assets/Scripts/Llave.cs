using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public GameObject door;
    public AudioClip llave_puerta;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            AudioManager.Instance.ReproducirSonido(llave_puerta);
            door.GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
}
