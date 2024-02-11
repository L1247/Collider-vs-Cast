#region

using System.Collections.Generic;
using System.Linq;
using Drawing;
using rStarUtility.Util.Extensions.Csharp;
using rStarUtility.Util.Extensions.Unity;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class CastHelper
    {
    #region Public Methods

        /// <summary>
        ///     return casted enemies
        /// </summary>
        /// <param name="centerPosition"></param>
        /// <param name="castSize"></param>
        /// <returns></returns>
        public static IEnumerable<Damageable> Cast(Vector2 centerPosition , Vector2 castSize)
        {
            // var collider2Ds =
            //         Physics2D.BoxCastAll(centerPosition , colliderSize , 0 , Vector2.zero , 0)
            //                  .Select(hit2D => hit2D.collider.GetComponent<Damageable>())
            //                  .Where(damageable => damageable.IsNotNull());
            DrawCast(centerPosition , castSize);
            var collider2Ds =
                    Physics2D.OverlapBoxAll(centerPosition , castSize , 0)
                             .Select(collider2D => collider2D.GetComponent<Damageable>())
                             .Where(damageable => damageable.IsNotNull());

            return collider2Ds;
        }

        private static void DrawCast(Vector2 projectilePosition , Vector2 colliderSize)
        {
            var draw = Draw.ingame;
            using (draw.WithColor(Color.red.WithA(0.2f)))
            {
                draw.SolidBox(projectilePosition.ToVector3() , colliderSize.ToVector3());
            }
        }

    #endregion
    }
}