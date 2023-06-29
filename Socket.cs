using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public int socketID = 0;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.05f);
        foreach (var item in colliders)
        {
            if (item.CompareTag("Object"))
            {
                if (item.GetComponent<StructureModel>().GetStructureID() == socketID)
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    public void CheckOtherSockets()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.05f);
        foreach (var item in colliders)
        {
            if (item.GetComponent<Socket>() && item.gameObject != gameObject)
            {
                if (item.GetComponent<Socket>().socketID == socketID)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

/*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.05f);
    }*/
}
