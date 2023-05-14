using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2_2 : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;
    [SerializeField] private float vida;

    public float cooldownAtaque;

    private bool volverAtacar = true;

    private SpriteRenderer spriteRenderer;

    private float timer;

    public AudioClip disparo;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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

}
