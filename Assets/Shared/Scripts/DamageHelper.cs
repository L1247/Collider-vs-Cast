#region

using System.Linq;
using Drawing;
using rStarUtility.Util.Extensions.Csharp;
using rStarUtility.Util.Extensions.Unity;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class DamageHelper
    {
    #region Public Methods

        public static void DealDamage(Vector2 position , Vector2 range)
        {
            DrawCast(position , range);
            var damageables = CastHelper.Cast(position , range);
            Debug.Log($"damageables count: {damageables.Count()}");
            damageables.ForEach(damageable => Debug.Log($"{damageable}"));
        }

    #endregion

    #region Private Methods

        private static void DrawCast(Vector2 position , Vector2 size)
        {
            var draw = Draw.ingame;
            using (draw.WithColor(Color.magenta))
            {
                draw.SolidBox(position.ToVector3() , size.ToVector3());
            }
        }

    #endregion
    }
}