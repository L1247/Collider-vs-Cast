#region

using rStarUtility.Util.Extensions.Csharp;
using rStarUtility.Util.Extensions.Unity;
using UnityEditor;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class Projectile : MonoBehaviour
    {
    #region Private Variables

        private Rigidbody2D rigidbody2D;

        private Vector2 lastPosition;

        private Vector2 range;

        // 100 會先移動下一幀才偵測
        // 180 穿過敵人，不觸發傷害
        [SerializeField]
        private float moveSpeed = 3f;

    #endregion

    #region Unity events

        private void Awake()
        {
            rigidbody2D  = GetComponent<Rigidbody2D>();
            lastPosition = transform.position;
        }

        private void Update()
        {
            // move by transform
            transform.position += Vector3.right * (Time.deltaTime * moveSpeed);
            // move by physics 
            // 間接 move by transform 
            // rigidbody2D.position += Vector2.right * (Time.deltaTime * moveSpeed);

            range   = Vector2.one;
            range.x = transform.position.x - lastPosition.x;
            Vector2 castPos = transform.position;
            castPos.x = lastPosition.x + range.x / 2; // center point
            // Debug.Log($"{castPos} , {range} , {transform.position} , {lastPosition}");
            DamageHelper.DealDamage(castPos , range);
            lastPosition = transform.position;
        }

    #endregion

    #region Private Methods

        private void OnDrawGizmos()
        {
            // rect position start from bottom left side
            var rect = new Rect(transform.position.ToVector2() - range.SetY(range.y / 2) , range);
            Handles.DrawSolidRectangleWithOutline(rect , Color.red.WithA(0.1f) , Color.black);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Damageable>(out var damageable).IsFalse()) return;
            damageable.TakeDamage();
        }

    #endregion
    }
}