using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFly : MonoBehaviour 
{
	public enum EnumPlayer { player1, player2 }

	public EnumPlayer playerType;
	public float speed = 3f;
	public float steerSpeed = 3f;
	public float autoCorrectionSpeed = 3f;
	public float maxTilt = 10f;
	public float tiltSpeed = 25f;
	public GameObject cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = 0f;
		
		if(playerType == EnumPlayer.player1)
		{
			h = Input.GetAxis("HorizontalP1");
		}
		else
		{
			h = Input.GetAxis("HorizontalP2");
		}

		this.transform.Translate(new Vector3(h * Time.deltaTime * steerSpeed, 0, speed * Time.deltaTime ));

		if(h > 0 && (cam.transform.localEulerAngles.z <= maxTilt || cam.transform.localEulerAngles.z >= 360-maxTilt))
		{
			print(cam.transform.localEulerAngles.z);
			cam.transform.Rotate(Vector3.forward * Time.deltaTime * -tiltSpeed);
		}

		if(h < 0 && (cam.transform.localEulerAngles.z <= maxTilt || cam.transform.localEulerAngles.z >= 360-maxTilt))
		{
			print(cam.transform.localEulerAngles.z);
			cam.transform.Rotate(Vector3.forward * Time.deltaTime * tiltSpeed);
		}

		if(h == 0 && cam.transform.localEulerAngles.z != 0)
		{
			var wantedrotation = new Vector3(cam.transform.rotation.eulerAngles.x, cam.transform.rotation.eulerAngles.y, 1); 
			cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(wantedrotation), Time.deltaTime * autoCorrectionSpeed);
		}


	}
}
