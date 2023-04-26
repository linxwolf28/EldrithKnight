using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    MovimientoJugador mj;
   
    void Start()
    {
        mj = FindObjectOfType<MovimientoJugador>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mj.ResetPosition();
            GameManager.Instance.PerderVida();

        }

    }
}
