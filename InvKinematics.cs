using UnityEngine;
using System;


public class InvKinematics : MonoBehaviour
{
    public double about_x; // x to rotate about
    public double about_y; // y to rotate about
    private double x_init; // initial x
    private double y_init; // initial y
    private double x_prime; // final x
    private double y_prime; // final y
    public double seconds = 3.0; // Time to go from start position to final

    public GameObject start;
    public GameObject end;

    private double theta;
    private double deltaTheta = 0;

    private int sign;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set initial position

        
        //intital position set
        x_init = start.transform.position.x;
        y_init = start.transform.position.y;
        //final position set
        x_prime = end.transform.position.x;
        y_prime = end.transform.position.y;

        transform.position = new Vector3((float)x_init, (float)y_init, 0);

        // Shorthand to clean up the theta calc a bit
        double ax = x_init - about_x;
        double ay = y_init - about_y;
        double bx = x_prime - about_x;
        double by = y_prime - about_y;

        // Determine direction of rotation
        sign = Math.Sign((ax * by) - (ay * bx));

        // The two GameObjects below are simply a visual aid
        // move the "start" GameObject to mark the starting position
        

        // move the "end" GameObject to mark the ending position
        

        // Find necessary rotation angle
        theta = (((ax * bx) + (ay * by)) / (Math.Sqrt((ax * ax) + (ay * ay)) * Math.Sqrt((bx * bx) + (by * by))));
        theta = Math.Acos(theta); // returned in radians
        theta = theta * (180 / Math.PI);
        //Debug.Log("Theta: " + theta);
    }

    // Update is called once per frame
    void Update()
    {
        // Apply rotation over a set number of seconds rather than in a single frame
        double angle = theta * (Time.deltaTime / seconds);
        if (Math.Abs(deltaTheta) + Math.Abs(angle) > Math.Abs(theta))
        {
            angle = theta - deltaTheta;
        }

        // Stop once final position has been reached.
        if (Math.Abs(deltaTheta) < Math.Abs(theta))
        {
            // Apply transforms for this frame
            Matrix4x4 originTransform = Matrix4x4.Translate(new Vector3((float)about_x, (float)about_y, 0));
            Matrix4x4 invOriginTransform = Matrix4x4.Translate(new Vector3((float)-about_x, (float)-about_y, 0));

            Matrix4x4 translation = Matrix4x4.Translate(new Vector3(transform.position.x, transform.position.y, 0));
            Matrix4x4 rotation = Matrix4x4.Rotate(Quaternion.Euler(0, 0, (float)(angle * sign)));

            transform.position = originTransform * rotation * invOriginTransform * translation * new Vector4(0, 0, 0, 1);
            deltaTheta += angle;
        }

    }
}
