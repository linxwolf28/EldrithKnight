using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{

    [SerializeField] private float velocidadMovimiento;

    [SerializeField] private Transform[] puntosMovimiento;

    [SerializeField] private float distanciaMinima;

    private int siguientePaso=0;

    private SpriteRenderer spriteRender;


    private void Start()
    {
       
        spriteRender = GetComponent<SpriteRenderer>();
        Girar();
    }

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velocidadMovimiento * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[siguientePaso].position) < distanciaMinima)
        {
            siguientePaso += 1;

            if (siguientePaso >= puntosMovimiento.Length)
            {
                siguientePaso = 0;
            }
            
            Girar();
        }


    }

    public void Girar()
    {
        if (transform.position.x < puntosMovimiento[siguientePaso].position.x)
        {
            spriteRender.flipX = true;
        }
        else
        {
            spriteRender.flipX = false;
        }
    }


}
