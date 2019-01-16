using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfflineController : MonoBehaviour
{
    MenuManager menuManager;
    Animator animator;
    public GameObject Player1;
    public GameObject Player2;
    public float moveSpeed;

    public Image P1HealthBar;
    public Image P2HealthBar;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        animator = GetComponent<Animator>();
        Player1 = GameObject.FindGameObjectWithTag("p1");
        Player2 = GameObject.FindGameObjectWithTag("p2");

        //Player1.transform.Rotate(0, 90, 0);
        P1HealthBar = GameObject.FindGameObjectWithTag("hb1").GetComponent<Image>(); 
        //Player2.transform.Rotate(0, -90, 0);
        P2HealthBar = GameObject.FindGameObjectWithTag("hb2").GetComponent<Image>(); 
            
    }

    void FixedUpdate()
    {
        {
            if (P2HealthBar.fillAmount <= 0)
            {
                menuManager.P1Wins();
            }

            else if (P1HealthBar.fillAmount <= 0)
            {
                menuManager.P2Wins();
            }
        }

        if (Input.GetKey(KeyCode.D) && Player1 != null)
        {
            Player1.GetComponent<Rigidbody>().AddForce(Vector3.right * moveSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A) && Player1 != null)
        {
            Player1.GetComponent<Rigidbody>().AddForce(Vector3.left * moveSpeed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.W) && Player1 != null)
        {
            Player1.GetComponent<Animator>().SetTrigger("Heavy1");
            P2HealthBar.fillAmount -= moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.S) && Player1 != null)
        {
            Player1.GetComponent<Animator>().SetTrigger("Light1");
            P2HealthBar.fillAmount -= moveSpeed;
        }

        
        
        if (Input.GetKey(KeyCode.L) && Player2 != null)
        {
            Player2.GetComponent<Rigidbody>().AddForce(Vector3.right * moveSpeed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.J) && Player2 != null)
        {
            Player2.GetComponent<Rigidbody>().AddForce(Vector3.left * moveSpeed, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.I) && Player2 != null)
        {
            Player2.GetComponent<Animator>().SetTrigger("Heavy1");
            P1HealthBar.fillAmount -= moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.K) && Player2 != null)
        {
            Player2.GetComponent<Animator>().SetTrigger("Light1");
            P1HealthBar.fillAmount -= moveSpeed;
        }
    }
}
