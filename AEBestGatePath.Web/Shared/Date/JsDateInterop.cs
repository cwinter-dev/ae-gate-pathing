using Microsoft.JSInterop;

namespace AEBestGatePath.Web.Shared.Date
{
    public interface IJsDateInterop
    {
        Task<DateTime> GetLocalDate(DateTime utc);
        Task<DateTime> GetUtcDate(DateTime local);
    }
    
    public class JsDateInterop : IJsDateInterop
    {
        private readonly IJSRuntime _js;
        public JsDateInterop(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<DateTime> GetLocalDate(DateTime utc)
        {
            return DateTime.Parse(await _js.InvokeAsync<string>("getLocalTime", utc.ToString("R")));
        }

        public async Task<DateTime> GetUtcDate(DateTime local)
        {
            return DateTime.Parse(await _js.InvokeAsync<string>("getUtcTime", local));
        }
    }
}