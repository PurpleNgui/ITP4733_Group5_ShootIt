using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;

    public float rotateSpeed = 1.0f;

    Vector2 mouse;
    Vector2 stick;
    float xRotation;
    float yRotation;

    Rigidbody rb;

    PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
        }
    }

    void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
        PV = GetComponentInParent<PhotonView>();  //task6c
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
        stick.x = Input.GetAxis("Vertical") * rotateSpeed * Time.deltaTime;
        stick.y = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        xRotation -= stick.x;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += stick.y;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, -0f);
        player.transform.localRotation = Quaternion.Euler(0f, yRotation, -0f);

        if (!PV.IsMine)  //task6c
            return;
    }

    void FixedUpdate()
    {
        if (!PV.IsMine)   //task6c
            return;
    }

}