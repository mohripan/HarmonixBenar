using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainPositionParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;
    ParticleSystem.ShapeModule editableShape;

    [SerializeField] private Transform playerPosition;
    [SerializeField] private float plusPosition;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        editableShape = particleSystem.shape;
    }

    private void Update()
    {
        editableShape.position = new Vector3(playerPosition.position.x+plusPosition, 0,0);
    }
}
