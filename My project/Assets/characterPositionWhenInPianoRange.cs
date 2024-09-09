using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterPositionWhenInPianoRange : MonoBehaviour
{
    public GameObject player;
    public GuardMovements guardMovements;
    public Vector3 playerPosition()
    {
        if(guardMovements.player_revealed == true)
        {
            guardMovements.player_revealed = false;
            return player.transform.position;
        }
        return new Vector3();
    }
}
