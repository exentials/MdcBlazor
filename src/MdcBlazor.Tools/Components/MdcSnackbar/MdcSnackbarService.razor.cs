using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcSnackbarService
    {
        private MdcSnackbar MdcSnackbar { get; set; }
        [Inject] SnackbarService SnackbarService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SnackbarService.ShowRequested += ShowSnackbar;
        }

        private async ValueTask ShowSnackbar(ISnackbarOptions options)
        {
            await MdcSnackbar.SetOptions(options);
            await MdcSnackbar.Open();
        }

        private ValueTask ShowNext(string reason)
        {
            return SnackbarService.NotifyClose(reason);
        }

        public override ValueTask DisposeAsync()
        {
            SnackbarService.ShowRequested -= ShowSnackbar;
            return base.DisposeAsync();
        }

    }
}
