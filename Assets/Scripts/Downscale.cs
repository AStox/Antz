using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downscale : MonoBehaviour {

	
	Camera cam;
	RenderTexture renderTexture;
	public int width;
	public int height;
	void Start () {
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnPreRender()
	{
		Debug.Log("sdf");
		renderTexture = RenderTexture.GetTemporary(width, height, 16, RenderTextureFormat.Default, RenderTextureReadWrite.Default, 1);
		cam.targetTexture = renderTexture;
	}
	
	void OnPostRender()
	{
		Debug.Log("454");
		cam.targetTexture = null;
		Graphics.Blit(renderTexture, null as RenderTexture);
		RenderTexture.ReleaseTemporary(renderTexture);
	}
}
