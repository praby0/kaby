using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterPositionWhenInPianoRange : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPosition()
    {
        return player.transform.position;
    }
}
