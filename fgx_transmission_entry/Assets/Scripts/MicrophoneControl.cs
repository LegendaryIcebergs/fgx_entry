using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneControl : MonoBehaviour, IMouseRayResponseGeneric
{
    GameObject Buttonmanager;

    // Use this for initialization
    void Start ()
    {
        Buttonmanager = GameObject.Find("MicrophoneMenuManager");
    }
	
    // Update is called once per frame
    void Update () {
		
    }

	public void RayHitAction()
	{
		Debug.Log("Ray hit me! t. " + gameObject.name);
        Buttonmanager.GetComponent<button_manager>().OpenMenu();
	}
}
