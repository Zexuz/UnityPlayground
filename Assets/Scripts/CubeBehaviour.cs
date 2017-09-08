using System;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {

    public float ChangeFactor = 1.0f;
    public float ShrinkFactor = 0.1f;
    public float GrowthFactor = 0.1f;
    public float MaxSize = 5.0f;

    public float fadeSpeed = 0.3f;

    public string data;

    private float size = 1.0f;
    private float targetSize = 1.0f;

    private float a = 1;

    private Color color;

    void Start() {
        color = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

        float a = GetComponent<Renderer>().material.color.a - Time.deltaTime * fadeSpeed;
        
        if(a > 0.5) {
            GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, a);
        } else {
            GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0.5f);
        }
        
        targetSize -= Time.deltaTime * ShrinkFactor;

        if (Math.Abs(size - targetSize) > 0.0001)
        {
            float magnitude = targetSize - size;
            size += ChangeFactor * magnitude * Time.deltaTime;

            transform.localScale = new Vector3(size, size, size);
            if (size < 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Feed(string data)
    {
        targetSize += GrowthFactor;
        targetSize = System.Math.Min(targetSize, MaxSize);
    }
}