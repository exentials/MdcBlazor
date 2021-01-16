using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{

    public class SnackbarService
    {
        private ConcurrentQueue<SnackbarOptions> _snacks;

        public event Func<ISnackbarOptions, ValueTask> ShowRequested;

        public SnackbarService()
        {
            _snacks = new ConcurrentQueue<SnackbarOptions>();
        }

        public ValueTask Send(string label)
        {
            return Send(new SnackbarOptions
            {
                Label = label
            });
        }

        public ValueTask Send(SnackbarOptions options)
        {
            _snacks.Enqueue(options);
            return InvokeSend();
        }

        private bool _waitDismiss = false;

        public ValueTask NotifyClose(string reason)
        {
            _waitDismiss = false;
            return InvokeSend();
        }

        public async ValueTask InvokeSend()
        {
            if (!_waitDismiss)
            {
                if (_snacks.TryDequeue(out var snackbarOptions))
                {
                    if (ShowRequested != null)
                    {
                        _waitDismiss = true;
                        await ShowRequested.Invoke(snackbarOptions);
                    }
                }
            }
        }
    }
}
