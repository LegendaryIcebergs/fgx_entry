using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

    private Animator anim;
    
    

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();

        Talk();
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    //
    public void Talk()
    {
        anim.SetFloat("randomNumber", Random.value);
        anim.SetBool("talk", true);
    }

    //
    public void Punch()
    {
        anim.SetFloat("randomNumber", Random.value);
        anim.SetTrigger("punch");
    }
}
