using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerPlayerId : MonoBehaviour {
    public int id;

    public void SetId(int newId)
    {
        id = newId;
    }

    public int GetId()
    {
        return id;
    }
}
