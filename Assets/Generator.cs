using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator:MonoBehaviour
{
	public Modifier Modifier;

	
	public void GenerateHex()
	{
		SendHex("00:00:00:00:00:00:00:00");
	}
	public void SendHex(string hex)
	{
		Modifier.PrintMessage(hex);
	}

	
}
