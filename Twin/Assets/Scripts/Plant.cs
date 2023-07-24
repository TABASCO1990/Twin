using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Plant : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private int _columnsCount;
    [SerializeField] private int _rowsCount;
    [SerializeField] private string _numbersTilesGreen;
    
    private Vector3 _startPosition = new Vector3(-6f, 0f, 3.75f);
    private List<Tile> _tiles = new List<Tile>();
    private List<int> _numbers;

    private void Start()
    {
        SetTiles();
        _numbers = _numbersTilesGreen.Split(',').Select(x => Convert.ToInt32(x)).ToList();
    }

    public void RemoveTile()
    {
        if (TryGetTile(_numbers))
        {
            _tiles[_numbers.First()].gameObject.SetActive(false);
            _numbers.RemoveAt(0);
        }
    }

    private void SetTiles()
    {
        Vector3 nextPosition = _startPosition;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                nextPosition = new Vector3(
                    _startPosition.x + (_tilePrefab.GetComponent<Renderer>().bounds.size.x) * i, 0, _startPosition.z + (_tilePrefab.GetComponent<Renderer>().bounds.size.z) * j * -1);
                Tile tile = Instantiate(_tilePrefab, new Vector3(nextPosition.x, 0, nextPosition.z), Quaternion.identity, transform);
                _tiles.Add(tile);
            }
        }
    }

    private bool TryGetTile(List<int> result)
    {
        return result != null && result.Any();
    }
}
