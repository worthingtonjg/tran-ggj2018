using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Fungus;
using System.IO;

public class videoController : MonoBehaviour {
	VideoPlayer videoPlayer;

	// Use this for initialization
	public Flowchart fungus;
	public string videoFile;

	void Start () {
		videoPlayer = GetComponent<VideoPlayer>();

		string url = Path.Combine(Application.streamingAssetsPath, videoFile);

		videoPlayer.url = url;
		videoPlayer.loopPointReached += EndReached;
		videoPlayer.Play();
	}

    private void EndReached(VideoPlayer source)
    {
        fungus.ExecuteBlock("NextScene");
    }
}
