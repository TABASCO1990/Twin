using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private int _columnsCount;
    [SerializeField] private int _rowsCount;
    [SerializeField] private string _numbersTilesGreen;
    [SerializeField] private ParticleSystem _explosionTile;

    private Vector3 _startPosition = new Vector3(-6f, 0f, 3.75f);
    private List<Tile> _tiles = new List<Tile>();
    private List<int> _numbers;

    private void Awake()
    {
        SetTiles();
        _numbers = _numbersTilesGreen.Split(',').Select(x => Convert.ToInt32(x)).ToList();
    }

    public void RemoveTile()
    {
        if (TryGetTile(_numbers))
        {
            _explosionTile.transform.position = new Vector3(_tiles[_numbers.First()].transform.position.x, 1, _tiles[_numbers.First()].transform.position.z);
            _explosionTile.Play();
            _tiles[_numbers.First()].gameObject.SetActive(false);
            _numbers.RemoveAt(0);
        }
    }

    public void ResetTile()
    {
        foreach (var tile in _tiles)
        {
            tile.gameObject.SetActive(true);
        }
        
        _numbers = _numbersTilesGreen.Split(',').Select(x => Convert.ToInt32(x)).ToList();
    }

    private void SetTiles()
    {
        Vector3 nextPosition = _startPosition;

        for (int i = 0; i < _columnsCount; i++)
        {
            for (int j = 0; j < _rowsCount; j++)
            {
                nextPosition = CalculateNextPosition(i, j);

                Tile tile = Instantiate(_tilePrefab, nextPosition, Quaternion.identity, transform);
                _tiles.Add(tile);
            }
        }
    }

    private Vector3 CalculateNextPosition(int column, int row)
    {
        float tileWidth = _tilePrefab.GetComponent<Renderer>().bounds.size.x;
        float tileDepth = _tilePrefab.GetComponent<Renderer>().bounds.size.z;

        float offsetX = tileWidth * column;
        float offsetZ = tileDepth * row * -1;

        return new Vector3(_startPosition.x + offsetX, 0, _startPosition.z + offsetZ);
    }

    private bool TryGetTile(List<int> result)
    {
        return result != null && result.Any();
    }
}