using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animations : MonoBehaviour {

    private Animator anim;

  

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        TalkToPunch();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    //
    public void Talk()
    {
        anim.SetFloat("randomNumber", Random.value);
        anim.SetBool("talk", true);
        anim.CrossFade("Armature|idleTalk", 1f);
    }

    //
    public void Punch()
    {
        anim.SetFloat("randomNumber", Random.value);
        anim.SetTrigger("punch");
    }

    //
    public void TalkToPunch()
    {
        for (int i = 0; i < 3; i++)
        {
            Talk();         
        }
        anim.SetBool("talk", false);

        for (int i = 3; i > 3 && i < 6; i++)
        {
            Punch();
        }
    }
}
