using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = _listeners.Count -1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (listener == null) return;
        _listeners.Add(listener);
    }

    public void UnRegisterListener(GameEventListener listener)
    {
        if (listener == null) return;
        _listeners.Remove(listener);
    }

}
