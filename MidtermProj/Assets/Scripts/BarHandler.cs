using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHandler : MonoBehaviour
{
    public float maxValue;
    public float[] values = new float[4];
    public RectTransform[] valueBars;
    public float bgLength;
    private float lengthPerVal;

    void Start()
    {
        lengthPerVal = bgLength/maxValue;
        values[0] = 40f;
        values[1] = 0f;
        values[2] = 30f;
        values[3] = 0f;
    }

    void Update()
    {
        valueBars[0].sizeDelta = new Vector2((values[0])*lengthPerVal, valueBars[0].sizeDelta.y);
        valueBars[1].sizeDelta = new Vector2((values[0] + values[1])*lengthPerVal, valueBars[1].sizeDelta.y);
        valueBars[2].sizeDelta = new Vector2((values[0] + values[1] + values[2])*lengthPerVal, valueBars[2].sizeDelta.y);
        valueBars[3].sizeDelta = new Vector2((values[0] + values[1] + values[2] + values[3])*lengthPerVal, valueBars[3].sizeDelta.y);
    }
}
