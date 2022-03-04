using UnityEngine;
using UnityEngine.UI;

public class CircleCoutner : MonoBehaviour
{
    [SerializeField] private Text _circleCounter;

    private int _counter;
    public void ChangeValue()
    {
        _counter++;
        _circleCounter.text = _counter.ToString();
    }
    
}
