using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Create/Attack")]
public class ParticleScriptableObject : ScriptableObject
{

     public int NumberOfColumns;
     public float Speed, Lifetime, Firerate, Size, SpinSpeed, Duration, StartDelay;
    
     public Sprite Sprite;
     public Color Color;
     public Material Material;
}


