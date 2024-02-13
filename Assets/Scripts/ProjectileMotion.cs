using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    [SerializeField] private GameObject projectile1;
    [SerializeField] private Vector3 initialVelocity;
    [SerializeField] private Vector3 finalVelocity;
    [SerializeField] private Vector3 angleOfProjection;
    [SerializeField] private Vector3 relativeVelocity;
    [SerializeField][Range(-30.0f, 0.0f)] private float gravitational_Acceleration;
    private bool reset = true;
    private bool inMotion = false;

    Vector3 gravity;
    float time;
    Vector3 initialPosition;
    Vector3 displacement;
    public bool airResistanceOn;
    private sphereProjectile projectileBody;
    private float timeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        if (angleOfProjection != Vector3.zero)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && reset == true)
        {
            inMotion = true;
            reset = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && reset == false)
        {
            projectile1.transform.position = initialPosition;
            displacement = new Vector3(0.0f, 0.0f, 0.0f);
            timeElapsed = 0.0f;
            reset = true;
            inMotion = false;
        }

        if (inMotion == true)
        {
            FireProjectile();
        }

    }

    private void ResetProjectile()
    {
        timeElapsed = 0.0f;
    }

    private void FireProjectile()
    {
        displacement.y = initialVelocity.y * timeElapsed + 0.5f * gravitational_Acceleration * timeElapsed * timeElapsed;
        displacement.x = initialVelocity.x * timeElapsed;
        displacement.z = initialVelocity.z * timeElapsed;

        projectile1.transform.position = initialPosition + displacement;
        Debug.Log(displacement);
        timeElapsed += Time.deltaTime;
    }
}
