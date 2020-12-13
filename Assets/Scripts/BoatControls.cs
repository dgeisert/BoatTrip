﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControls : MonoBehaviour
{
    public static BoatControls instance;

    public float maxSpeed = 5;
    public float acceleration = 1;
    public float turnSpeed = 1;
    public float maxTurn = 1;
    public float turnDecay = 0.01f;
    public float speedDecay = 0.01f;

    public ParticleSystem leftWake, rightWake;
    ParticleSystem.EmissionModule leftWakeE, rightWakeE;

    public List<Vector3> route = new List<Vector3>();
    public GameObject routeObject;

    float turn = 0;
    float speed = 0;
    int routeNum = 0;

    void Start()
    {
        instance = this;
        leftWakeE = leftWake.emission;
        rightWakeE = rightWake.emission;
        NextRoute();
        NextRoute();
        NextRoute();
    }

    void Update()
    {
        if (Controls.Forward)
        {
            speed += acceleration * Time.deltaTime;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (Controls.Back)
        {
            speed -= acceleration * Time.deltaTime;
            if (speed < 0)
            {
                speed = 0;
            }
        }
        if (Controls.Left)
        {
            turn -= Time.deltaTime * turnSpeed * (speed / 2 + 5f);
        }
        else if (Controls.Right)
        {
            turn += Time.deltaTime * turnSpeed * (speed / 2 + 5f);
        }
        leftWakeE.rateOverDistance = 50 / maxSpeed * speed;
        rightWakeE.rateOverDistance = 50 / maxSpeed * speed;
        turn /= 1 + turnDecay;
        speed /= 1 + speedDecay;
        turn = Mathf.Clamp(turn, -maxTurn, maxTurn);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + turn, 0);
        transform.position += new Vector3(transform.forward.x, 0, transform.forward.z) * Time.deltaTime * speed;
    }

    public void NextRoute()
    {

        if (routeNum < route.Count)
        {
            GameObject.Instantiate(routeObject, route[routeNum], Quaternion.identity);
        }
        routeNum++;
        if(routeNum > route.Count + 2)
        {
            Game.Instance.Victory();
        }
    }

}