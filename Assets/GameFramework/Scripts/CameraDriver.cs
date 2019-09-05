using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDriver : MonoBehaviour
{
    /// <summary>
    /// Target is what the camera looks at.
    /// </summary>

    [SerializeField] private Transform observationTarget;
    [SerializeField] private float verticalOffset;
    [SerializeField] private float followOffset;
    [SerializeField] private float followSpeed = 2.0f;
    [SerializeField] private bool lookAtTarget;

    private Vector3 targetPosition;
    private Vector3 targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Look();
    }
    private void Move()
    {
        // Relative to the world
        //targetPosition = new Vector3(observationTarget.transform.position.x, verticalOffset, observationTarget.transform.position.z - followOffset);

        // Relative to the actor / observation Target
        targetPosition = new Vector3(observationTarget.transform.position.x, verticalOffset + observationTarget.transform.position.y, observationTarget.transform.position.z - followOffset);
        targetDirection = targetPosition - transform.position;
        transform.position += targetDirection * Time.deltaTime * followSpeed;
            
    }
    private void Look()
    {
        if (lookAtTarget)
        {
            transform.LookAt(observationTarget);
        }
    }
}
