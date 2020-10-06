using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    public GameEvent GameEvent;

    public void RaiseEvent()
    {
        GameEvent.Raise();
    }
}
