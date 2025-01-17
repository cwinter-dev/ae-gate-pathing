using AEBestGatePath.Web.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AEBestGatePath.Web.Shared.Tables;

public abstract class PagedTableComponentBase<T> : ComponentBase
{
    [Inject]
    private IJSRuntime JsRuntime { get; set; }
    private const int PageDefault = 1;
    private int _page = PageDefault;
    private const int ItemsPerPageDefault = 25;
    private int _itemsPerPage = ItemsPerPageDefault;
    private string _search = string.Empty;
    private string _sort = null;
    private bool _asc = true;
    
    protected PagedTable<T> Table;

    [Parameter]
    [SupplyParameterFromQuery(Name = nameof(Page))]
    public int Page
    {
        get => _page;
        set
        {
            HandleNewValueWithQuery(value, _page, PageDefault, nameof(Page), x => _page = x);
        }
    }

    [Parameter]
    [SupplyParameterFromQuery(Name = nameof(Search))]
    public string Search
    {
        get => _search;
        set
        {
            HandleNewValueWithQuery(value, _search, string.Empty, nameof(Search), x => _search = x);
        }
    }

    [Parameter]
    [SupplyParameterFromQuery(Name = nameof(ItemsPerPage))]
    public int ItemsPerPage
    {
        get => _itemsPerPage;
        set
        {
            HandleNewValueWithQuery(value, _itemsPerPage, ItemsPerPageDefault, nameof(ItemsPerPage), x => _itemsPerPage = x);
        }
    }

    [Parameter]
    [SupplyParameterFromQuery(Name = nameof(Asc))]
    public bool? Asc
    {
        get => _asc;
        set => HandleNewValueWithQuery(value, _asc, true, nameof(Asc), x => _asc = x ?? true);
    }

    [Parameter]
    [SupplyParameterFromQuery(Name = nameof(Sort))]
    public string Sort
    {
        get => _sort;
        set
        {
            HandleNewValueWithQuery(value, _sort, null, nameof(Sort), x => _sort = x);
        }
    }

    protected void HandleNewValueWithQuery<TQuery>(TQuery v, TQuery cv, TQuery def, string name, Action<TQuery> set)
    {
        var newValue = v == null || v.Equals(default(TQuery)) ? def : v;
        //var newValue = v?.Equals(default(TQuery)) ?? false ? def : v;
        if (newValue == null && cv == null || newValue != null && newValue.Equals(cv)) return;
        set(newValue);
        _debounceFetch?.Invoke();
        PushUpdatedState(name, newValue?.Equals(def) ?? false ? null : newValue);
        InvokeAsync(StateHasChanged);
    }

    private void PushUpdatedState(string query, object newValue)
    {
        JsRuntime.InvokeVoidAsync("pushState", new Dictionary<string, object> { { query, newValue } });
    }

    private Action _debounceFetch;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (_debounceFetch == null && Table != null)
            _debounceFetch = ((Func<Task>)Table.Fetch).Debounce(50);
        await base.OnAfterRenderAsync(firstRender);
    }
}