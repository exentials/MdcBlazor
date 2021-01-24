# <img src="./MdcBlazor-icon.png" width="48" />  Exentials.MdcBlazor & Exentials.MdcBlazor.Tools
Library for Blazor based on [Material Design Component]

[![Nuget](https://img.shields.io/nuget/v/Exentials.MdcBlazor?label=nuget%20Exentials.MdcBlazor)](https://www.nuget.org/packages/Exentials.MdcBlazor)
[![Nuget](https://img.shields.io/nuget/v/Exentials.MdcBlazor.Tools?label=nuget%20Exentials.MdcBlazor.Tools)](https://www.nuget.org/packages/Exentials.MdcBlazor.Tools)
___
### Key features are:

- Build on Dotnet 5.0
- Wrap of Material Design Component Web 9.0
- Source of javascript code build in Typescript
- Embedded Google Roboto Fonts and Material Icons for scenarios with no Internet access
___

**Exentials.MdcBlazor** wraps the base Mdc components, **Exentials.MdcBlazor.Tools** depens on them 
but aim to serve richer and productive controls with less markup and code.

## Demo server application is available as docker container 
```
docker run -it exentials/mdc-blazor-server-demo:latest
```

## How to use the libraries

### Blazor Server App

#### Install the library on the Server project

```sh
Install-Package Exentials.MdcBlazor

Install-Package Exentials.MdcBlazor.Tools
```

Add on the service registration section of your Startup.cs file
```csharp
services.AddMdcBlazor();    // Enable MdcBlazor services

services.AddMdcBlazorTools(); // Enable MdcBlazor Tools services

```

##### In your _Imports.razor add the components namespace:

```csharp
@using Exentials.MdcBlazor
```

##### In your _Host.cshtml add a link reference to:

```html
<link href="_content/Exentials.MdcBlazor/mdcBlazor.css" rel="stylesheet" />  <!-- develop -->
<link href="_content/Exentials.MdcBlazor/mdcBlazor.min.css" rel="stylesheet" />  <!-- production -->
.
.
<body class="@MdcStyle.Typography">
```

##### Optionally to use the embedded Roboto fonts and Material Icons 

```html
<link href="_content/Exentials.MdcBlazor/roboto/roboto.css" rel="stylesheet" />
<link href="_content/Exentials.MdcBlazor/material-icons/material-icons.css" rel="stylesheet" />
```
##### and at the end after the blazor js script
```html
<script type="module" src="_content/Exentials.MdcBlazor/mdcBlazor.js"></script> <!-- develop -->
<script type="module" src="_content/Exentials.MdcBlazor/mdcBlazor.min.js"></script> <!-- production -->
```

### Blazor WebAssembly App

#### Install the library on both Server and Client project

```sh
Install-Package Exentials.MdcBlazor
```

Server project: Add on the service registration section of Startup.cs file
```csharp
services.AddMdcBlazor();    // Enable MdcBlazor services

services.AddMdcBlazorTools(); // Enable MdcBlazor Tools services
```

##### In _Imports.razor add the components namespace:

```csharp
@using Exentials.MdcBlazor
```

##### On Index.html (Client project) add a link reference to:

```html
<link href="_content/Exentials.MdcBlazor/mdcBlazor.css" rel="stylesheet" />  <!-- develop -->
<link href="_content/Exentials.MdcBlazor/mdcBlazor.min.css" rel="stylesheet" />  <!-- production -->
.
.
<body class="@MdcStyle.Typography">
```

##### Optionally to use the embedded Roboto fonts and Material Icons 

```html
<link href="_content/Exentials.MdcBlazor/roboto/roboto.css" rel="stylesheet" />
<link href="_content/Exentials.MdcBlazor/material-icons/material-icons.css" rel="stylesheet" />
```
##### and at the end after the blazor js script
```html
<script type="module" src="_content/Exentials.MdcBlazor/mdcBlazor.js"></script> <!-- develop -->

<script type="module" src="_content/Exentials.MdcBlazor/mdcBlazor.min.js"></script> <!-- production -->
```

##### On _Imports.razor (Client project) add the components namespace:

```csharp
@using Exentials.MdcBlazor
```

### MdcBlazor controls
|Components|Status|Material docs|
|-|-|-|
|MdcBanner|In progress|[material.io](https://material.io/components/banners/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-banner)|
|MdcButton|Complete|[material.io](https://material.io/components/buttons/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-button)|
|MdcCard|Complete|[material.io](https://material.io/components/cards/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-card)|
|MdcCheckbox|Complete|[material.io](https://material.io/components/checkboxes/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-checkbox)|
|MdcChip|In progress|[material.io](https://material.io/components/chips/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-chips)|
|MdcCircularProgress|Complete|[material.io](https://github.com/material-components/material-components-web/tree/master/packages/mdc-circular-progress) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-circular-progress)|
|MdcDataTable|In progress|[material.io](https://material.io/components/data-tables/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-data-table)|
|MdcDialog|Complete|[material.io](https://material.io/components/dialogs/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-dialog)|
|MdcDrawer|In progress|[material.io](https://material.io/components/navigation-drawer/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-drawer)|
|MdcElevation|Complete|[github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-elevation)|
|MdcFab|Complete|[material.io](https://material.io/components/buttons-floating-action-button/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-fab)|
|MdcIconButton|Complete|[material.io](https://material.io/components/buttons/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-icon-button)|
|MdcImageList|-|[material.io](https://material.io/components/image-lists/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-image-list)|
|MdcLayoutGrid|Complete|[material.io](https://material-components.github.io/material-components-web-catalog/#/component/layout-grid) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-layout-grid)|
|MdcLinearProgress|Complete|[material.io](https://github.com/material-components/material-components-web/tree/master/packages/mdc-linear-progress) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-linear-progress)|
|MdcList|Complete|[material.io](https://material.io/components/lists/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-list)|
|MdcMenu|-|[material.io](https://material.io/components/menus/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-menu)|
|MdcRadio|Complete|[material.io](https://material.io/components/radio-buttons/web#installation) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-radio)|
|MdcSegmentedButton|-|[github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-segmented-button)|
|MdcSelect|In progress|[github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-select)|
|MdcSlider|In progress|[material.io](https://material.io/components/sliders/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-slider)|
|MdcSnackbar|Complete|[material.io](https://material.io/components/snackbars/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-snackbar)|
|MdcSwitch|Complete|[material.io](https://material.io/components/switches/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-switch)|
|MdcTabBar|Complete|[material.io](https://material.io/components/tabs) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-tab-bar)|
|MdcTextField|Complete|[material.io](https://material.io/components/text-fields/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-textfield)|
|MdcTextarea|Complete|[material.io](https://material.io/components/text-fields/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-textfield#textarea)|
|MdcTooltip|In progress|[material.io](https://material.io/components/tooltips/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-tooltip)|
|MdcTopAppBar|In progress|[material.io](https://material.io/components/app-bars-top/web) - [github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-top-app-bar)|
|MdcTypography|Complete|[github](https://github.com/material-components/material-components-web/tree/master/packages/mdc-typography)|
|MdcIcon|Complete|[material.io](https://material.io/resources/icons/)|

### MdcBlazor.Tools controls

#### DataTableColumn
Simplify the table building by passing a data source and the columns definitions to display.

#### MdcSnackbarService
Handle a centralized queue of Snackbar messages.
Must place \<MdcSnackbarService/> on the main layout component.
By injecting the SnackbarService, messages could be sent to the main control.


To see it action download and execute MdcBlazor.ServerDemo project

# Todos

- A lot of todos

License
----

MIT


[Material Design Component]: <https://material.io/components?platform=web>