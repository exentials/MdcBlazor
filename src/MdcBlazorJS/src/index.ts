// Module alias must match Blazor component class Name

import { elements } from "./mdc/mdcBlazor"; // TODO: Should remove
import * as MdcButton from "./mdcButton/mdcButton";
import * as MdcCheckbox from "./mdcCheckbox/mdcCheckbox";
import * as MdcDrawer from "./mdcDrawer/mdcDrawer";
import * as MdcFab from "./mdcFab/mdcFab";
import * as MdcIcon from "./mdcIcon/mdcIcon";
import * as MdcIconButtonToggle from "./mdcButton/mdcIconButtonToggle";
import * as MdcList from "./mdcList/mdcList";
import * as MdcTextarea from "./mdcTextInput/mdcTextarea";
import * as MdcTextField from "./mdcTextInput/mdcTextField";
import * as MdcTooltip from "./mdcTooltip/mdcTooltip";
import * as MdcTopAppBar from "./mdcTopAppBar/mdcTopAppBar";

window.exentials = window.exentials || {};

window.exentials.mdcBlazor = {
    elements, // TODO: Should remove
    MdcButton,
    MdcCheckbox,
    MdcDrawer,
    MdcFab,
    MdcIcon,
    MdcIconButtonToggle,
    MdcList,
    MdcTextarea,
    MdcTextField,
    MdcTooltip,
    MdcTopAppBar
};