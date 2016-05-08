using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HealthBar: MonoBehaviour {

	public float health;
	public float toxicityLevel;

	private GameObject healthfilling;



	void Start () {
		health = 1f;
		toxicityLevel = 0;
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
			health = Mathf.Clamp (health, 0, 1);
			health -= toxicityLevel;
			healthfilling.transform.DOScaleX (Mathf.Clamp (health, 0, 1), 0.45f);

			if(health <= 0)
			{
				Application.LoadLevel ("YouDied");
			}
			yield return new WaitForSeconds(0.5f);
		}
	}


	public void AddToxicity(float amount)
	{
		toxicityLevel += amount;
	}

	public void SubstractToxicity(float amount)
	{
		toxicityLevel -= amount;
	}

	public void LoseHealth(float amount)
	{
		health -= amount;
	}

}
