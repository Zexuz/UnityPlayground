using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow {

	public float glowDuration = 0.5f;
	private float timeElapsed = 0;
	private bool animating = false;
	private Color color;
	public Color fadeColor;

	private int direction;
	private float rSpeed;
	private float gSpeed;
	private float bSpeed;

	private float r;
	private float g;
	private float b;
	
	private Renderer obj;

	public Glow(Renderer obj) {
		this.obj = obj;
		color = obj.material.color;
		fadeColor = new Color(0.92f,0.92f,0.92f);
		direction = 1;		
		
		rSpeed = ((fadeColor.r - color.r) * 2) / glowDuration;
		gSpeed = ((fadeColor.g - color.g) * 2) / glowDuration;
		bSpeed = ((fadeColor.b - color.b) * 2) / glowDuration;

		r = color.r;
		g = color.g;
		b = color.b;
				
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
		r += direction * deltaTime * rSpeed;
		g += direction * deltaTime * gSpeed;
		b += direction * deltaTime * bSpeed;

		if(timeElapsed < treshold) {
			obj.material.color = new Color(r,g,b);
		} else if(direction > 0) {
			direction = -1;
		} else {
			resetAnimation();
			
		}
	}

	private void resetAnimation() {
		animating = false;
		timeElapsed = 0;
		obj.material.color = color;
		r = color.r;
		g = color.g;
		b = color.b;
	}

	public void InitGlow() {
		if(animating) {
			if(direction < 0) {
				timeElapsed = glowDuration - timeElapsed;
			}
		} else {
			r = color.r;
			g = color.g;
			b = color.b;
		}

		direction = 1;
		animating = true;
	}
}
