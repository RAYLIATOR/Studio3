using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public int onlineID;
    public int onlineColor;
    public int offlineColorP1;
    public int offlineColorP2;
    public bool online;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
