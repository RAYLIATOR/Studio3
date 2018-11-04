using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject bluePlayer;
    public GameObject redPlayer;
    PlayersManager pM;

    void Start()
    {
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
}
