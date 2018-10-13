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

	public string videoFile;

	void Start () {
		string url = string.Empty;

		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			url = System.IO.Path.Combine (Application.streamingAssetsPath, videoFile);
		}
		else
		{
			url = System.IO.Path.Combine (Application.streamingAssetsPath, videoFile);
		}
			

		videoPlayer = GetComponent<VideoPlayer>();
		videoPlayer.loopPointReached += EndReached;
		videoPlayer.url = url;
		videoPlayer.Play();
	}

    private void EndReached(VideoPlayer source)
    {
        fungus.ExecuteBlock("NextScene");
    }
}
