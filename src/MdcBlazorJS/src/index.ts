// Module alias must match Blazor component class Name

import { elements } from "./mdc/mdcBlazor"; // TODO: Should remove
import * as MdcButton from "./mdcButton/mdcButton";
import * as MdcCheckbox from "./mdcCheckbox/mdcCheckbox";
import * as MdcChip from "./mdcChip/mdcChip";
import * as MdcChipset from "./mdcChip/mdcChipSet";
import * as MdcDataTable from "./mdcDataTable/mdcDataTable";
import * as MdcDrawer from "./mdcDrawer/mdcDrawer";
import * as MdcFab from "./mdcFab/mdcFab";
import * as MdcFormField from "./mdcFormField/mdcFormField";
import * as MdcIcon from "./mdcIcon/mdcIcon";
import * as MdcIconButton from "./mdcButton/mdcIconButton";
import * as MdcIconButtonToggle from "./mdcButton/mdcIconButtonToggle";
import * as MdcList from "./mdcList/mdcList";
import * as MdcCircularProgress from "./mdcProgressIndicator/mdcCircularProgress";
import * as MdcLinearProgress from "./mdcProgressIndicator/mdcLinearProgress";
import * as MdcRadio from "./mdcRadio/mdcRadio";
import * as MdcSlider from "./mdcSlider/mdcSlider";
import * as MdcSnackbar from "./mdcSnackbar/mdcSnackbar";
import * as MdcSwitch from "./mdcSwitch/mdcSwitch";
import * as MdcTab from "./mdcTabBar/mdcTab";
import * as MdcTabBar from "./mdcTabBar/mdcTabBar";
import * as MdcTextarea from "./mdcTextInput/mdcTextarea";
import * as MdcTextField from "./mdcTextInput/mdcTextField";
import * as MdcTooltip from "./mdcTooltip/mdcTooltip";
import * as MdcTopAppBar from "./mdcTopAppBar/mdcTopAppBar";

window.exentials = window.exentials || {};

window.exentials.mdcBlazor = {
    elements, // TODO: Should remove
    MdcButton,
    MdcCheckbox,
    MdcChip,
    MdcChipset,
    MdcCircularProgress,
    MdcDataTable,
    MdcDrawer,
    MdcFab,
    MdcFormField,
    MdcIcon,
    MdcIconButton,
    MdcIconButtonToggle,
    MdcList,
    MdcLinearProgress,
    MdcRadio,
    MdcSlider,
    MdcSnackbar,
    MdcSwitch,
    MdcTextarea,
    MdcTab,
    MdcTabBar,
    MdcTextField,
    MdcTooltip,
    MdcTopAppBar
};