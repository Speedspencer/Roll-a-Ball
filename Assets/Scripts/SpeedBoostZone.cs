using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    public float boostAmount = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 boostDirection = rb.velocity.normalized;
            Vector3 boostVelocity = boostDirection * boostAmount;
            rb.AddForce(boostVelocity, ForceMode.VelocityChange);
        }
    }
}