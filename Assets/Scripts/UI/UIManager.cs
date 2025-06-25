using Core;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace UIManager
{
    public class UIManager : IUIManager
    {
        private readonly Dictionary<System.Type, IUIView> _views = new();
        private readonly List<IUIView> _activeViews = new();

        [Inject]
        public void Initialize(List<IUIView> views)
        {
            foreach (var view in views)
            {
                _views[view.GetType()] = view;

                var interfaces = view.GetType().GetInterfaces()
                    .Where(i => i != typeof(IUIView) &&
                               typeof(IUIView).IsAssignableFrom(i));

                foreach (var interfaceType in interfaces)
                {
                    _views[interfaceType] = view;
                }

                view.Hide();
            }
        }

        public void ShowView<T>() where T : class, IUIView
        {
            if (_views.TryGetValue(typeof(T), out var view))
            {
                view.Show();
                if (!_activeViews.Contains(view))
                    _activeViews.Add(view);
            }
        }

        public void HideView<T>() where T : class, IUIView
        {
            if (_views.TryGetValue(typeof(T), out var view))
            {
                view.Hide();
                _activeViews.Remove(view);
            }
        }

        public void HideAllViews()
        {
            foreach (var view in _activeViews.ToList())
            {
                view.Hide();
            }
            _activeViews.Clear();
        }

        public T GetView<T>() where T : class, IUIView
        {
            return _views.TryGetValue(typeof(T), out var view) ? view as T : null;
        }
    }
}