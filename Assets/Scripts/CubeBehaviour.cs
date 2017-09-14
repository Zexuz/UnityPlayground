using System;
using UnityEngine;
using UnityEngine.UI;

public class CubeBehaviour : MonoBehaviour {


    public Camera Camera;
    public Text Text;

    private Glow glow;


    public float ChangeFactor = 1.0f;
    public float ShrinkFactor = 0.1f;
    public float GrowthFactor = 0.1f;
    public float MaxSize = 5.0f;

    public float fadeSpeed = 0.3f;

    public string data;

    private float size = 1.0f;
    private float targetSize = 1.0f;


    void Start() {
        glow = new Glow(gameObject.GetComponent<Renderer>());
        size = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        glow.Update(Time.deltaTime);
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


        const float MIN_DISTANCE = 0.7f;
        const float MAX_DISTANCE = 0.75f;

        float distance = Vector3.Distance(Camera.gameObject.transform.position, transform.position);             
        float alpha = Mathf.Clamp((distance - MIN_DISTANCE) / (MAX_DISTANCE - MIN_DISTANCE), 0.0f, 1.0f);

        Color c = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        c.a = alpha;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", c);                

    }

    public void Feed(string data)
    {
        targetSize += GrowthFactor;
        targetSize = System.Math.Min(targetSize, MaxSize);
        if(glow != null) {
            glow.InitGlow();
        }
        
    }
}