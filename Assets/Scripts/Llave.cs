using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
