namespace AEBestGatePath.Web.Utils;

public static class Shared
{
    public static Action Debounce(this Func<Task> func, int milliseconds = 300)
    {
        CancellationTokenSource? cancelTokenSource = null;

        return () =>
        {
            cancelTokenSource?.Cancel();
            cancelTokenSource = new CancellationTokenSource();

            Task.Delay(milliseconds, cancelTokenSource.Token)
                .ContinueWith(async t =>
                {
                    if (t.IsCompletedSuccessfully)
                        await func();
                }, TaskScheduler.Default);
        };
    }
}