using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    private ParticleSystem system;


    public ParticleScriptableObject Info;
    public ParticleManager Manager;
    private float angle, time;

    private void Start()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time * Info.SpinSpeed);
    }


    private void Summon()
    {
        angle = 360f / Info.NumberOfColumns;

        for (int i = 0; i < Info.NumberOfColumns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = Info.Material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.SetParent(transform);
            go.transform.position = transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = Info.Speed;
            mainModule.maxParticles = 100000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var _emission = system.emission;
            _emission.enabled = false;

            var _shape = system.shape;
            _shape.enabled = true;
            _shape.shapeType = ParticleSystemShapeType.Sprite;
            _shape.sprite = null;

            var _texture = system.textureSheetAnimation;
            _texture.enabled = true;
            _texture.mode = ParticleSystemAnimationMode.Sprites;
            _texture.AddSprite(Info.Sprite);
        }

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", Info.StartDelay, Info.Firerate);
        Invoke("StopSpawningParticles", Info.Duration);
    }

    void DoEmit()
    {
        foreach (Transform _child in transform)
        {
            system = _child.GetComponent<ParticleSystem>();

            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = Info.Color;
            emitParams.startSize = Info.Size;
            emitParams.startLifetime = Info.Lifetime;
            system.Emit(emitParams, 10);
            system.Play(); // Continue normal emissions
        }
    }


    private void StopSpawningParticles()
    {
        CancelInvoke("DoEmit");
        Manager.ParticleEnded();
        Destroy(gameObject, 5f);
    }
}
