using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Create/Attack")]
public class ParticleScriptableObject : ScriptableObject
{

     public int NumberOfColumns;
     public float Speed = 5f, Lifetime = 5f, FireRate = 0.1f, Size = 0.7f, SpinSpeed = 30f, Duration = 5f, StartDelay = 0f, PercentCompleteUntilNext = 1.0f;
    
     public Sprite Sprite;
     public Color Color;
     public Material Material;
}


