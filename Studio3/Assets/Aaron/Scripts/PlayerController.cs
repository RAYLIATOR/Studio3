using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPunObservable
{
    PhotonView pv;
    PlayersManager pM;
    float health;
    float enemyHealth;
    Image myHealthBar;
    Image enemyHealthBar;

    void Start ()
    {
        pv = GetComponent<PhotonView>();
        pM = FindObjectOfType<PlayersManager>();
        if (pM.id == 1)
        {
            transform.Rotate(0, 90, 0);
            myHealthBar = GameObject.FindGameObjectWithTag("hb1").GetComponent<Image>();
            enemyHealthBar = GameObject.FindGameObjectWithTag("hb2").GetComponent<Image>();
        }
        else if (pM.id == 2)
        {
            transform.Rotate(0, -90, 0);
            myHealthBar = GameObject.FindGameObjectWithTag("hb2").GetComponent<Image>();
            enemyHealthBar = GameObject.FindGameObjectWithTag("hb1").GetComponent<Image>();
        }
        health = 100;
	}
	
	void Update ()
    {
        if (pv.IsMine)
        {
            MovePlayer();
            myHealthBar.fillAmount = health / 100;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                health -= 10;
            }
        }
        else
        {
            enemyHealthBar.fillAmount = enemyHealth / 100;
        } 
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.Serialize(ref health);
        }
        else
        {
             stream.Serialize(ref enemyHealth);
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
