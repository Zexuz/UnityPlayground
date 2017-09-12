using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HudBehavior : MonoBehaviour
{
    private string data = @"00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca
00:fa:45:ca:00:fa:45:ca";

    // Use this for initialization
    void Start()
    {
        var textComponent = GetComponent<TextMesh>();
        textComponent.text = data;
    }

    // Update is called once per frame
    private float time;
    void Update()
    {
        time += Time.deltaTime;
        if (time < 0.2f) return;
        
        time = 0.0f;
        
        
        var rows = data.Split('\n');
        for (int i = 0; i < rows.Length; i++)
        {
            var randomNr = new System.Random().Next(0, 16);
            randomNr += randomNr / 2;

            var row = rows[i];

            var first = row.Substring(0, randomNr);
            var last = row.Substring(randomNr+1);
            rows[i] = first + RandomString(1) + last;
        }
        data = string.Join("\n", rows);
        var textComponent = GetComponent<TextMesh>();
        textComponent.text = data;
    }
    
    private static System.Random random = new System.Random();
    private static string RandomString(int length)
    {
        const string chars = "abcdef0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
}