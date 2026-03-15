using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace ActionCode.LocalizationSystem
{
    /// <summary>
    /// Extensions for <see cref="LocalizedString"/> instances.
    /// </summary>
    public static class LocalizedStringExtension
    {
        /// <summary>
        /// Updates the dynamic localization using the given variable name and value.
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName">The dynamic variable name inside the Local Variables.</param>
        /// <param name="value">The dynamic variable value inside the Local Variables.</param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, string value)
        {
            var variable = localization[variableName] as StringVariable;
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, int value)
        {
            var variable = localization[variableName] as IntVariable;
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, uint value)
        {
            var variable = localization[variableName] as UIntVariable;
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, bool value)
        {
            var variable = localization[variableName] as BoolVariable;
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, float value)
        {
            var variable = localization[variableName] as FloatVariable;
            variable.Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)"/>
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="variableName"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='variableName']"/></param>
        /// <param name="value"><inheritdoc cref="UpdateDynamicLocalization(LocalizedString, string, string)" path="/param[@name='value']"/></param>
        /// <param name="format">The Date Time format. Default is abbreviated date (d).</param>
        public static void UpdateDynamicLocalization(this LocalizedString localization, string variableName, System.DateTime value, string format = "d")
        {
            var variable = localization[variableName] as StringVariable;

            localization.StringChanged += _ =>
            {
                var code = UnityEngine.Localization.Settings.LocalizationSettings.SelectedLocale.Identifier.Code;
                var info = new System.Globalization.CultureInfo(code);
                variable.Value = value.ToString(format, info);
            };
        }
    }
}