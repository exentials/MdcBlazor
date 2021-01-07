using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public class MdcEventHandlers
    {
        public static MdcEventService MdcEventServiceInstance { get; private set; } = new MdcEventService();

        [JSInvokable(MdcEvents.DrawerClosed)]
        public static Task DrawerClose()
        {
            return MdcEventServiceInstance.InvokeSubscribers(MdcEvents.DrawerClosed);
        }

        [JSInvokable(MdcEvents.DrawerOpened)]
        public static Task DrawerOpened()
        {
            return MdcEventServiceInstance.InvokeSubscribers(MdcEvents.DrawerOpened);
        }

        [JSInvokable(MdcEvents.TopAppBarNav)]
        public static Task NavHandler()
        {
            return MdcEventServiceInstance.InvokeSubscribers(MdcEvents.TopAppBarNav);
        }
    }
}
