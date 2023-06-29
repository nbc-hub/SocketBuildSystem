using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollider : MonoBehaviour
{
    bool isDetect = false;

    public bool GetIsDetect()
    {
        return isDetect;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Object"){
            isDetect=true;
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag=="Object"){
            isDetect=true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag=="Object"){
            isDetect=false;
        }
    }
}


/*
    Collider[] colliders = Physics.OverlapSphere(transform.position, 0.49f);
        foreach (var item in colliders)
        {
            if (item.CompareTag("Object"))
            {
                isDetect = true;
            }
            else
            {
                isDetect = false;
            }
        }
*/