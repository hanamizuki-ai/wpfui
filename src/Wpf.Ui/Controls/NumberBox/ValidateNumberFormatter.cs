// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

// This Source Code is partially based on the source code provided by the .NET Foundation.

// ReSharper disable once CheckNamespace
namespace Wpf.Ui.Controls;

/// <summary>
/// Base nubmer formatter that uses default format specifier and <see cref="CultureInfo"/> that represents the culture used by the current thread.
/// </summary>
public class ValidateNumberFormatter : INumberFormatter, INumberParser
{
    /// <inheritdoc />
    public string FormatDouble(double? value)
    {
        return value?.ToString(GetFormatSpecifier(), GetCurrentCultureConverter()) ?? String.Empty;
    }

    /// <inheritdoc />
    public string FormatInt(int? value)
    {
        return value?.ToString(GetFormatSpecifier(), GetCurrentCultureConverter()) ?? String.Empty;
    }

    /// <inheritdoc />
    public string FormatUInt(uint? value)
    {
        return value?.ToString(GetFormatSpecifier(), GetCurrentCultureConverter()) ?? String.Empty;
    }

    /// <inheritdoc />
    public double? ParseDouble(string? value)
    {
        var success = Double.TryParse(value, out double d);

        return success ? d : null;
    }

    /// <inheritdoc />
    public int? ParseInt(string? value)
    {
        var success = Int32.TryParse(value, out int i);

        return success ? i : null;
    }

    /// <inheritdoc />
    public uint? ParseUInt(string? value)
    {
        var success = UInt32.TryParse(value, out uint ui);

        return success ? ui : null;
    }

    private static string GetFormatSpecifier()
    {
        return "G";
    }

    private static CultureInfo GetCurrentCultureConverter()
    {
        return CultureInfo.CurrentCulture;
    }
}
