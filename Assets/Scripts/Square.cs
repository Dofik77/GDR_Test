using System;
using System.Collections;
using UnityEngine;

public class Square : MonoBehaviour
{
     [SerializeField] private float _cameraOffset;
     
     private Coroutine _aimCoroutine;
     private Camera _camera;

     private void Awake()
     {
          _camera = Camera.main;
     }

     public void StartAiming()
     {
          _aimCoroutine = StartCoroutine(AimingCoroutine());
     }
        
     public void StopAiming()
     {
          StopCoroutine(_aimCoroutine);
     }
     
     private IEnumerator AimingCoroutine()
     {
          while (true)
          {
               yield return null;
               
               MoveByMouse();
               MouseIsDown();
          }
     }
     
     private void MoveByMouse()
     {
          if (RayCastHasHitCollider() && MouseIsDown())
          {
               Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,_cameraOffset);
               transform.position = _camera.ScreenToWorldPoint(position);
          }
     }
 
     private bool RayCastHasHitCollider()
     {
          var raycastHit = Vector2.zero;
          var ray = _camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
          var hasHit = Physics2D.Raycast(ray, raycastHit);

          return hasHit.collider != null;
     }

     private bool MouseIsDown()
     {
          return Input.GetMouseButton(0);
     }

}
