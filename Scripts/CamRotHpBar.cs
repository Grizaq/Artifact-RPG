using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotHpBar : MonoBehaviour
{

    void Update()
    {
        Camera camera = Camera.main;

        transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);
    }
}
