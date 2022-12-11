using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gilly : MonoBehaviour
{
    public Collider2D boxCollider2d;
    public LayerMask playerLayerMask;
    public GameObject playuhBodee;
    public float totalCount = 2f;
    public float countLeft;

    // Start is called before the first frame update
    void Start()
    {
        countLeft = totalCount;
    }

    // Update is called once per frame
    void Update()
    {
        countLeft -= Time.deltaTime;
        if (playerThere() & countLeft <= 0)
        {
            Debug.Log("Death");
             playuhBodee.GetComponent<Moveee>().enabled = false;
            countLeft = totalCount;
        } else if (playerThere())
        {

        } else
        {
            countLeft = totalCount;
        }
    }
    public bool playerThere() {
        //return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;

        float extraHeightText = -0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, playerLayerMask);

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
