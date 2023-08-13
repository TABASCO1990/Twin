using UnityEngine;
using UnityEngine.Events;

public class Locations : MonoBehaviour
{
    [SerializeField] private Stage[] _stages;

    public event UnityAction<int> StageInitialised;

    public int _numberLevel;

    private void Start()
    {
        _stages[_numberLevel].gameObject.SetActive(true);
    }

    public Stage GetStage()
    {
        _stages[_numberLevel].gameObject.SetActive(true);
        Stage level = _stages[_numberLevel];
        return level;
    }  
    
    public void SetNumberStage(int number)
    {
        _numberLevel = number;
        StageInitialised(_numberLevel);
    }

    public void ResetStages()
    {
        foreach (var stage in _stages)
        {
            stage.gameObject.SetActive(false);
        }
    }
}
