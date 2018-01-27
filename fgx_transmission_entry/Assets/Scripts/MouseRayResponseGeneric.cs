using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used as a parent class for Raycast actions
/// </summary>
public interface IMouseRayResponseGeneric
{

	/// <summary>
	/// Called when mouse is clicked on gameObject this script is part of
	/// </summary>
	void RayHitAction();
}
