using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteObject : MonoBehaviour
{
    public GameObject yes;
    void OnTriggerEnter(Collider collider)
    {
        BoatControls.instance.NextRoute();
        Game.Score += 10;
        yes.SetActive(true);
        gameObject.SetActive(false);
    }
}