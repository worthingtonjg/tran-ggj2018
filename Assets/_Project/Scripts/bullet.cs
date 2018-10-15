using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	public float bulletSpeed = 10f;
	private Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = transform.forward * bulletSpeed * Time.deltaTime;
	}

		/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		print(other.name);
		if(other.tag.Contains("Player"))
		{
			other.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
		}

		GameObject.Destroy(gameObject);
	}
}
