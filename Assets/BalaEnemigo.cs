using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    [SerializeField] private float daño;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
