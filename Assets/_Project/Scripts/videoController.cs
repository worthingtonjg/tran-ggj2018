using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Fungus;

public class videoController : MonoBehaviour {
	VideoPlayer videoPlayer;

	// Use this for initialization
	public Flowchart fungus;

	void Start () {
		videoPlayer = GetComponent<VideoPlayer>();
		videoPlayer.loopPointReached += EndReached;
	}

    private void EndReached(VideoPlayer source)
    {
        fungus.ExecuteBlock("NextScene");
    }
}
