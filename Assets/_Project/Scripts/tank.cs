using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour {
	public enum EnumPlayer { Player1, Player2 }
	
	public EnumPlayer playerType;
	public float rotationSpeed = 25f;
	public float speed = 10f;
	public GameObject gunMount;
	public float gunSpeed = 100f;
	public GameObject BulletSpawner;
	public GameObject BulletPrefab;
	private bool rotateGun;
	private Vector3 originalPosition;

	private bool stunned;
	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerType == EnumPlayer.Player1)
		{
			ProcessKeys("P1");
		}
		else
		{
			ProcessKeys("P2");
		}
	}

	private void ProcessKeys(string player)
	{
		if(stunned) return;

		if(Input.GetAxis("Turret"+player) != 0) 
		{
			float h = Input.GetAxis("Turret"+player);

			if(h != 0)
			{
				gunMount.transform.Rotate(0, Time.deltaTime * gunSpeed * h, 0, Space.Self);
			}
		}
		else
		{
			float h = Input.GetAxis("Horizontal"+player);

			if(h != 0)
			{
				transform.Rotate(0, Time.deltaTime * rotationSpeed * h, 0, Space.Self);
			}
		}

		float v = Input.GetAxis("Vertical"+player);
		if(v > 0 || v <0)
		{
			transform.Translate(transform.forward * speed * v * Time.deltaTime, Space.World);
		}

		if(Input.GetButtonDown("Fire"+player))
		{
			print("fire "+player);
			GameObject bullet = GameObject.Instantiate(BulletPrefab, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
			GameObject.Destroy(bullet, 5f);
		}
	}

	public void TakeDamage()
	{
		StartCoroutine(Stunned());
	}

	private IEnumerator Stunned()
	{
		stunned = true;
		yield return new WaitForSeconds(3);
		stunned = false;
	}
}
