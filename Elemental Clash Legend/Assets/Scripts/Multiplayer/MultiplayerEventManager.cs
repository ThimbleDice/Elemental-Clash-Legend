using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerEventManager : MonoBehaviour
{
    public delegate void NextPhaseEvent();
    public static event NextPhaseEvent NextPhase;

	public delegate void AllowCurrentPlayerToMoveEvent(int currentPlayer);
    public static event AllowCurrentPlayerToMoveEvent AllowCurrentPlayerToMove;

	public delegate void DisallowCurrentPlayerToMoveEvent(int currentPlayer);
    public static event DisallowCurrentPlayerToMoveEvent DisallowCurrentPlayerToMove;

	public delegate void AllowCurrentPlayerToFireEvent(int currentPlayer);
    public static event AllowCurrentPlayerToFireEvent AllowCurrentPlayerToFire;

	public delegate void DisallowCurrentPlayerToFireEvent(int currentPlayer);
    public static event DisallowCurrentPlayerToFireEvent DisallowCurrentPlayerToFire;

	public delegate void NextPlayerEvent(int currentPlayer, int nextPlayer);
    public static event NextPlayerEvent NextPlayer;

    public delegate void PlayerDeadEvent(int playerId);
    public static event PlayerDeadEvent PlayerDead;

    public delegate void PlayerWonEvent(int playerId);
    public static event PlayerWonEvent PlayerWon;

	public delegate void TimerEndEvent();
	public static event TimerEndEvent TimerEnd;

	public delegate void PlayerCastEvent();
	public static event PlayerCastEvent PlayerCast;

	public delegate void SpellEndEvent();
	public static event SpellEndEvent SpellEnd;

	public delegate void NextPlayerButtonClickEvent();
	public static event NextPlayerButtonClickEvent NextPlayerButtonClick;

	public static void UnsubscribeAllSubscriber()
	{
		if (NextPhase != null) {
			System.Delegate[] delegates = NextPhase.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				NextPhase -= delegates [i] as NextPhaseEvent;
			}
		}
		if (AllowCurrentPlayerToMove != null) {
			System.Delegate[] delegates = AllowCurrentPlayerToMove.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				AllowCurrentPlayerToMove -= delegates [i] as AllowCurrentPlayerToMoveEvent;
			}
		}
		if (DisallowCurrentPlayerToMove != null) {
			System.Delegate[] delegates = DisallowCurrentPlayerToMove.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				DisallowCurrentPlayerToMove -= delegates [i] as DisallowCurrentPlayerToMoveEvent;
			}
		}
		if (AllowCurrentPlayerToFire != null) {
			System.Delegate[] delegates = AllowCurrentPlayerToFire.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				AllowCurrentPlayerToFire -= delegates [i] as AllowCurrentPlayerToFireEvent;
			}
		}
		if (DisallowCurrentPlayerToFire != null) {
			System.Delegate[] delegates = DisallowCurrentPlayerToFire.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				DisallowCurrentPlayerToFire -= delegates [i] as DisallowCurrentPlayerToFireEvent;
			}
		}
		if (NextPlayer != null) {
			System.Delegate[] delegates = NextPlayer.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				NextPlayer -= delegates [i] as NextPlayerEvent;
			}
		}
		if (PlayerDead != null) {
			System.Delegate[] delegates = PlayerDead.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				PlayerDead -= delegates [i] as PlayerDeadEvent;
			}
		}
		if (PlayerWon != null) {
			System.Delegate[] delegates = PlayerWon.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				PlayerWon -= delegates [i] as PlayerWonEvent;
			}
		}
		if (TimerEnd != null) {
			System.Delegate[] delegates = TimerEnd.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				TimerEnd -= delegates [i] as TimerEndEvent;
			}
		}
		if (PlayerCast != null) {
			System.Delegate[] delegates = PlayerCast.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				PlayerCast -= delegates [i] as PlayerCastEvent;
			}
		}
		if (SpellEnd != null) {
			System.Delegate[] delegates = SpellEnd.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				SpellEnd -= delegates [i] as SpellEndEvent;
			}
		}
		if (NextPlayerButtonClick != null) {
			System.Delegate[] delegates = NextPlayerButtonClick.GetInvocationList ();
			for (int i = 0; i < delegates.Length; i++) {
				NextPlayerButtonClick -= delegates [i] as NextPlayerButtonClickEvent;
			}
		}
	}

    public static void TriggerNextPhase()
    {
        if (NextPhase != null)
            NextPhase();
    }

	public static void TriggerAllowCurrentPlayerToMove(int currentPlayer)
    {
        if (AllowCurrentPlayerToMove != null)
			AllowCurrentPlayerToMove(currentPlayer);
    }

	public static void TriggerDisallowCurrentPlayerToMove(int currentPlayer)
    {
        if (DisallowCurrentPlayerToMove != null)
			DisallowCurrentPlayerToMove(currentPlayer);
    }

	public static void TriggerAllowCurrentPlayerToFire(int currentPlayer)
    {
        if (AllowCurrentPlayerToFire != null)
			AllowCurrentPlayerToFire(currentPlayer);
    }

	public static void TriggerDisallowCurrentPlayerToFire(int currentPlayer)
    {
        if (DisallowCurrentPlayerToFire != null)
			DisallowCurrentPlayerToFire(currentPlayer);
    }

	public static void TriggerNextPlayer(int currentPlayer, int nextPlayer)
    {
        if (NextPlayer != null)
			NextPlayer(currentPlayer, nextPlayer);
    }

    public static void TriggerPlayerDead(int playerId)
    {
        if (PlayerDead != null)
            PlayerDead(playerId);
    }

    public static void TriggerPlayerWon(int playerId)
    {
        if (PlayerWon != null)
            PlayerWon(playerId);
    }

	public static void TriggerTimerEnd()
	{
		if (TimerEnd != null)
			TimerEnd();
	}

	public static void TriggerPlayerCast()
	{
		if (PlayerCast != null)
			PlayerCast();
	}

	public static void TriggerSpellEnd()
	{
		if (SpellEnd != null)
			SpellEnd();
	}

	public static void TriggerNextPlayerButtonClick()
	{
		if (NextPlayerButtonClick != null)
			NextPlayerButtonClick();
	}
}