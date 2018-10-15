using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sweeper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
			print(other.tag);
			other.gameObject.SetActive(false);
		}
	}
}
