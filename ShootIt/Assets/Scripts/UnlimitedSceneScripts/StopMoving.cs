using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoving : MonoBehaviour
{
    Move playerMove;

    private void OnTriggerEnter(Collider other)
    {

        playerMove = other.GetComponent<Move>();
        playerMove.shouldStop = true;
    }
}
