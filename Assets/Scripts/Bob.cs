using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    void Update()
    {
        transform.localPosition = Vector3.up * Mathf.Sin(Time.time) * 0.1f;
        transform.localEulerAngles = new Vector3(0, Time.time * 180, -45);
    }
}
