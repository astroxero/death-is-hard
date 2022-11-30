using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveee : MonoBehaviour
{
    
    Rigidbody2D rb;
    public float sped = 40;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * sped);
            transform.localScale = new Vector2(0.12f, 0.12f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * sped);
            transform.localScale = new Vector2(-0.12f, 0.12f);
        }
    }
}
