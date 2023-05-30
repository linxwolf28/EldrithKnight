using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]

    private float movimientoHorinzontal = 0f;

    [SerializeField] private float velocidadMovimiento;

    [Range(0, 0.3f)][SerializeField] private float suavizadorMovimiento;

    private Vector3 velocidad=Vector3.zero;

    private bool mirandoDerecha = true;

    [Header("Salto")]

    [SerializeField] private float FuerzaSalto;
   
    [SerializeField] private LayerMask queEsSuelo;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private Vector3 dimensionesCajas;

    [SerializeField] private bool enSuelo;

    [SerializeField] private int saltosExtrasRestantes;

    [SerializeField] private int saltosExtras;



    Vector3 initPosicion;
    
    private float escalaGravedad;

    private bool botonSaltoArriba = true;

    private bool salto = false;

    private Vector3 respawPoint;
    public GameObject fallDetector;

    public AudioClip daño;

    private Animator Animator;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        escalaGravedad = rb2D.gravityScale;
        initPosicion = this.transform.position;
        respawPoint = transform.position;
    }


    private void Update() {
        movimientoHorinzontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        Animator.SetBool("running", movimientoHorinzontal != 0.0f);
        Animator.SetBool("enSuelo", enSuelo);

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCajas, 0f, queEsSuelo);

        if (enSuelo)
        {
            saltosExtrasRestantes = saltosExtras;
        }


        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
        else
        {
            DesactivarPlataforma();
        }



        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);


    }


    private void FixedUpdate() {

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCajas, 0f, queEsSuelo);

        Mover(movimientoHorinzontal * Time.fixedDeltaTime, salto);

        salto = false;
    }

    private void DesactivarPlataforma()
    {

    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjeto = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjeto, ref velocidad, suavizadorMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.velocity = new Vector2(0f, FuerzaSalto);
        }
        else
        {
            if (saltar && saltosExtrasRestantes > 0)
            {
                enSuelo = false;
                //rb2D.AddForce(new Vector2(0f, FuerzaSalto));
                rb2D.velocity = new Vector2(0f, FuerzaSalto);
                saltosExtrasRestantes -= 1;

            }
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCajas);
    }

    public void ResetPosition()
    {
        this.transform.position = initPosicion;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="ZonaMuerte")
        {
            transform.position = respawPoint;
            GameManager.Instance.PerderVida();

        }else if (collision.tag == "Checkpoint")
        {
            respawPoint = transform.position;

        }

    }
}
