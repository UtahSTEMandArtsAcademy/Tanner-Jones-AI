using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Stats : ScriptableObject
{
    public float Food;
    public float Water;
    public bool Dying;
    public void Day(float fTime, float wTime)
    {
        Food += Time.deltaTime;
        Water += Time.deltaTime;

        if(Food > fTime)
        {
            Dying = true;
        }

        if (Water > wTime)
        {
            Dying = true;
        }
    }
}
