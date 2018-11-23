using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerEventManager : MonoBehaviour
{
    public delegate void NextPhaseEvent();
    public static event NextPhaseEvent NextPhase;

    public delegate void AllowCurrentPlayerToMoveEvent();
    public static event AllowCurrentPlayerToMoveEvent AllowCurrentPlayerToMove;

    public delegate void DisallowCurrentPlayerToMoveEvent();
    public static event DisallowCurrentPlayerToMoveEvent DisallowCurrentPlayerToMove;

    public delegate void AllowCurrentPlayerToFireEvent();
    public static event AllowCurrentPlayerToFireEvent AllowCurrentPlayerToFire;

    public delegate void DisallowCurrentPlayerToFireEvent();
    public static event DisallowCurrentPlayerToFireEvent DisallowCurrentPlayerToFire;

    public delegate void NextPlayerEvent();
    public static event NextPlayerEvent NextPlayer;

    public static void TriggerNextPhase()
    {
        if (NextPhase != null)
            NextPhase();
    }

    public static void TriggerAllowCurrentPlayerToMove()
    {
        if (AllowCurrentPlayerToMove != null)
            AllowCurrentPlayerToMove();
    }

    public static void TriggerDisallowCurrentPlayerToMove()
    {
        if (DisallowCurrentPlayerToMove != null)
            DisallowCurrentPlayerToMove();
    }

    public static void TriggerAllowCurrentPlayerToFire()
    {
        if (AllowCurrentPlayerToFire != null)
            AllowCurrentPlayerToFire();
    }

    public static void TriggerDisallowCurrentPlayerToFire()
    {
        if (DisallowCurrentPlayerToFire != null)
            DisallowCurrentPlayerToFire();
    }

    public static void TriggerNextPlayer()
    {
        if (NextPlayer != null)
            NextPlayer();
    }
}