using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private float da�o;



    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            other.GetComponent<Enemigo>().TomarDa�o(da�o);

            Destroy(gameObject);
        }else if (other.CompareTag("Enemigo2"))
        {
            other.GetComponent<Enemigo2_2>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
        
        else if (other.CompareTag("JefeFinal"))
        {
            other.GetComponent<JefeFinal>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
    }
}
