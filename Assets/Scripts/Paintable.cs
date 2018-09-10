using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public GameObject Brush;
    public RenderTexture renderTexture;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	    if (Input.GetMouseButton(0))
	    {
	        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;
	        if (Physics.Raycast(ray, out hit))
	        {
	            var paint = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
	        }
	    }

	}

    public void Save()
    {
        StartCoroutine(CoSave());
    }

    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log(Application.dataPath + "/savedImage.png");

        RenderTexture.active = renderTexture;

        var texture2D = new Texture2D(renderTexture.width, renderTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        var data = texture2D.EncodeToPNG();

        File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);
    }
}
