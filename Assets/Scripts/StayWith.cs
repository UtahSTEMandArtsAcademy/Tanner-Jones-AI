using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWith : MonoBehaviour
{
    public GameObject followTarget;
    public float speed = 10f;

    
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, followTarget.transform.position, speed);
    }
}
