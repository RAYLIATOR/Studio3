using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPunObservable
{
    Animator animator;
    PhotonView pv;
    PlayersManager pM;
    float health;
    float enemyHealth;
    Image myHealthBar;
    Image enemyHealthBar;
    float minX;
    float maxX;
    Rigidbody rb;
    float force;
    int lightLevel;
    int heavyLevel;

    void Start ()
    {
        lightLevel = 1;
        heavyLevel = 1;
        //rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        force = 50f;
        minX = -3.5f;
        maxX = 3.5f;
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
            Fight();
            //Vector3.ClampMagnitude(rb.velocity, 1);
            myHealthBar.fillAmount = health / 100;
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

    void Fight()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (heavyLevel == 1)
            {
                animator.SetTrigger("Heavy1");
                enemyHealth -= 10;
            }
            else if (heavyLevel == 2)
            {
                animator.SetTrigger("Heavy2");
                enemyHealth -= 10;
            }
            else if (heavyLevel == 3)
            {
                animator.SetTrigger("Heavy3");
                enemyHealth -= 10;
            }
            if (heavyLevel < 3)
            {
                heavyLevel += 1;
            }
            else
            {
                heavyLevel = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lightLevel == 1)
            {
                animator.SetTrigger("Light1");
                enemyHealth -= 5;
            }
            else if (lightLevel == 2)
            {
                animator.SetTrigger("Light2");
                enemyHealth -= 5;
            }
            else if (lightLevel == 3)
            {
                animator.SetTrigger("Light3");
                enemyHealth -= 5;
            }
            if (lightLevel < 3)
            {
                lightLevel += 1;
            }
            else
            {
                lightLevel = 1;
            }
        }
    }

    //Mobile Controls below

    public void MoveLeft()
    {
        if (transform.position.x > minX)
        {
            rb.AddForce(Vector3.left * force);
        }
    }

    public void MoveRight()
    {
        if (transform.position.x < maxX)
        {
            rb.AddForce(Vector3.right * force);
        }
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }
}
