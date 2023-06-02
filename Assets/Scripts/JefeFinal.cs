using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JefeFinal : MonoBehaviour
{
    public float cooldownAtaque;

    private bool volverAtacar = true;

    private SpriteRenderer spriteRenderer;
    
    public GameObject bullet;

    public Transform bulletPos;
    
    private float timer;
    
    public Slider barraVida;
    
    [SerializeField] private float vida;
    
    public AudioClip disparo;

    



    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        barraVida.value = vida;
    }




    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        barraVida.value = vida;
        if (vida <= 0)
        {
            Muerte();
            
        }

    }

    private void Muerte()
    {

        Destroy(gameObject);
        SceneManager.LoadScene(4);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!volverAtacar) return;

            volverAtacar = false;


            Color color = spriteRenderer.color;
            other.gameObject.GetComponent<MovimientoJugador>().AplicarGolpe();
            color.a = 0.5f;
            spriteRenderer.color = color;

            GameManager.Instance.PerderVida();

            Invoke("ReactivarAtaque", cooldownAtaque);
        }
    }

    public void ReactivarAtaque()
    {
        volverAtacar = true;

        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        AudioManager.Instance.ReproducirSonido(disparo);
    }
}
