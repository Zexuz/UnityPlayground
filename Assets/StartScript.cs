using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class StartScript : MonoBehaviour
{
    public Generator _generator;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            _generator.CreateSender(RandomString(1), Random.value);
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