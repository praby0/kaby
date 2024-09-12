using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterPositionWhenInPianoRange : MonoBehaviour
{
    public GameObject player;
    public GuardMovements guardMovements;
    private float playerWaitSeconds;
    private float maxPlayerWaitSeconds = 0.5f;
    public bool playerWait = false;
    public Vector3 playerPos;
    public void Update()
    {
        playerWaitSeconds += Time.deltaTime;
        if (playerWaitSeconds > maxPlayerWaitSeconds)
        {
            playerWait = true;
            playerPos = player.transform.position;
            playerWaitSeconds = 0.0f;
            //print("going closer to player position");
            playerWait = false;
        }
    }
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
