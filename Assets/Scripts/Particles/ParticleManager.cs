using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<ParticleScriptableObject> particleList = new List<ParticleScriptableObject>();
    private int index;

    private void Start()
    {
        Invoke("StartAttacks", 3f);
    }

    private void StartAttacks()
    {
        SpawnParticleSpawner();
    }


    private void SpawnParticleSpawner()
    {
        if(index >= particleList.Count)
        {
            index = 0;
        }

        GameObject _spawnedSpanwer = new GameObject("ParticleSpawner");

        _spawnedSpanwer.AddComponent<ParticleSpawner>().Info = particleList[index];
        _spawnedSpanwer.GetComponent<ParticleSpawner>().Manager = this;
        _spawnedSpanwer.transform.SetParent(transform);
        _spawnedSpanwer.transform.position = transform.position;

        index ++;
    }

    public void ParticleEnded()
    {
        SpawnParticleSpawner();
    }
}
