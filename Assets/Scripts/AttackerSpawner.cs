using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minDelaySpawn = 1f;
    [SerializeField] float maxDelaySpawn = 5f;
    [SerializeField] Attacker[] attackerPrefabArray = { };

    private static List<AttackerSpawner> _attackerSpawnerList = new List<AttackerSpawner>();
    public static List<AttackerSpawner> AttackerSpawners { get { return _attackerSpawnerList; } }

    bool spawn = true;

    private void Awake()
    {
        if (_attackerSpawnerList != null)
        {
            _attackerSpawnerList.Add(this);
        }
        else
        {
            _attackerSpawnerList = new List<AttackerSpawner>();
            _attackerSpawnerList.Add(this);
        }
    }

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minDelaySpawn, maxDelaySpawn));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        if (attackerPrefabArray.Length == 0)
        {
            Debug.LogWarning("Attacker Prefab array is empty, will not have attacker to spawn!");
            return;
        }

        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }

    private void OnDestroy()
    {
        _attackerSpawnerList = null;
    }

}
