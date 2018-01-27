using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour {

	/// <summary>
	/// These are set in Unity Editor.
	/// Right now events are executed in order they are specified here.
	/// </summary>
	public enum EventIds
	{
		StreetInterview
	}

	public Dictionary<int, GameObject> ScriptedEvents;

	private Dictionary<String, int> _finishedEvents;

	private Dictionary<String, int> _failedEvents;

	private List<int> _pastEventsList;
	
	private int _currentEventInProgress;
	private bool _isEventInProgress;

	public bool RunEvents = true;
	
	// Use this for initialization
	void Start () {
		_finishedEvents = new Dictionary<string, int>();
		_failedEvents = new Dictionary<string, int>();
		_pastEventsList = new List<int>();
		ScriptedEvents = new Dictionary<int, GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (!_isEventInProgress && RunEvents )
		{
			if (_pastEventsList.Count == 0)
			{
				FireEvent(0);
			}
			FireEvent(_pastEventsList.Last() + 1); //This fires the next event specified in EventIds
		}
	}

	/// <summary>
	/// Failed event is added to dictionary for scorekeeping
	/// </summary>
	/// <param name="eventId">Event's ID</param>
	public void NotifyEventFailier(int eventId)
	{
		EventIds eid = (EventIds) eventId;
		_failedEvents.Add(eid.ToString(), eventId);
		_pastEventsList.Add(eventId);
		_isEventInProgress = false;

	}
	/// <summary>
	/// Successful events are added to dictionary for scorekeeping
	/// </summary>
	/// <param name="eventId"></param>
	public void NotifyEventSuccess(int eventId)
	{
		EventIds eid = (EventIds) eventId;
		_finishedEvents.Add(eid.ToString(), eventId);
		_pastEventsList.Add(eventId);
		_isEventInProgress = false;
	}

	private void FireEvent(int eventId)
	{
		_currentEventInProgress = eventId;
		_isEventInProgress = true;
		ScriptedEvents[eventId].GetComponent<IGenericScriptedEvent>().StartEvent();
	}
}
