using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1FinalDeath : MonoBehaviour
{

    public Animator gAnim;
    public Animator pAnim;
    public float croakTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        croakTime -= (Time.deltaTime * 5);
        if (croakTime <= 0)
        {
            gAnim.SetTrigger("IsSlicing");
            pAnim.SetTrigger("Dead");
        }
    }
}
