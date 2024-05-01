using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;
    public float valueTwo;

    public void ChaseIncrease(float num)
    {
        value += num;
    }

    public void ChasingIncrease(float num)
    {
        valueTwo += num;
    }
}
