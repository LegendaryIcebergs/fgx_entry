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
	private enum StateIds
	{
		EventStart,
		EventSceneOne,
		EventSceneTwo,
		EventSuccess,
		EventFail
	}

	private bool _sceneSuccess;
	
	private int currentState;

	private EventManager _manager;

	private int _eventId;
	
	public String EventName;

	private void Awake()
	{
		_manager = GameObject.Find("MasterObject").GetComponent<EventManager>();
	}

	/*public virtual void StartEvent()
	{
		currentState = (int) StateIds.EventStart;
		
	}*/

	public virtual void EnterSceneOne()
	{
		currentState = (int) StateIds.EventSceneOne;
		if (_sceneSuccess)
		{
			EnterSceneTwo();
		}
		else
		{
			EnterSceneFailier();
		}
	}

	public virtual void EnterSceneTwo()
	{
		currentState = (int) StateIds.EventSceneTwo;
		if (_sceneSuccess)
		{
			EnterSceneSuccess();
		}
		else
		{
			EnterSceneFailier();
		}
	}

	public virtual void EnterSceneSuccess()
	{
		currentState = (int) StateIds.EventSuccess;
		_manager.NotifyEventSuccess(_eventId);
	}

	public virtual void EnterSceneFailier()
	{
		currentState = (int) StateIds.EventFail;
		_manager.NotifyEventFailier(_eventId);
	}
}

public interface IGenericScriptedEvent
{
	void StartEvent();
}
