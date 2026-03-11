using TMPro;
using System;
using UnityEngine;
using UnityEngine.Localization;
using ActionCode.UISystem;

namespace ActionCode.LocalizationSystem
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ButtonHandler))]
    public sealed class LanguageButtonHandler : MonoBehaviour
    {
        [SerializeField] private ButtonHandler button;
        [SerializeField] private TMP_Text label;

        public event Action<Locale> OnSelected;
        public event Action<Locale> OnConfirmed;

        private Locale locale;

        private void OnDisable() => Unbind();

        public void SetLocale(Locale locale)
        {
            this.locale = locale;

            gameObject.name = $"Button_{locale.LocaleName}";
            label.text = LocalizationManager.GetDisplayName(locale);

            Bind();
        }

        private void Bind()
        {
            button.OnSubmitted += HandleSubmition;
            button.Selection.OnSelected += HandleSelection;
        }

        private void Unbind()
        {
            button.OnSubmitted -= HandleSubmition;
            button.Selection.OnSelected -= HandleSelection;
        }

        private void HandleSubmition()
        {
            if (locale) OnConfirmed?.Invoke(locale);
        }

        private void HandleSelection()
        {
            if (locale) OnSelected?.Invoke(locale);
        }
    }
}