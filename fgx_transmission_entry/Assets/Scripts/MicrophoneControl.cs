using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneControl : MonoBehaviour, IMouseRayResponseGeneric
{
    // Use this for initialization
    void Start ()
    {
    }
	
    // Update is called once per frame
    void Update () {
		
    }

	public void RayHitAction()
	{
		Debug.Log("Ray hit me! t. " + gameObject.name);
        GameObject.Find("ButtonManager").GetComponent<button_manager>().OpenMenu();
	}
}
