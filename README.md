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
|Component|Status|Material reference|
|-|-|-|
|MdcTopAppBar|In progress|[https://material.io/components/app-bars-top/web](https://material.io/components/app-bars-top/web)|
|MdcBanner|In progress|[https://material.io/components/banners/web](https://material.io/components/banners/web)|
|MdcButton|Complete|[https://material.io/components/buttons/web](https://material.io/components/buttons/web)|
|MdcIconButton|Complete|[https://material.io/components/buttons/web](https://material.io/components/buttons/web)|
|MdcFab|Complete|[https://material.io/components/buttons-floating-action-button/web](https://material.io/components/buttons-floating-action-button/web)|
|MdcCard|Complete|[https://material.io/components/cards/web](https://material.io/components/cards/web)|
|MdcCheckbox|Complete|[https://material.io/components/checkboxes/web](https://material.io/components/checkboxes/web)|
|MdcChip|In progress|[https://material.io/components/chips/web](https://material.io/components/chips/web)|
|MdcDataTable|In progress|[https://material.io/components/data-tables/web](https://material.io/components/data-tables/web)|
|MdcDialog|Complete|[https://material.io/components/dialogs/we](https://material.io/components/dialogs/web)|
|MdcDivider|-|[https://material.io/components/dividers/web](https://material.io/components/dividers/web)|
|MdcImageList|-|[https://material.io/components/image-lists/web](https://material.io/components/image-lists/web)|
|MdcList|Complete|[https://material.io/components/lists/web](https://material.io/components/lists/web)|
|MdcMenu|-|[https://material.io/components/menus/web](https://material.io/components/menus/web)|
|MdcDrawer|In progress|[https://material.io/components/navigation-drawer/web](https://material.io/components/navigation-drawer/web)|
|MdcCircularProgress|Complete|[https://github.com/material-components/material-components-web/tree/master/packages/mdc-circular-progress](https://github.com/material-components/material-components-web/tree/master/packages/mdc-circular-progress)|
|MdcLinearProgress|Complete|[https://github.com/material-components/material-components-web/tree/master/packages/mdc-linear-progress](https://github.com/material-components/material-components-web/tree/master/packages/mdc-linear-progress)|
|MdcRadio|Complete|[https://material.io/components/radio-buttons/web#installation](https://material.io/components/radio-buttons/web#installation)|
|MdcSlider|In progress|[https://material.io/components/sliders/web](https://material.io/components/sliders/web)|
|MdcSnackbar|Complete|[https://material.io/components/snackbars/web](https://material.io/components/snackbars/web)|
|MdcSwitch|Complete|[https://material.io/components/switches/web](https://material.io/components/switches/web)|
|MdcTabBar|Complete|[https://material.io/components/tabs](https://material.io/components/tabs)|
|MdcTextField|Complete|[https://material.io/components/text-fields/web](https://material.io/components/text-fields/web)|
|MdcTextarea|Complete|[https://material.io/components/text-fields/web](https://material.io/components/text-fields/web)|
|MdcTooltip|In progress|[https://material.io/components/tooltips/web](https://material.io/components/tooltips/web)|
|MdcSelect|In progress|[https://github.com/material-components/material-components-web/tree/master/packages/mdc-select](https://github.com/material-components/material-components-web/tree/master/packages/mdc-select)|
||||
|MdcElevation|Complete||
|MdcIcon|Complete|[https://material.io/resources/icons/](https://material.io/resources/icons/)|
|MdcTypography|Complete|[https://github.com/material-components/material-components-web/tree/master/packages/mdc-typography](https://github.com/material-components/material-components-web/tree/master/packages/mdc-typography)|

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