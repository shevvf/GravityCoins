using UnityEngine;
using UnityEngine.UI;

namespace BasicModules
{
    [RequireComponent(typeof(Mask))]
    public class BarMask : MaskableGraphic
    {
        [Range(0, 1)]
        [SerializeField]
        private float value = 1f;
        public float leftPadding = 0f;
        public float rightPadding = 0f;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            // normalized pivot position
            float pivotX = rectTransform.pivot.x;
            float pivotY = rectTransform.pivot.y;

            float width = rectTransform.rect.width;
            float height = rectTransform.rect.height;

            float zeroX = width * -pivotX;
            float zeroY = height * -pivotY;

            float maxX = width - width * pivotX;
            float maxY = height - height * pivotY;

            float value2 = Mathf.Lerp(zeroX + leftPadding, maxX - rightPadding, value);

            UIVertex vertex = UIVertex.simpleVert;
            vertex.color = color;

            vertex.position = new Vector3((zeroX + leftPadding), zeroY);
            vh.AddVert(vertex);

            vertex.position = new Vector3((zeroX + leftPadding), maxY);
            vh.AddVert(vertex);

            vertex.position = new Vector3(value2, maxY);
            vh.AddVert(vertex);

            vertex.position = new Vector3(value2, zeroY);
            vh.AddVert(vertex);

            vh.AddTriangle(0, 1, 2);
            vh.AddTriangle(2, 3, 0);
        }

        public void UpdateBar(float value)
        {
            this.value = value;
            SetVerticesDirty();
        }
    }
}
