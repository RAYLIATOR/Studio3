using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviourPun, IPunObservable
{
    public GameObject waitingPanel;
    public GameObject bluePlayer;
    public GameObject redPlayer;
    PlayersManager pM;
    PhotonView pv;

    [PunRPC]
    void StopWaiting()
    {
        waitingPanel.SetActive(false);
    }

    void Start()
    {
        pv = GetComponent<PhotonView>();
        pM = FindObjectOfType<PlayersManager>();
        if(pM.id==1)
        {
            if(pM.color == 1)
            {
                PhotonNetwork.Instantiate(bluePlayer.name, new Vector3(-2, 0, -6.5f), Quaternion.identity);
            }
            else if(pM.color == 2)
            {
                PhotonNetwork.Instantiate(redPlayer.name, new Vector3(-2, 0, -6.5f), Quaternion.identity);
            }
            else
            {
                int i = Random.Range(1, 3);
                if (i == 1)
                {
                    PhotonNetwork.Instantiate(bluePlayer.name, new Vector3(-2, 0, -6.5f), Quaternion.identity);
                }
                else if (i == 2)
                {
                    PhotonNetwork.Instantiate(redPlayer.name, new Vector3(-2, 0, -6.5f), Quaternion.identity);
                }
            }
        }
        else if (pM.id == 2)
        {
            pv.RPC("StopWaiting", RpcTarget.All);
            if (pM.color == 1)
            {
                PhotonNetwork.Instantiate(bluePlayer.name, new Vector3(2, 0, -6.5f), Quaternion.identity);
            }
            else if (pM.color == 2)
            {
                PhotonNetwork.Instantiate(redPlayer.name, new Vector3(2, 0, -6.5f), Quaternion.identity);
            }
            else
            {
                int i = Random.Range(1, 3);
                if (i == 1)
                {
                    PhotonNetwork.Instantiate(bluePlayer.name, new Vector3(2, 0, -6.5f), Quaternion.identity);
                }
                else if (i == 2)
                {
                    PhotonNetwork.Instantiate(redPlayer.name, new Vector3(2, 0, -6.5f), Quaternion.identity);
                }
            }
        }
    }

    void Update()
    {

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
}
