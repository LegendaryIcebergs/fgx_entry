using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public Dictionary<int, GameObject> ScriptedEvents;

	private Dictionary<String, int> _finishedEvents;

	private Dictionary<String, int> _failedEvents;

	private List<int> _pastEventsList;
	
	private int _currentEventInProgress;
	private bool _isEventInProgress;

	public bool RunEvents = true;

	/// <summary>
	/// These are set in Unity Editor.
	/// Right now events are executed in order they are specified here.
	/// </summary>
	public string[] EventIds;
	
	// Use this for initialization
	void Start () {
		_finishedEvents = new Dictionary<string, int>();
		_failedEvents = new Dictionary<string, int>();
		_pastEventsList = new List<int>();
		ScriptedEvents = new Dictionary<int, GameObject>();
		//TODO: Loop EventIds to ScriptedEvents
		for (int i = 0; i < EventIds.Length; i++)
		{
			//EventIds[i] ex. StreetInterview 
			ScriptedEvents.Add(i, GameObject.Find(String.Format("Event{0}Master", EventIds[i])));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (!_isEventInProgress && RunEvents )
		{
			for (int i = 0; i < ScriptedEvents.Count; i++)
			{
				FireEvent(i);
			}
		}
	}

	/// <summary>
	/// Failed event is added to dictionary for scorekeeping
	/// </summary>
	/// <param name="eventId">Event's ID</param>
	public void NotifyEventFailier(int eventId)
	{
		_failedEvents.Add(EventIds[eventId], eventId);
		_pastEventsList.Add(eventId);
		_isEventInProgress = false;

	}
	/// <summary>
	/// Successful events are added to dictionary for scorekeeping
	/// </summary>
	/// <param name="eventId"></param>
	public void NotifyEventSuccess(int eventId)
	{
		_finishedEvents.Add(EventIds[eventId], eventId);
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
