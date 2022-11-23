using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 mouseTurn;
    private Vector2 joystickTurn;
    private Vector2 previousMouseTurn = new Vector2(1, 1);
    private Vector2 previousJoystickTurn = new Vector2(1, 1);
    [SerializeField] GameObject player;

    public float rotateSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        joystickTurn.x += Input.GetAxis("Horizontal") * rotateSpeed;
        joystickTurn.y += Input.GetAxis("Vertical") * rotateSpeed;

        mouseTurn.x += Input.GetAxis("Mouse X") * rotateSpeed;
        mouseTurn.y += Input.GetAxis("Mouse Y") * rotateSpeed;

        if (joystickTurn.x != previousJoystickTurn.x || joystickTurn.y != previousJoystickTurn.y)
        {
            player.transform.localRotation = Quaternion.Euler(0, joystickTurn.x, 0);
            transform.localRotation = Quaternion.Euler(-joystickTurn.y, 0, 0);

            if (transform.rotation.x < -45)
            {
                transform.rotation = Quaternion.Euler(-45, 0, 0);
            }
            if (transform.rotation.x > 30)
            {
                transform.rotation = Quaternion.Euler(30, 0, 0);
            }
        }
        else if (mouseTurn.x != previousMouseTurn.x || mouseTurn.y != previousMouseTurn.y)
        {
            player.transform.localRotation = Quaternion.Euler(0, mouseTurn.x, 0);
            transform.localRotation = Quaternion.Euler(-mouseTurn.y, 0, 0);
        }

        previousJoystickTurn = joystickTurn;
        previousMouseTurn = mouseTurn;
    }
}