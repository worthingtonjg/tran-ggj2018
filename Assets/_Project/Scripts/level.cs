using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Fungus;

public class level : MonoBehaviour {
	List<Vector3> startPlayers1;
	List<Vector3> startPlayers2;
	List<Vector3> startEnemies1;
	List<Vector3> startEnemies2;

	GameObject[] players1;
	GameObject[] players2;
	GameObject[] enemies1;
	GameObject[] enemies2;

	private static level _instance;
	
    public static level Instance { get { return _instance; } }

	public Text WinText;
	public Flowchart fungus;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

	// Use this for initialization
	void Start () {
		players1 = GameObject.FindGameObjectsWithTag("Player1");
		players2 = GameObject.FindGameObjectsWithTag("Player2");
		
		enemies1 = GameObject.FindGameObjectsWithTag("Enemy1");
		enemies2 = GameObject.FindGameObjectsWithTag("Enemy2");

		startPlayers1 = players1.Select(p => p.transform.position).ToList();
		startPlayers2 = players2.Select(p => p.transform.position).ToList();

		startEnemies1 = enemies1.Select(p => p.transform.position).ToList();
		startEnemies2 = enemies2.Select(p => p.transform.position).ToList();
	}
	
	public void ResetGame(string player)
	{
		if(player == "Player1")
		{
			for(int index = 0; index < players1.Length; index ++)
			{
				players1[index].transform.position = startPlayers1[index];
			}
		
			for(int index = 0; index < enemies1.Length; index ++)
			{
				enemies1[index].transform.position = startEnemies1[index];
				enemies1[index].SetActive(true);
			}
		}
		
		if(player == "Player2")
		{
			for(int index = 0; index < players2.Length; index ++)
			{
				players2[index].transform.position = startPlayers2[index];
			}
		
			for(int index = 0; index < enemies2.Length; index ++)
			{
				enemies2[index].transform.position = startEnemies2[index];
				enemies2[index].SetActive(true);
			}
		}
	}

	public void WinGame(string player)
	{
		GameObject p1 = players1.FirstOrDefault();
		CameraFly p1CamScript = p1.GetComponent<CameraFly>();
		p1CamScript.enabled = false;

		GameObject p2 = players2.FirstOrDefault();
		CameraFly p2CamScript = p2.GetComponent<CameraFly>();
		p2CamScript.enabled = false;

		for(int index = 0; index < enemies1.Length; index ++)
		{
			enemies1[index].SetActive(false);
		}

		for(int index = 0; index < enemies2.Length; index ++)
		{
			enemies2[index].SetActive(false);
		}

		if(player == "Player1")
		{
			WinText.text = "Player 1 wins!";
		}

		if(player == "Player2")
		{
			WinText.text = "Player 1 wins!";
		}

		fungus.ExecuteBlock("EndLevel");
	}
}
