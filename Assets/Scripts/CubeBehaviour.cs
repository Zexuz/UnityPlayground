using System;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {

    public float ShrinkFactor = 0.1f;
    public float GrowthRoof = 1000.0f;
    public float GrowthFactor = 1.0f;
    public float MaxSize = 5.0f;

    private float size = 1.0f;
    private float targetSize = 1.0f;
    private float messages = 1.0f;

  
    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(size - targetSize) > 0.1)
        {
            float magnitude = targetSize - size;
            size = size + magnitude * 0.1f;
        }
        else
        {
            size -= Time.deltaTime * ShrinkFactor;
            targetSize = size;
            transform.localScale = new Vector3(size, size, size);

            if (size < 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void Feed(string data)
    {
        messages += 1;
        float growth = System.Math.Min((float) messages * GrowthFactor, GrowthRoof);
        targetSize = (MaxSize - 1.0f) * (growth / GrowthRoof) + 1.0f;
    }
}