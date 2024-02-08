﻿using System.Collections.ObjectModel;

using CQRS_EventSourcing.EventBus.Interfaces;
using CQRS_EventSourcing.Events.Interfaces;

namespace CQRS_EventSourcing.EventBus.Implementations;

public class EventBus : IEventBusSender, IEventBusReceiver
{
    private Queue<IEvent> _eventQueue;

    public EventBus()
    {
        _eventQueue = new Queue<IEvent>();
    }
    
    public void SendEvent(IEvent e)
    {
        var eventArg = new EventReceivedArg(e);
        EventReceived?.Invoke(this, eventArg);
    }

    public Queue<IEvent> GetAllEvents()
    {
        return _eventQueue;
    }
    
    public event EventHandlerWithArg EventReceived;
}