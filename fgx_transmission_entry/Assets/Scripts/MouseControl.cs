using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
	private Ray _ray;

	private RaycastHit _hit;
	// Use this for initialization
	/*
	 * Mouse left click: 0
	 * Mouse right click: 1
	 * Mouse middle click: 2
	 */

	private void FixedUpdate()
	{
		if (!Input.GetMouseButtonDown(0)) 
			return;
		_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(_ray, out _hit, 100))
		{
			GameObject targetGameObject = _hit.collider.gameObject;
			if (targetGameObject.CompareTag("interactable"))
			{
			//Debug.DrawLine(ray.origin, hit.point);
			//Debug.Log("Ray hit " + targetGameObject.name);
			IMouseRayResponseGeneric targetInterface;
			targetInterface = targetGameObject.GetComponent<IMouseRayResponseGeneric>();
			if (targetInterface != null)
			{
				targetInterface.RayHitAction();
			}
			}
		}

	}
}
