using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Circels : MonoBehaviour
{
    public event Action CircleListIsEmpty;
    public event Action OnCircleDestroy;

    [SerializeField] private float _countOfCircle;
    [SerializeField] private Circle _circlePrefab;

    private List<Circle> _circles = new List<Circle>();
    private Coroutine _updateListStatusCoroutine;

    public void StartUpdateListStatus()
    {
        _updateListStatusCoroutine = StartCoroutine(ListIsEmpty());
    }
    
    public void StopUpdateListStatus()
    {
        StopCoroutine(_updateListStatusCoroutine);
    }
    
    public void SpawnCircles()
    {
        for (int i = 0; i < _countOfCircle; i++)
        {
            //TODO change Random.Range -> CameraBorder ( top and bottom )

            Vector2 squarePosition = GenerateRandomPlace();
            Circle newCircle = Instantiate(_circlePrefab, squarePosition, Quaternion.identity);

            newCircle.OnDestroy += ChangeCountValue;
            _circles.Add(newCircle);
        }
    }

    private Vector2 GenerateRandomPlace()
    {
        //TODO change random pos ( uninclude square pos ) 
        Vector2 squarePosition = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
        
        return squarePosition;
    }

    private void ChangeCountValue()
    {
        OnCircleDestroy?.Invoke();
    }

    private IEnumerator ListIsEmpty()
    {
        while (true)
        {
            yield return null;
            
            _circles.RemoveAll(x => x == null);

            if(_circles.Count == 0)
                CircleListIsEmpty?.Invoke();
        }
    }
}
