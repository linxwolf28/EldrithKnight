using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaer : MonoBehaviour
{
    [SerializeField] private float tiempoEspera;
    [SerializeField] private float tiempoReaparece;
    private Rigidbody2D rb;
    [SerializeField] private Vector3 posIni;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Caer", tiempoEspera);
            Invoke("Reaparece", tiempoReaparece);
        }
    }

    private void Caer()
    {
        rb.isKinematic = false;
    }

    private void Reaparece()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        transform.position = posIni;
    }












}
