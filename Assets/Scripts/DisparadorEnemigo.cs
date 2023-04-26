using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorEnemigo : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    [SerializeField] private GameObject bala;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
