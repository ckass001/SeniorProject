using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTf;
    private void Update()
    {
        transform.position = new Vector3(playerTf.position.x, playerTf.position.y, transform.position.z);
    }
}
