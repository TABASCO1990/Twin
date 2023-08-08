using UnityEngine;

public class Locations : MonoBehaviour
{
    [SerializeField] private Stage[] _stages;

    public int _numberLevel;

    public Stage GetStage()
    {
        _stages[_numberLevel].gameObject.SetActive(true);
        Stage level = _stages[_numberLevel];
        return level;
    }  
    
    public void SetNumberStage(int number)
    {
        _numberLevel = number;
    }

    public void ResetStages()
    {
        foreach (var stage in _stages)
        {
            stage.gameObject.SetActive(false);
        }
    }
}
