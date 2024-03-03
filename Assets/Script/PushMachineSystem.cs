using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushMachineSystem : MonoBehaviour
{
    public static int pushCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            pushCount++;
        }
    }
}
