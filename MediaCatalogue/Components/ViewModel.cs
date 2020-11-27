using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Converters;

namespace MediaCatalogue.Components
{
    public class ViewModel : ReactiveObject, IDisposable
    {
        private readonly Lazy<CompositeDisposable> _compositeDisposable = new Lazy<CompositeDisposable>();

        public CompositeDisposable CompositeDisposable => _compositeDisposable.Value;
        public void Dispose()
        {
            if (_compositeDisposable.IsValueCreated) _compositeDisposable.Value.Dispose();
        }

        protected void RaiseAndSetIfChanged<T>(
            ref T item,
            T newItem,
            [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(item, newItem)) return;
            item = newItem;
            this.RaisePropertyChanged(propertyName);
        }
    }
}
