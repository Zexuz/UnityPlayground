using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSenderBehaviour : MonoBehaviour {
	public Modifier Modifier;

	public string data;
	public float interval = 0.0f;

	private float time = 0.0f;

	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;
		if (interval > 0.0f)
		{
			if (time >= interval)
			{
				Modifier.PrintMessage(data);
				time = 0.0f;
			}
		}
	}
}
