using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventStreetInterview : GenericScriptedEvent, IGenericScriptedEvent
{

	private int _eventId = 0;

	private StateIds _stateIds;

	private int currentState;

	private bool _sceneSuccess;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		switch (_stateIds)
		{
			case StateIds.EventStart:
				//Use this to init scene and stuff
				//When ready call EnterSceneOne()
				EnterSceneOne();
				break;
			case StateIds.EventSceneOne:
				//Do shit
				//after shit is done, call EnterSceneTwo()
				//or if first scene was failed call EnterSceneFailier()
				EnterSceneTwo();
				break;
			case StateIds.EventSceneTwo:
				//Do shit:
				EnterSceneSuccess();
				break;
			case StateIds.EventSuccess:
				//Do shit
			case StateIds.EventFail:
				//Do shit
			default:
				break;
			
		}
	}

	public override void EnterSceneOne()
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

	public override void EnterSceneTwo()
	{
		base.EnterSceneTwo();
	}

	public override void EnterSceneSuccess()
	{
		currentState = (int) StateIds.EventFail;
		Manager.NotifyEventSuccess(_eventId);	
	}

	public override void EnterSceneFailier()
	{
		currentState = (int) StateIds.EventFail;
		Manager.NotifyEventFailier(_eventId);	
	}

	public void StartEvent()
	{
		currentState = (int)StateIds.EventStart;
	}
}
