using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class baseEntered : MonoBehaviour {
	public string baseOwner;
	public Flowchart fungus;

	public Text WinText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Contains("Player") && other.tag != baseOwner)		
		{
			bool win = false;
			if(other.tag == "Player1")
			{
				WinText.text = "Player 1 wins!";
				win = true;
			}
			
			if(other.tag == "Player2")
			{
				WinText.text = "Player2 wins!";
				win = true;
			}

			if(win)
			{
				fungus.ExecuteBlock("EndLevel");
			}
		}
	}
}
