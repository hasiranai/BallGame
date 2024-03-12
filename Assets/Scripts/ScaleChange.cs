using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    public Vector3 scale;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.localScale = scale;
    }
}
