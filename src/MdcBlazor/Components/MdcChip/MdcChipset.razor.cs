﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcChipset : MdcContainerComponentBase
    {
        [Parameter] public MdcChipsetType ChipsetType { get; set; }
        [Parameter] public string TrailingIcon { get; set; }
        public bool Selected { get; private set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            switch (ChipsetType)
            {
                case MdcChipsetType.None:
                    break;
                case MdcChipsetType.Choice:
                    CssAttributes.Add("mdc-chip-set--choice");
                    break;
                case MdcChipsetType.Filter:
                    CssAttributes.Add("mdc-chip-set--filter");
                    break;
                case MdcChipsetType.Input:
                    CssAttributes.Add("mdc-chip-set--input");
                    if (TrailingIcon == null)
                    {
                        TrailingIcon = MdcIcons.Cancel;
                    }
                    break;
                case MdcChipsetType.Action:
                    break;
            }
        }

        /// <summary>
        /// Indicates the chip was interacted with (via click/tap or Enter key)
        /// </summary>
        /// <param name="chipId"></param>
        /// <returns></returns>
        [JSInvokable("MDCChip:interaction")]
        public Task MDCChipInteraction(string chipId)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Indicates the chip's selection state has changed (for choice/filter chips)
        /// </summary>
        /// <param name="chipId"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        [JSInvokable("MDCChip:selection")]
        public Task MDCChipSelection(string chipId, bool selected)
        {
            this.Selected = selected;
            return Task.CompletedTask;
        }

        [JSInvokable("MDCChip:removal")]
        public Task MDCChipRemoval(string chipId, string removedAnnouncement)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Indicates the chip's trailing icon was interacted with (via click/tap or Enter key)
        /// </summary>
        /// <param name="chipId"></param>
        /// <returns></returns>
        [JSInvokable("MDCChip:trailingIconInteraction")]
        public Task MDCChipTrailingIconInteraction(string chipId)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Indicates a navigation event has occurred on a chip
        /// </summary>
        /// <param name="chipId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [JSInvokable("MDCChip:navigation")]
        public Task MDCChipNavigation(string chipId, string key)
        {
            return Task.CompletedTask;
        }
    }
}
