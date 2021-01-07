using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public class MdcEventService
    {
        private readonly Dictionary<string, IList<Func<ValueTask>>> _handlers;

        public MdcEventService()
        {
            _handlers = new Dictionary<string, IList<Func<ValueTask>>>();
        }

        public Action Subscribe(string mdcEvent, Func<ValueTask> handler)
        {
            if (!_handlers.ContainsKey(mdcEvent))
            {                
                _handlers.Add(mdcEvent, new List<Func<ValueTask>>());
            }
            _handlers[mdcEvent].Add(handler);

            return delegate () { Unsubscribe(mdcEvent, handler); };
        }

        public void Unsubscribe(string mdcEvent, Func<ValueTask> handler)
        {
            _handlers[mdcEvent]?.Remove(handler);
        }

        public Task InvokeSubscribers(string eventName, object arg = null)
        {
            if (_handlers.ContainsKey(eventName))
            {
                return Task.WhenAll(_handlers[eventName]?.AsParallel().Select(handler => handler.Invoke().AsTask()));
            }
            return Task.CompletedTask;
        }

    }
}
