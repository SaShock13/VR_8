using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Vector3 startRotation;
    [SerializeField] Vector3 endRotation;
    [SerializeField] float speed;
    [Range(0,1),SerializeField] float tDelta=0;
    Transform doorTransform;
    Quaternion startQuat;
    Quaternion endQuat;

    private void Awake()
    {        
        doorTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        startQuat = Quaternion.Euler(startRotation);
        endQuat = Quaternion.Euler(endRotation);
        doorTransform.rotation = Quaternion.Lerp(startQuat, endQuat, tDelta*speed);
        tDelta += Time.deltaTime;
        if (tDelta > 1) { tDelta = 0; }
        
    }
}
