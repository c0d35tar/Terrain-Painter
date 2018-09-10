using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    public float scale = 0.01f;
    public GameObject brush;
	
	// Update is called once per frame
	void Update ()
	{

	}

    public void AdjustScale(float newScale)
    {
        
        scale = newScale;
        brush.transform.localScale = Vector3.one * scale;
    }
}
