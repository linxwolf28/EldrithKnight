using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaer2 : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 initialPosition;
    bool plataformMovingBack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (plataformMovingBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, 20f * Time.deltaTime);

        }

        if (transform.position.y == initialPosition.y)
        {
            plataformMovingBack = false;
        }
    }

    void OnCollisionEnter2D( Collision2D col)
    {
        if (col.gameObject.Equals("Caballero") && !plataformMovingBack)
        {
            Invoke("DropPlataform", 0.5f);
        }
    }

    void DropPlataform()
    {
        rb.isKinematic = false;
        Invoke("GetPlataformBack", 0.5f);
    }

    void GetPlataformBack()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        plataformMovingBack = true;
    }


}
