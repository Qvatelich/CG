using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SkySpawner : MonoBehaviour
{
    [SerializeField] private List<Sprite> _skyVariants;
    [SerializeField] private GameObject _skyPrefab;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            float y = Random.Range(-4f,4f);
            int i = Random.Range(0,_skyVariants.Count);
            GameObject newSky = Instantiate(_skyPrefab , new Vector2(transform.position.x,y),Quaternion.identity);
            newSky.GetComponent<SpriteRenderer>().sprite = _skyVariants[i];
        }
    }
}
