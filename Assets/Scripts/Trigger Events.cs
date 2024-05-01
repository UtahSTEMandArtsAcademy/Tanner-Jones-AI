using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerEvents : MonoBehaviour
{
    public UnityEvent enter;

    private void OnTriggerEnter(Collider other)
    {
        enter.Invoke();
    }
}
