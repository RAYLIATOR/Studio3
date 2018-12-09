using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfflinePlayerController : MonoBehaviour
{
    MenuManager menuManager;
    Animator animator;
    public Image enemyHealthBar;

    void Start ()
    {
        menuManager = FindObjectOfType<MenuManager>();
        animator = GetComponent<Animator>();

        if(gameObject.tag == "p1")
        {
            transform.Rotate(0, 90, 0);
            enemyHealthBar = GameObject.FindGameObjectWithTag("hb2").GetComponent<Image>(); ;
        }
        else if (gameObject.tag == "p2")
        {
            transform.Rotate(0, -90, 0);
            enemyHealthBar = GameObject.FindGameObjectWithTag("hb1").GetComponent<Image>(); ;
        }
    }
	
	void Update ()
    {
        if (gameObject.tag == "p1")
        {
            MoveP1();
            if (enemyHealthBar.fillAmount <= 0)
            {
                menuManager.OfflineVictoryScreen("player1");
            }
        }
        else if (gameObject.tag == "p2")
        {
            MoveP2();
            if (enemyHealthBar.fillAmount <= 0)
            {
                menuManager.OfflineVictoryScreen("player2");
            }
        }
    }

    void MoveP1()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Heavy1");
            enemyHealthBar.fillAmount -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Light1");
            enemyHealthBar.fillAmount -= 0.05f;
        }
    }

    void MoveP2()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("Heavy1");
            enemyHealthBar.fillAmount -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("Light1");
            enemyHealthBar.fillAmount -= 0.05f;
        }
    }
}
