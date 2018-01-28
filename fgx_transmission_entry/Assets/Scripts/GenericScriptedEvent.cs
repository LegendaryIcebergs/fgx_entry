using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericScriptedEvent : MonoBehaviour
{

	/// <summary>
	/// Enums of possible states, values are of int type and go from 0 - 4.
	/// You can override this one if you need more than 5 states
	/// </summary>
	protected enum StateIds
	{
		EventStart,
		EventSceneOne,
		EventSceneTwo,
		EventSuccess,
		EventFail
	}

	

	protected EventManager Manager;
	
	public String EventName;

	private void Awake()
	{
		Manager = GameObject.Find("MasterObject").GetComponent<EventManager>();
	}

	/*public virtual void StartEvent()
	{
		currentState = (int) StateIds.EventStart;
		
	}*/

	public virtual void EnterSceneOne()
	{
		/*
		currentState = (int) StateIds.EventSceneOne;
		if (_sceneSuccess)
		{
			EnterSceneTwo();
		}
		else
		{
			EnterSceneFailier();
		}*/
	}

	public virtual void EnterSceneTwo()
	{
		/*currentState = (int) StateIds.EventSceneTwo;
		if (_sceneSuccess)
		{
			EnterSceneSuccess();
		}
		else
		{
			EnterSceneFailier();
		}*/
	}

	public virtual void EnterSceneSuccess()
	{
		throw new NotImplementedException();
	}

	public virtual void EnterSceneFailier()
	{
		throw new NotImplementedException();
	}
}

public interface IGenericScriptedEvent
{
	void StartEvent();
}
