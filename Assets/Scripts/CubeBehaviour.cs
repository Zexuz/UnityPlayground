using System;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {

    public float ChangeFactor = 1.0f;
    public float ShrinkFactor = 0.1f;
    public float GrowthFactor = 0.1f;
    public float MaxSize = 5.0f;

    public string data;

    private float size = 1.0f;
    private float targetSize = 1.0f;

    private void Start()
    {
        size = transform.localScale.x;
    }
  
    // Update is called once per frame
    void Update()
    {
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