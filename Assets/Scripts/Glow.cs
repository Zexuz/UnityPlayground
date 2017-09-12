using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow {

	public float glowDuration = 0.6f;
	private float timeElapsed = 0;
	private bool animating = false;
	private Color c;
	private float a0;
	
	private Renderer obj;

	public Glow(Renderer obj) {
		this.obj = obj;
		c = obj.material.color;
		a0 = 0.7f;
		obj.material.color = new Color(c.r,c.g,c.b,a0);
	}

	// Update is called once per frame
	public void Update (float deltaTime) {
		if(animating){
			glow(deltaTime);
		} 
	}

	private void glow(float deltaTime) {

		timeElapsed += deltaTime;
		float fade = ((1 - a0) * 2) / glowDuration;

		if(timeElapsed < glowDuration / 2f) {
			float a = obj.material.color.a + deltaTime * fade;
			obj.material.color = new Color(c.r,c.g,c.b,a);
		} else if (timeElapsed < glowDuration) {
			float a = obj.material.color.a - deltaTime * fade;
			obj.material.color = new Color(c.r,c.g,c.b,a);
		} else {
			animating = false;
			timeElapsed = 0;
			obj.material.color = new Color(c.r,c.g,c.b,a0);
		}
	}

	public void InitGlow() {
		animating = true;
	}

	
}
