using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviourPun, IPunObservable
{
    public GameObject victoryPanel;
    GameObject waitingPanel;
    public GameObject bluePlayerOnline;
    public GameObject redPlayerOnline;
    public GameObject bluePlayerOffline;
    public GameObject redPlayerOffline;
    public GameObject greenPlayerOffline;
    public GameObject yellowPlayerOffline;
    public GameObject player1;
    public GameObject player2;
    PlayersManager pM;
    PhotonView pv;
    bool twoPlayersConnected;

    [PunRPC]
    void StopWaiting()
    {
        waitingPanel = GameObject.FindGameObjectWithTag("waiting");
        waitingPanel.SetActive(false);
    }

    public void Instatiation()
    {
        pv = GetComponent<PhotonView>();
        pM = FindObjectOfType<PlayersManager>();
        if (pM.online)
        {
            if (pM.onlineID == 1)
            {
                if (pM.onlineColor == 1)
                {
                    player1 = PhotonNetwork.Instantiate(bluePlayerOnline.name, new Vector3(-2, 0, -6.5f), Quaternion.identity);
                    
                }
                else if (pM.onlineColor == 2)
                {
                    player1 = PhotonNetwork.Instantiate(redPlayerOnline.name, new Vector3(-2, 0, -6.5f), Quaternion.identity);
                }
                else
                {
                    int i = Random.Range(1, 3);
                    if (i == 1)
                    {
                        player1 = PhotonNetwork.Instantiate(bluePlayerOnline.name, new Vector3(-2, 0, -6.5f), Quaternion.identity);
                    }
                    else if (i == 2)
                    {
                        player1 = PhotonNetwork.Instantiate(redPlayerOnline.name, new Vector3(-2, 0, -6.5f), Quaternion.identity);
                    }
                }
            }
            else if (pM.onlineID == 2)
            {
                pv.RPC("StopWaiting", RpcTarget.All);
                if (pM.onlineColor == 1)
                {
                    player2 = PhotonNetwork.Instantiate(bluePlayerOnline.name, new Vector3(2, 0, -6.5f), Quaternion.identity);
                    player2.GetComponent<PlayerController>().Init();
                    player1.GetComponent<PlayerController>().Init();
                }
                else if (pM.onlineColor == 2)
                {
                    player2 = PhotonNetwork.Instantiate(redPlayerOnline.name, new Vector3(2, 0, -6.5f), Quaternion.identity);
                    player2.GetComponent<PlayerController>().Init();
                    player1.GetComponent<PlayerController>().Init();
                }
                else
                {
                    int i = Random.Range(1, 3);
                    if (i == 1)
                    {
                        player2 = PhotonNetwork.Instantiate(bluePlayerOnline.name, new Vector3(2, 0, -6.5f), Quaternion.identity);
                        player2.GetComponent<PlayerController>().Init();
                        player1.GetComponent<PlayerController>().Init();
                    }
                    else if (i == 2)
                    {
                        player2 = PhotonNetwork.Instantiate(redPlayerOnline.name, new Vector3(2, 0, -6.5f), Quaternion.identity);
                        player2.GetComponent<PlayerController>().Init();
                        player1.GetComponent<PlayerController>().Init();
                    }
                }
            }
        }
        else if(!pM.online)
        {
            if(pM.offlineColorP1 == 1)
            {
                GameObject p1 =  Instantiate(bluePlayerOffline, new Vector3(-2, 0, -6.5f), Quaternion.identity) as GameObject;
                p1.tag = "p1";
            }
            else if(pM.offlineColorP1 == 2)
            {
                GameObject p1 = Instantiate(redPlayerOffline, new Vector3(-2, 0, -6.5f), Quaternion.identity) as GameObject;
                p1.tag = "p1";
            }
            else if (pM.offlineColorP1 == 3)
            {
                GameObject p1 = Instantiate(greenPlayerOffline, new Vector3(-2, 0, -6.5f), Quaternion.identity) as GameObject;
                p1.tag = "p1";
            }
            else if (pM.offlineColorP1 == 4)
            {
                GameObject p1 = Instantiate(yellowPlayerOffline, new Vector3(-2, 0, -6.5f), Quaternion.identity) as GameObject;
                p1.tag = "p1";
            }

            if (pM.offlineColorP2 == 1)
            {
                GameObject p2 = Instantiate(bluePlayerOffline, new Vector3(2, 0, -6.5f), Quaternion.identity) as GameObject;
                p2.tag = "p2";
            }
            else if (pM.offlineColorP2 == 2)
            {
                GameObject p2 = Instantiate(redPlayerOffline, new Vector3(2, 0, -6.5f), Quaternion.identity) as GameObject;
                p2.tag = "p2";
            }
            else if (pM.offlineColorP2 == 3)
            {
                GameObject p2 = Instantiate(greenPlayerOffline, new Vector3(2, 0, -6.5f), Quaternion.identity) as GameObject;
                p2.tag = "p2";
            }
            else if (pM.offlineColorP2 == 4)
            {
                GameObject p2 = Instantiate(yellowPlayerOffline, new Vector3(2, 0, -6.5f), Quaternion.identity) as GameObject;
                p2.tag = "p2";
            }
        }
    }

    void Update()
    {

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }
}
