using System.Linq;
using HoloToolkit.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

public class StartScript : MonoBehaviour
{
    public Generator Generator;
    // Use this for initialization
    void Start()
    {
        var tts = gameObject.GetComponent<TextToSpeechManager>();
        tts.SpeakText("Ognak Gnouk");

        
        for (int i = 0; i < 100; i++)
        {
            Generator.CreateSender(RandomString(1), Random.value);
        }
    }

    private static System.Random random = new System.Random();
    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}