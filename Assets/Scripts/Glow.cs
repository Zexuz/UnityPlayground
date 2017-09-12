using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow {

	public float glowDuration = 0.8f;
	private float timeElapsed = 0;
	private bool animating = false;
	private Color c;
	private float a0;
	private float a;
	private int direction;
	private float fadeSpeed;
	
	private Renderer obj;

	public Glow(Renderer obj) {
		this.obj = obj;
		c = obj.material.color;
		a0 = 0.7f;
		a = a0;
		direction = 1;
		obj.material.color = new Color(c.r,c.g,c.b,a0);
		fadeSpeed = ((1 - a) * 2) / glowDuration;
	}

	// Update is called once per frame
	public void Update (float deltaTime) {
		if(animating){
			glow(deltaTime);
		} 
	}
	
	private void glow(float deltaTime) {

		timeElapsed += deltaTime;
		
		float treshold = direction > 0 ? glowDuration / 2f : glowDuration;
		a += direction * deltaTime * fadeSpeed;

		if(timeElapsed < treshold) {
			obj.material.color = new Color(c.r,c.g,c.b,a);
		} else if(direction > 0) {
			direction = -1;
		} else {
			resetAnimation();
		}
	}

	private void resetAnimation() {
		animating = false;
		timeElapsed = 0;
		a = a0;
		obj.material.color = new Color(c.r,c.g,c.b,a);
	}

	public void InitGlow() {
		if(animating) {
			if(direction < 0) {
				timeElapsed = glowDuration - timeElapsed;
			}
		} else {
			a = a0;
		}

		direction = 1;
		animating = true;
	}
}
