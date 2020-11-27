using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

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
    }
}
