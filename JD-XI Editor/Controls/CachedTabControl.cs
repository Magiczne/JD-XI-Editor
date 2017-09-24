using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

//https://stackoverflow.com/questions/9794151/stop-tabcontrol-from-recreating-its-children
namespace JD_XI_Editor.Controls
{
    [TemplatePart(Name = "PART_ItemsHolder", Type = typeof(Panel))]
    public class CachedTabControl : TabControl
    {
        private Panel _itemsHolderPanel;

        public CachedTabControl()
        {
            // This is necessary so that we get the initial databound selected item
            ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }

        /// <summary>
        ///     If containers are done, generate the selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            if (ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                ItemContainerGenerator.StatusChanged -= ItemContainerGenerator_StatusChanged;
                UpdateSelectedItem();
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///     Get the ItemsHolder and generate any children
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _itemsHolderPanel = GetTemplateChild("PART_ItemsHolder") as Panel;
            UpdateSelectedItem();
        }

        /// <inheritdoc />
        /// <summary>
        ///     When the items change we remove any generated panel children and add any new ones as necessary
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            if (_itemsHolderPanel == null)
                return;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    _itemsHolderPanel.Children.Clear();
                    break;

                case NotifyCollectionChangedAction.Add:
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                        foreach (var item in e.OldItems)
                        {
                            var cp = FindChildContentPresenter(item);
                            if (cp != null)
                                _itemsHolderPanel.Children.Remove(cp);
                        }

                    // Don't do anything with new items because we don't want to
                    // create visuals that aren't being shown

                    UpdateSelectedItem();
                    break;

                case NotifyCollectionChangedAction.Replace:
                    throw new NotImplementedException("Replace not implemented yet");
            }
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            UpdateSelectedItem();
        }

        private void UpdateSelectedItem()
        {
            if (_itemsHolderPanel == null)
                return;

            // Generate a ContentPresenter if necessary
            var item = GetSelectedTabItem();
            if (item != null)
                CreateChildContentPresenter(item);

            // show the right child
            foreach (ContentPresenter child in _itemsHolderPanel.Children)
                child.Visibility = ((TabItem) child.Tag).IsSelected ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        ///     Create child content presenter
        /// </summary>
        /// <param name="item"></param>
        private void CreateChildContentPresenter(object item)
        {
            if (item == null)
                return;

            var cp = FindChildContentPresenter(item);

            if (cp != null)
                return;

            // the actual child to be added.  cp.Tag is a reference to the TabItem
            cp = new ContentPresenter
            {
                Content = item is TabItem ? ((TabItem) item).Content : item,
                ContentTemplate = SelectedContentTemplate,
                ContentTemplateSelector = SelectedContentTemplateSelector,
                ContentStringFormat = SelectedContentStringFormat,
                Visibility = Visibility.Collapsed,
                Tag = item is TabItem ? item : ItemContainerGenerator.ContainerFromItem(item)
            };
            _itemsHolderPanel.Children.Add(cp);
        }

        /// <summary>
        ///     FInd child content presenter
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private ContentPresenter FindChildContentPresenter(object data)
        {
            if (data is TabItem)
                data = ((TabItem) data).Content;

            if (data == null)
                return null;

            if (_itemsHolderPanel == null)
                return null;

            foreach (ContentPresenter cp in _itemsHolderPanel.Children)
                if (cp.Content == data)
                    return cp;

            return null;
        }

        /// <summary>
        ///     Get selected tab item
        /// </summary>
        /// <returns></returns>
        protected TabItem GetSelectedTabItem()
        {
            var selectedItem = SelectedItem;
            if (selectedItem == null)
                return null;

            if (!(selectedItem is TabItem item))
                item = ItemContainerGenerator.ContainerFromIndex(SelectedIndex) as TabItem;

            return item;
        }
    }
}