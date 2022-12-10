using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveee : MonoBehaviour
{
    public Rigidbody2D rb; 
    public Collider2D boxCollider2d;
    public LayerMask platformLayerMask;
    public float sped = 40;
    public float jumpHeight = 20f;
    public float bodySize = 0.72f;
    public Animator animatr;

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
            animatr.SetBool("IsRunning", true);
            rb.AddForce(transform.right * sped);
            transform.localScale = new Vector2(bodySize, bodySize);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animatr.SetBool("IsRunning", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animatr.SetBool("IsRunning", true);
            rb.AddForce(-transform.right * sped);
            transform.localScale = new Vector2(-bodySize, bodySize);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animatr.SetBool("IsRunning", false);
        }
        if (IsGrounded())
        {
            animatr.SetBool("IsJumping", false);
        } else
        {
            animatr.SetBool("IsJumping", true);
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            animatr.SetTrigger("TakeOff");
            float jumpVelocity = 10f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        
    }
    public bool IsGrounded() {
        //return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;

        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, platformLayerMask);

        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, boxCollider2d.bounds.extents.y + extraHeightText), Vector2.right * (boxCollider2d.bounds.extents.x * 2f), rayColor);
        return raycastHit.collider != null;
    }
}
