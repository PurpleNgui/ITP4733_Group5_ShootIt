using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoving : MonoBehaviour
{
    Move playerMove;
    public UIManager uIManager;

    private void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        playerMove = other.GetComponent<Move>();
        playerMove.shouldStop = true;
        uIManager.CallResult();
    }
}
