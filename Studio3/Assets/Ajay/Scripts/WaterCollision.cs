using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour {

	private int waveNumber;
	public  float distanceX, distanceZ;
	public float [] waveAmp;
	public float magnitudeDivider;
	public Vector2[] impactPos;
	public float [] distance;
	public float speedWaveSpread;
	Mesh mesh;
	void Start () 
	{
		mesh = GetComponent<MeshFilter>().mesh;
	}
	
	
	void Update () 
	{
		for (int i = 0; i < 8; i++)
		{
			//i is set to 0, but the waveAmp starts at 1, so i+1
			waveAmp[i] = GetComponent<Renderer>().material.GetFloat("_WaveAmp" + (i+1));
			if(waveAmp[i] > 0)
			{
				distance[i] += speedWaveSpread;
				GetComponent<Renderer>().material.SetFloat("_Distance" + (i+1), distance[i]); 
				GetComponent<Renderer>().material.SetFloat("_WaveAmp" + (i+1), waveAmp[i] * 0.98f);
			}
			if(waveAmp[i] < 0.01 )
			{
				GetComponent<Renderer>().material.SetFloat("_WaveAmp" + (i+1), 0);
				distance[i] = 0;
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.rigidbody)
		{
			waveNumber++;;
			//Since there are only gonna be 8 value sets, so once it reaches 9, resets back to 1
			if (waveNumber == 9)
			{
				waveNumber = 1;
			}
			//Arrays start at zero not one, so minus 1
			waveAmp[waveNumber - 1] = 0;
			distance[waveNumber-1] = 0;

			distanceX = this.transform.position.x - col.gameObject.transform.position.x;
			distanceZ = this.transform.position.z - col.gameObject.transform.position.z;
			impactPos[waveNumber-1].x = col.transform.position.x;
			//Vector 2 has x and y, the y of this will be the z
			impactPos[waveNumber-1].y = col.transform.position.z;

			GetComponent<Renderer>().material.SetFloat("_xImpact" + waveNumber, col.transform.position.x);
			GetComponent<Renderer>().material.SetFloat("_zImpact" + waveNumber, col.transform.position.z);

			GetComponent<Renderer>().material.SetFloat("_OffsetX" + waveNumber, distanceX / mesh.bounds.size.x * 2.5f);
			GetComponent<Renderer>().material.SetFloat("_OffsetZ" + waveNumber, distanceZ / mesh.bounds.size.z * 2.5f);

			GetComponent<Renderer>().material.SetFloat("_WaveAmp" + waveNumber, col.rigidbody.velocity.magnitude * magnitudeDivider);
		}
	}
}
