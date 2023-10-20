using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    public float TimeToDestroy;

    void Start()
    {
        StartCoroutine(DestoryAfterTimeIsGone(TimeToDestroy));
    }

    private IEnumerator DestoryAfterTimeIsGone(float timeToDestroy)
    {
        yield return new WaitForSeconds(timeToDestroy);

        Destroy(gameObject);
    }
}
