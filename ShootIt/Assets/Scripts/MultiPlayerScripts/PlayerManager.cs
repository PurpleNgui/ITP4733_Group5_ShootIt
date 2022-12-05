using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
	PhotonView PV;

	GameObject controller;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if (PV.IsMine)
		{
			//CreateController();
			if (PhotonNetwork.IsMasterClient)
            {
				CreateController();
            }
            else
            {
				controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), new Vector3(2, 0, 0), Quaternion.identity, 0, new object[] { PV.ViewID });
			}
		}
	}

	//task10
	void CreateController()
	{
		Debug.Log("Instantiated player controller");
		controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity, 0, new object[] { PV.ViewID });
	}

	//task10
	public void Die()
	{
		PhotonNetwork.Destroy(controller);
		CreateController();
	}
}
