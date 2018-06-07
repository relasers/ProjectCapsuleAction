using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    public float delay = 2.0f;

    IEnumerator Self_Destroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(Self_Destroy(delay));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
