using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    [SerializeField]
    private GameObject _rainingDessertsPrefab;

    [Range(0f, 0.1f)]
    [SerializeField]
    private float _spawnRate = 0.005f;

    void Update()
    {
        if (Random.value <= _spawnRate)
            CreateRainingDessertsPrefab();
    }

    private void CreateRainingDessertsPrefab()
    {
        GameObject dessertsClone = Instantiate(_rainingDessertsPrefab, transform);
        Vector2 randomVector = MyToolbox.GetRandomVector2(-1200, 1200, 1000, 1000);
        dessertsClone.transform.localPosition = randomVector;
    }
}
