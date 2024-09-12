using UnityEngine;

namespace BasicModules
{
    public class ItemUI : MonoBehaviour
    {
        protected Item item;
        protected InventoryUI inventory;
        protected int id;
        protected bool isSelected;

        [SerializeField]
        protected BetterButton button;

        public System.Action<ItemUI> Clicked;

        public Item Item => item;
        public InventoryUI Inventory => inventory;
        public int Id => id;
        public bool IsSelected => isSelected;


        public virtual void Init(int id, Item item, InventoryUI inventory)
        {
            this.id = id;
            this.item = item;
            this.inventory = inventory;
        }

        private void Awake()
        {
            button.onClick.AddListener(OnPointerClick);
        }

        public virtual void OnPointerClick()
        {
            Clicked?.Invoke(this);
        }

        public virtual void SetSelect(bool selected)
        {
            isSelected = selected;
        }
    }
}
