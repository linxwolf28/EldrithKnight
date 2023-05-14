using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JefeFinal : MonoBehaviour
{
    public float cooldownAtaque;

    private bool volverAtacar = true;

    private SpriteRenderer spriteRenderer;
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;

    [SerializeField] private float vida;
    [SerializeField] public GameObject[] vidas;
    public AudioClip disparo;



    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }




    public void TomarDaño(float daño)
    {
        vida -= daño;
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
