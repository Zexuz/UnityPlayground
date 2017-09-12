using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour {

	public float duration = 1;
	public float interval = 2;
	private float timeElapsed = 0;
	private float delay = 2;

	private float sleepDuration = 2;
	private float timeSlept = 0;
	private bool sleep = false;

	private float fadeSpeed = 2f;

	private Color c;
	
	void Start () {
		c = GetComponent<Renderer>().material.color;
	}
	// Update is called once per frame
	void Update () {
		if(!sleep){
			glow();
		} else if (sleep && timeSlept >= sleepDuration) {
			sleep = false;
			timeSlept = 0;
		} 
		else {
			sleep = true;
			timeSlept += Time.deltaTime;
		}
		
	}

	public void glow() {
		timeElapsed += Time.deltaTime;
		float fade = (0.3f * 2) / duration;
		if(timeElapsed < duration / 2) {
			float a = GetComponent<Renderer>().material.color.a + Time.deltaTime * fade;
			GetComponent<Renderer>().material.color = new Color(c.r,c.g,c.b,a);
			//Debug.Log(a);
		} else if (timeElapsed < duration) {
			float a = GetComponent<Renderer>().material.color.a - Time.deltaTime * fade;
			GetComponent<Renderer>().material.color = new Color(c.r,c.g,c.b,a);
		} 
		else {
			timeElapsed = 0;
			GetComponent<Renderer>().material.color = new Color(c.r,c.g,c.b,0.7f);
			sleep = true;
		}
	}
}
