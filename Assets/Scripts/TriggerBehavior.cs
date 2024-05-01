using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    public UnityEvent enter;
    public UnityEvent exit;

    public bool isHitBox = false;
    public Vector3 direction;
    public bool characterLeft;

    private void OnTriggerEnter(Collider other)
    {
        enter.Invoke();

        if (isHitBox == true)
        {
            if (characterLeft == true)
            {
                direction.x = direction.x * -1;
                direction.x = direction.y * -1;
                var rb = other.GetComponentInParent<Rigidbody>();
                rb.AddForceAtPosition(direction, this.transform.position, ForceMode.Force);
            }
            else
            {
                direction.x = direction.x * 1;
                direction.x = direction.y * 1;
                var rb = other.GetComponentInParent<Rigidbody>();
                rb.AddForceAtPosition(direction, this.transform.position, ForceMode.Force);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        exit.Invoke();
    }
}
