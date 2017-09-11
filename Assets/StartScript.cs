using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartScript : MonoBehaviour
{
	public Generator Generator;
	public GameObject GameObjectHolder;
	
	//make a reset button for hololens
	
	// Use this for initialization
	void Start () {

		GameObjectHolder = new GameObject
		{
			name = "MessageSenderHolder"
		};

		Debug.Log("start");
		for (int i = 0; i < 100; i++)
		{
			var messageSender = Generator.createSender();
			MessageSenderBehaviour script = messageSender.GetComponent<MessageSenderBehaviour>();
			script.data = RandomString(1);
			script.interval = Random.value;
			messageSender.transform.parent = GameObjectHolder.transform;
		}
	}
	
	private static System.Random random = new System.Random();
	private static string RandomString(int length)
	{
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
