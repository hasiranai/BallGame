using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelPoint : MonoBehaviour
{
    [SerializeField]
    private float upPower;

    [SerializeField]
    private float accelPower;

    [SerializeField]
    private bool isZAccel;

    private void OnTriggerEnter(Collider other)
    {  
        if (isZAccel == true)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upPower, accelPower), ForceMode.VelocityChange);
        }
        else
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(accelPower, upPower, 0), ForceMode.VelocityChange);
        }
    }
}
