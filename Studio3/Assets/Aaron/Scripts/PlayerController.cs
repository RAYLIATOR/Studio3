using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PhotonView pv;
    PlayersManager pM;

    void Start ()
    {
        pv = GetComponent<PhotonView>();
        pM = FindObjectOfType<PlayersManager>();
        if (pM.id == 1)
        {
            transform.Rotate(0, 90, 0);
        }
        else if (pM.id == 2)
        {
            transform.Rotate(0, -90, 0);
        }
	}
	
	void Update ()
    {
        if(pv.IsMine)
        {
            MovePlayer();
        }
	}

    void MovePlayer()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 0.1f;
        }
    }
}
