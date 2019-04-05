using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace GalleryApp.Extensions
{
    public class ExtendedObservableCollection<T> : ObservableCollection<T>
    {
        private bool _collectionChangedSuppressed;

        public void AddRange(IEnumerable<T> items)
        {
            var currentItemsCount = Count;
            _collectionChangedSuppressed = true;
            foreach (var item in items)
            {
                Add(item);
            }
            _collectionChangedSuppressed = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, currentItemsCount));
        }
        
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_collectionChangedSuppressed)
                base.OnCollectionChanged(e);
        }
    }
}