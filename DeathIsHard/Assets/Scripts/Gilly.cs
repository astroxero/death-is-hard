using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gilly : MonoBehaviour
{
    public bool killSwitch;
    public Animator anim;
    public Animator pAnim;
    public Animator nAnim;
    public Collider2D boxCollider2d;
    public LayerMask playerLayerMask;
    public LayerMask nurseLayerMask;
    public GameObject playuhBodee;
    public GameObject nurzeeBody;
    public float totalCount = 2f;
    public float totalNurseCount = 2f;
    float countLeft;
    float nurseCountLeft;
    public float totalBodyCount = 2f;
    float BodyCountLeft;
    public float totalNSliceCount = 2f;
    float NSliceCountLeft;
    public float totalPSliceCount = 2f;
    float PSliceCountLeft;

    // Start is called before the first frame update
    void Start()
    {
        killSwitch = false;
        NSliceCountLeft = totalNSliceCount;
        PSliceCountLeft = totalPSliceCount;
        countLeft = totalCount;
        nurseCountLeft = totalNurseCount;
        BodyCountLeft = totalBodyCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (killSwitch == true)
        {
            PSliceCountLeft -= Time.deltaTime;
        }

        if (BodyCountLeft == totalBodyCount)
        {
        countLeft -= Time.deltaTime;
        } else 
        {
            countLeft = totalCount;
        }
        if (playerThere() & countLeft <= 0 & nurzeeBody == null)
        {
            killSwitch = true;
            anim.SetTrigger("IsSlicing");
            if (PSliceCountLeft <= 0)
            {
                anim.SetTrigger("NotSlicing");
                Destroy(playuhBodee);

            }
        }
        if (playerThere() & countLeft <= 0 & nurzeeBody != null)
        {
            playuhBodee.GetComponent<Moveee>().enabled = false;
            anim.SetTrigger("IsSlicing");
            pAnim.SetTrigger("IsSlicing");
            nAnim.SetTrigger("IsSlicing");
            countLeft = totalCount;
        } else if (playerThere())
        {

        } else
        {
            countLeft = totalCount;
        }
        if (playuhBodee.GetComponent<Moveee>().enabled == false & killSwitch == false)
        {
            BodyCountLeft -= Time.deltaTime;
        }
        if (BodyCountLeft <= 0 & killSwitch == false)
        {
            playuhBodee.GetComponent<Moveee>().enabled = true;
            BodyCountLeft = totalBodyCount;
            anim.SetTrigger("NotSlicing");
            pAnim.SetTrigger("NotSlicing");
            nAnim.SetTrigger("NotSlicing");
        }
        if (nurseThere() & nurseCountLeft <= 0)
        {
            anim.SetTrigger("IsSlicing");
        } else if (nurseThere())
        {
            nurseCountLeft -= Time.deltaTime;

        } else
        {
            nurseCountLeft = totalNurseCount;
        }
        if (nurseCountLeft <= 0)
        {
            NSliceCountLeft -= Time.deltaTime;
            if (NSliceCountLeft <= 0)
            {
                Destroy(nurzeeBody);
                NSliceCountLeft = totalNSliceCount;
            }
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
    public bool nurseThere() {
        //return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;

        float extraHeightText = -0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, nurseLayerMask);

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
