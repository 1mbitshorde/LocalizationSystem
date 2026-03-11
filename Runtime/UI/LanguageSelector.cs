using ActionCode.UISystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

namespace ActionCode.LocalizationSystem
{
    [DisallowMultipleComponent]
    public sealed class LanguageSelector : MonoBehaviour
    {
        [SerializeField] private ListController languages;

        [Space]
        [Tooltip("Event fired when the localization is selected.")]
        public UnityEvent OnLanguageConfirmed;

        private readonly List<LanguageButtonHandler> buttons = new();

        private void OnEnable() => PopulateLanguageButtons();
        private void OnDisable() => Dispose();

        private void Dispose()
        {
            foreach (var button in buttons)
            {
                UnbindButton(button);
            }
            buttons.Clear();
        }

        private async void PopulateLanguageButtons()
        {
            var locales = await LocalizationManager.GetLocalesAsync();
            var selectedIndex = LocalizationManager.GetLocaleIndex(locales);

            languages.Clear();

            foreach (var locale in locales)
            {
                var item = languages.Add();
                var button = item.GetComponent<LanguageButtonHandler>();

                button.SetLocale(locale);

                BindButton(button);
                buttons.Add(button);
            }

            languages.Select(selectedIndex);
        }

        private void BindButton(LanguageButtonHandler button)
        {
            button.OnConfirmed += HandleLanguageConfirmed;
            button.OnSelected += HandleLanguageSelected;
        }

        private void UnbindButton(LanguageButtonHandler button)
        {
            button.OnConfirmed -= HandleLanguageConfirmed;
            button.OnSelected -= HandleLanguageSelected;
        }


        private void HandleLanguageConfirmed(Locale locale)
        {
            LocalizationManager.Select(locale);
            OnLanguageConfirmed?.Invoke();
        }

        // GameData.Settings.LanguageCode is update by GameDataLocaleHandler
        private void HandleLanguageSelected(Locale locale) => LocalizationManager.Select(locale);
    }
}