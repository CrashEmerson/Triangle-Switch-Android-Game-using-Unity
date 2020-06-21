using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Level")]
public class LevelScript : ScriptableObject
{
    [SerializeField] string stageName;

    [SerializeField] int triangleRotateSpeed;
    [SerializeField] public int no_of_lantern;

    [Header("Ball Script")]
    [SerializeField] ParticleSystem AcquireSparkVFX;

    [Header("LaternScript")]
    [SerializeField] GameObject lanternBurst;

    [Header("PowerStars")]
    [SerializeField] GameObject AcquireStarVFX;

    [SerializeField] GameObject FireBall;
    [SerializeField] float FireBallSpawnSeconds;

    [SerializeField] int levelFinishTime;

    public string GetStageName() { return stageName; }    // stage name

    public int GetTriangleRotateSpeed()  { return triangleRotateSpeed;  }
    public int GetlanternCount() {  return no_of_lantern; }

    public ParticleSystem GetAcquireSparkVFX() { return AcquireSparkVFX; }
    public GameObject GetLaternBurst() { return lanternBurst; }

    public GameObject GetAcquireStarVFX() { return AcquireStarVFX; }

    public GameObject GetFireBallPrefab() { return FireBall; }
    public float GetFireBallSpawnSeconds() { return FireBallSpawnSeconds; }

    public int GetLevelFinishTime() { return levelFinishTime; }
}