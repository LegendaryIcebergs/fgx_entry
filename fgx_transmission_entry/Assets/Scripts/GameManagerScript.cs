using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
	private static GameManagerScript instance;
	/// <summary>
	/// This allows gameObject that this script is attached to be preserved through Scene changes
	/// </summary>
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
			instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
