using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour {

	public float stamina;
	public float maxStamina;
	public float staminaRegen;
	public float staminaDrainPerFrame;
	public float staminaRegenPerFrame;
 	public float staminaTimeToRegen;
	void Start () 
	{
		
	}
	
	
	void Update () 
	{
		bool isFighting = Input.GetKeyDown(KeyCode.Space);

		if (isFighting)
		{
			stamina = Mathf.Clamp(stamina - (staminaDrainPerFrame * Time.deltaTime), 0.0f, maxStamina);
			staminaRegen = 0.0f;
		}
		else if (stamina < maxStamina)
		{
			if(staminaRegen >= staminaTimeToRegen)
			{
				stamina = Mathf.Clamp(stamina + (staminaRegenPerFrame * Time.deltaTime), 0.0f, maxStamina);
			}
			else
			{
				staminaRegen += Time.deltaTime;
			}
		}
	}
}
