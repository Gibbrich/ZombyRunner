using System;

namespace DefaultNamespace
{
    /// <summary>
    /// Wraps a variable in a class that triggers an
    /// event if the value changes. This is useful when
    /// values can be meaningfully compared using Equals,
    /// and when the variable changes infrequently in
    /// comparison to the number of times it is updated.
    /// </summary>
    /// <typeparam name="T">The type of the value you want to observe</typeparam>
    /// <remarks>This is a typical use case:
    /// <code>
    /// ObservableValue&lt;bool&gt; showWindow;
    /// 
    /// public void Start()
    /// {
    ///		show = new ObservableValue(false);
    ///     show.OnValueChanged += ShowHideWindow;
    /// }
    /// public void OnGUI()
    /// {
    ///		showWindow.Value = GUILayout.Toggle("Show Window", showWindow.Value);
    /// }
    /// 
    /// public void ShowHideWindow(bool isActive)
    /// {
    ///		window.gameObject.SetActive(isActive);
    /// }
    /// </code>
    /// </remarks>

    public class ObservableValue<T>
    {
        private T currentValue;

        /// <summary>
        /// Subscribe to this event to get notified when the value changes.
        /// </summary>
#pragma warning disable 0067
        public event Action<T> OnValueChange;
#pragma warning restore 0067

        public ObservableValue(T initialValue)
        {
            currentValue = initialValue;
        }
		
        public T Value
        {
            get { return currentValue; }

            set
            {
                if (!currentValue.Equals(value))
                {
                    currentValue = value;

                    if (OnValueChange != null)
                    {
                        OnValueChange(currentValue);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the value without notification.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetSilently(T value)
        {
            currentValue = value;
        }
    }
}