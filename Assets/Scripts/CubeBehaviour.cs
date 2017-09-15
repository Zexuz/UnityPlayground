using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class CubeBehaviour : MonoBehaviour {
    
    [HideInInspector]
    public Camera Camera;

    public float ChangeFactor = 1.0f;
    public float ShrinkFactor = 0.1f;
    public float GrowthFactor = 0.1f;
    public float MaxSize = 5.0f;

    [HideInInspector]
    public string Data;

    private List<DateTime> _messageTimes;
    public double MessageAvgDeltaTime
    {
        get
        {
            var deltaTimeList = new List<TimeSpan>();
            for (var index = 1; index < _messageTimes.Count; index++)
            {
                var messageTime = _messageTimes[index];
                deltaTimeList.Add(_messageTimes[index - 1] - messageTime);
            }
            var totalSum = deltaTimeList.Sum(time => time.TotalSeconds);
            
            var returnData = totalSum / deltaTimeList.Count;
            return returnData;
        }
    }

    private float size = 1.0f;
    private float targetSize = 1.0f;

    private void Start()
    {
        _messageTimes = new List<DateTime>();
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
        var maxMessages = 10;
        if(_messageTimes == null)
            _messageTimes =  new List<DateTime>();
        
        if (_messageTimes.Count >= maxMessages)
            _messageTimes.RemoveRange(0, _messageTimes.Count - (maxMessages - 1));

        _messageTimes.Add(DateTime.Now);
        
        Data = data;
        targetSize += GrowthFactor;
        targetSize = System.Math.Min(targetSize, MaxSize);        
    }
}