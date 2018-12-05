using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour {

	public Slider staminaBar;
	public float stamina;
	public float maxStamina;
	public float staminaRegen;
	public float staminaDrainPerFrame;
	public float staminaRegenPerFrame;
 	public float staminaTimeToRegen;
	void Start () 
	{
		staminaBar.value = 100;
	}
	
	
	void Update () 
	{
		bool isFighting = Input.GetKeyDown(KeyCode.Space);

		if (isFighting)
		{
			stamina = Mathf.Clamp(stamina - (staminaDrainPerFrame * Time.deltaTime), 0.0f, maxStamina);
			staminaRegen = 0.0f;
			staminaBar.value = staminaDrainPerFrame;
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
				staminaBar.value = staminaRegenPerFrame;
			}
		}
	}
}
