using UnityEngine;

public class SeedGenerator : MonoBehaviour
{
    [SerializeField] private int _seed;
#if UNITY_EDITOR
    [SerializeField] private bool _generateSeed;
#endif
    [SerializeField] private bool _randomSeedOnStart = true;

    public int Seed => _seed;

    protected void Awake()
    {
        if (_randomSeedOnStart)
        {
            GenerateSeed();
        }    
        Random.InitState(_seed);
    }

    public void GenerateSeed()
    {
        _seed = Random.Range(100000, 999999);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_generateSeed)
        {
            _generateSeed = false;
            GenerateSeed();
        }
    }
#endif
}
