using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float matchCamXMovement = 0f; // range [0..1]. 1 matches camera move
    [SerializeField] private float matchCamYMovement = 0f; // range [0..1]. 1 matches camera move
    [SerializeField] private Vector2 offset; // allows us to offset our position relative to the camera

    void LateUpdate() 
    {
        transform.position = new Vector2(cam.position.x * matchCamXMovement, cam.position.y * matchCamYMovement) + offset;
    }
}
