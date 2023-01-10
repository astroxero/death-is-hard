using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1FinalDeath : MonoBehaviour
{

    public Animator gAnim;
    public Animator pAnim;

    // Start is called before the first frame update
    void Start()
    {
        gAnim.SetTrigger("IsSlicing");
        pAnim.SetTrigger("Dead");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
