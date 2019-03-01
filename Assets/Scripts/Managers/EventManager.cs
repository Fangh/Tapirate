using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;

public class EventManager : MonoBehaviour
{

    private Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    public static EventManager Instance;

    EventManager()
    {
        Instance = this;
        Init();
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Action>();
        }
    }

    public static void Bind(string eventName, Action listener)
    {
        Action thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent += listener;
        }
        else
        {
            thisEvent+= listener;
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void Unbind(string eventName, Action listener)
    {
        if (Instance == null) return;
        Action thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent-= listener;
        }
    }

    public static void Trigger(string eventName)
    {
        Action thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}