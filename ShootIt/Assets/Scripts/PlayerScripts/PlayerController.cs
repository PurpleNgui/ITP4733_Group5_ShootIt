using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;

    public float rotateSpeed = 1.0f;

    Vector2 mouse;
    //Vector2 stick;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //--for mouse--
        mouse.x = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        mouse.y = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        xRotation -= mouse.x;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouse.y;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, -0f);
        player.transform.localRotation = Quaternion.Euler(0f, yRotation, -0f);

        //--for stick--
        //stick.x = Input.GetAxis("Vertical") * rotateSpeed * Time.deltaTime;
        //stick.y = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        //xRotation -= stick.x;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //yRotation += stick.y;
        //yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, -0f);
        //player.transform.localRotation = Quaternion.Euler(0f, yRotation, -0f);
    }
}