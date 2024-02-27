using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public GameObject Prefab;
    public GameObject Bullet_prefab;
    public int fireRate;
    public int fireRange;
    public int weaponYear;
    public Mesh weaponMesh;
    public Vector3 spawnPoint;


}
