using UnityEngine;

namespace Scenes
{
    public class TargetController : MonoBehaviour
    {
        public GameObject target;
        private Camera mainCamera;

        void Start()
        {
            mainCamera = Camera.main;
        }
        void FixedUpdate()
        {
            var mouseWorldPos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            target = null;
            if (hit.collider is not null && (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Player")))
            {
                target = hit.collider.gameObject;
            }
        }
    }
}