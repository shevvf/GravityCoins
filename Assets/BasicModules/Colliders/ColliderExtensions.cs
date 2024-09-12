using UnityEngine;

namespace BasicModules
{
    public static class ColliderExtensions
    {
        public static float GetWorldRadius(this SphereCollider collider)
        {
            Vector3 scale = collider.transform.lossyScale;
            float absoluteRadius = Mathf.Abs(Mathf.Max(Mathf.Max(Mathf.Abs(scale.x), Mathf.Abs(scale.y)), Mathf.Abs(scale.z)) * collider.radius);
            return Mathf.Max(absoluteRadius, 0.00001F);
        }

        public static Vector3 GetWorldPosition(this SphereCollider collider)
        {
            return collider.transform.TransformPoint(collider.center);
        }

        public static Vector3 GetWorldBottomPoint(this CapsuleCollider collider)
        {
            // Определяем направление вниз вдоль оси капсулы
            Vector3 direction = Vector3.down;
            switch (collider.direction)
            {
                case 0: // X-axis
                    direction = Vector3.left;
                    break;
                case 1: // Y-axis
                    direction = Vector3.down;
                    break;
                case 2: // Z-axis
                    direction = Vector3.back;
                    break;
            }

            // Рассчитываем смещение локальной нижней точки
            Vector3 localBottomOffset = direction * (collider.height / 2);

            // Преобразуем локальные координаты смещения в мировые
            Vector3 worldBottomOffset = collider.transform.TransformVector(localBottomOffset);

            // Получаем мировую позицию центра капсулы
            Vector3 worldCenter = collider.transform.TransformPoint(collider.center);
            // Вычисляем мировую позицию нижней точки
            Vector3 worldBottomPoint = worldCenter + worldBottomOffset;

            return worldBottomPoint;
        }
    }
}
