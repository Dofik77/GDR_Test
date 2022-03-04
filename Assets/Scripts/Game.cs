using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Square square;
    [SerializeField] private Circels _circles;
    [SerializeField] private CircleCoutner _circleCoutner;
    [SerializeField] private Button _restartButton;

    private Square _actualSquare;
    
    private void Start()
    {
        _actualSquare = Instantiate(square, Vector2.zero, Quaternion.identity);
        _actualSquare.StartAiming();
        
        _circles.SpawnCircles();
        _circles.StartUpdateListStatus();
        
        _circles.CircleListIsEmpty += OnCircleCollected;
        _circles.OnCircleDestroy += ChangeCountValue;
    }

    private void ChangeCountValue()
    {
        _circleCoutner.ChangeValue();
    }

    private void OnCircleCollected()
    {
        _circles.CircleListIsEmpty -= Restart;
        _circles.OnCircleDestroy -= ChangeCountValue;
        
        _actualSquare.StopAiming();
        _circles.StopUpdateListStatus();
        
        _restartButton.gameObject.SetActive(true);
    }
    
    public void Restart()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
}
