using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCode : MonoBehaviour
{
    // Start is called before the first frame update
    private float bobIntensity = .25f;
    private float bobFrequency = .25f;
    float rotateSpeed = 50.0f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * bobFrequency) * bobIntensity;

        transform.position = tempPos;

        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
