using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    protected List<GameObject> _pool = new List<GameObject>();

    public void ResetPool()
    {
        _pool[0].SetActive(true);

        for (int i = 1; i < _pool.Count; i++)
        {
            _pool[i].SetActive(false);
        }
    }

    protected void Initialize(GameObject prefab)
    {
        GameObject spawn = Instantiate(prefab, _container.transform);
        spawn.SetActive(false);
        _pool.Add(spawn);
    }

    protected bool TryGetNextObject(out GameObject result)
    {  
        result = _pool.SkipWhile(x => x.activeSelf == false).Skip(1).FirstOrDefault();

        return result != null;
    }
}
