using Entities;
using UI;
using UnityEngine;
using Screen = UI.Screen;

namespace Scenes
{
    public class TargetController : MonoBehaviour
    {
        public GameObject target;
        private Camera mainCamera;
        private TargetInfo targetInfo;

        void Start()
        {
            mainCamera = Camera.main;
            targetInfo = Screen.Instance.TargetInfo.GetComponent<TargetInfo>();
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

            if (target is not null)
            {
                targetInfo.targetEntity = target.GetComponent<EntityWrapper>().Entity;
                Screen.Instance.TargetInfo.SetActive(true);
            }
            else
            {
                targetInfo.targetEntity = null;
                Screen.Instance.TargetInfo.SetActive(false);
            }
        }
    }
}