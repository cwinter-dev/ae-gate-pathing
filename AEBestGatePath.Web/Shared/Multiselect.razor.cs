﻿using Microsoft.AspNetCore.Components;

namespace AEBestGatePath.Web.Shared;

public partial class Multiselect<TKey, TValue> : ComponentBase where TKey : notnull
{
    /// <summary>
    /// Represents the selected options in the multiselect dropdown.
    /// </summary>
    [Parameter]
    public List<TKey> SelectedOptions { get; set; } = new();

    /// <summary>
    /// Event callback that is invoked when the selected options change.
    /// </summary>
    [Parameter]
    public EventCallback<List<TKey>> SelectedOptionsChanged { get; set; }

    /// <summary>
    /// Represents the available options in the multiselect dropdown.
    /// </summary>
    [Parameter]
    public Dictionary<TKey, TValue> Options { get; set; } = new();

    /// <summary>
    /// Function to convert an item to a string for display in the dropdown.
    /// </summary>
    [Parameter]
    public Func<TValue, string> StringSelector { get; set; } = item => item?.ToString() ?? string.Empty;

    /// <summary>
    /// The default text to display when no options are selected.
    /// </summary>
    [Parameter]
    public string DefaultText { get; set; } = "Select Options";

    /// <summary>
    /// Optional custom renderer for the selected options.
    /// If not set, items will be rendered using <see cref="StringSelector"/> and concatenated with a comma.
    /// </summary>
    [Parameter]
    public RenderFragment<IEnumerable<TValue>>? SelectedOptionsRenderer { get; set; }

    /// <summary>
    /// Whether or not the dropdown should be filterable.
    /// </summary>
    [Parameter]
    public bool CanFilter { get; set; }

    /// <summary>
    /// A function that determines whether a given item matches the filter string.
    /// Default implementation checks if the item's string representation contains the filter string, case-insensitive.
    /// </summary>
    /// <returns>Returns true if the item's string representation contains the filter string, false otherwise.</returns>
    [Parameter]
    public Func<TValue, string, bool>? FilterPredicate { get; set; }

    private bool DefaultFilterPredicate(TValue item, string filterString)
    {
        return StringSelector(item).Contains(filterString, StringComparison.OrdinalIgnoreCase);
    }
    
    /// <summary>
    /// Whether or not the virtualize component should be used to render the options.
    /// </summary>
    [Parameter]
    public bool Virtualize {get; set; }

    /// <summary>
    /// Whether or not the multiselect should allow multiple selections.
    /// </summary>
    [Parameter]
    public bool IsMultiSelect { get; set; } = true;
    
    /// <summary>
    /// Additional CSS classes to apply.
    /// </summary>
    [Parameter]
    public string? Class { get; set; }
    
    /// <summary>
    /// Additional CSS styles to apply.
    /// </summary>
    [Parameter]
    public string? Style { get; set; }
}