using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float cooldownAtaque;

    private bool volverAtacar = true;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float vida;
    public AudioClip da�o;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }




    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if (vida <=0)
        {
            Muerte();
        }

    }

    private void Muerte()
    {
       
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!volverAtacar) return;

            volverAtacar = false;


            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            other.gameObject.GetComponent<MovimientoJugador>().AplicarGolpe();
            GameManager.Instance.PerderVida();
            AudioManager.Instance.ReproducirSonido(da�o);
            Invoke("ReactivarAtaque", cooldownAtaque);
        }
    }

    public void ReactivarAtaque()
    {
        volverAtacar = true;

        Color c= spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;

    }
   
}
