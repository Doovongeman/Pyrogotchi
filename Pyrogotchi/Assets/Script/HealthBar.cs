using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HealthBar: MonoBehaviour {

	public float health;

	private GameObject healthfilling;



	void Start () {
		health = 0.1f;
		healthfilling = GameObject.Find ("HealthFilling");
		StartCoroutine (GiveHealth());
	}



	public void UpdateHealth(float amount)
	{
		
		health += amount;
	}



	IEnumerator GiveHealth()
	{
		while(true) 
		{			
			health += 0.01f;
			healthfilling.transform.DOScaleX (Mathf.Clamp (health, 0, 1), 0.45f);
			yield return new WaitForSeconds(0.5f);
		}
	}

}
