using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicModules
{
    public abstract class InventoryUI : MonoBehaviour
    {
        protected List<ItemUI> itemUIList = new();
        protected List<Item> items;

        [SerializeField]
        protected Transform itemContainer;
        [SerializeField]
        protected ItemUI itemUIPrefab;

        public Action InventoryOpened;
        public Action InventoryClosed;
        public Action<int[]> ItemsDeleted;

        public virtual void Init(List<Item> items)
        {
            OnInventoryChanged(items);
        }

        public void OnInventoryChanged(List<Item> items)
        {
            this.items = items;
            if (gameObject.activeInHierarchy)
            {
                RefreshItems();
            }
        }

        public void ToggleInventory()
        {
            if (gameObject.activeInHierarchy)
                Hide();
            else
                Show();
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
            RefreshItems();
            InventoryOpened?.Invoke();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            InventoryClosed?.Invoke();
        }

        public void RefreshItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                ItemUI itemUI = GetOrCreateItemUI(i, item);
                itemUI.Init(i, item, this);
                RefreshItemUI(item, itemUI);
            }
            // Disable extra ItemUIs
            for (int i = items.Count; i < itemUIList.Count; i++)
            {
                itemUIList[i].gameObject.SetActive(false);
            }
        }

        private ItemUI GetOrCreateItemUI(int id, Item item)
        {
            if (id <= itemUIList.Count - 1)
            {
                return itemUIList[id];
            }
            ItemUI ui = Instantiate(itemUIPrefab, itemContainer);
            ui.Clicked = OnItemClick;
            itemUIList.Add(ui);
            return ui;
        }

        protected virtual void OnItemClick(ItemUI itemUI)
        {

        }

        protected abstract void RefreshItemUI(Item item, ItemUI itemUI);
    }
}
