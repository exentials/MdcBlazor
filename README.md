# Exentials.MdcBlazor

Inspired by [SamProf/MatBlazor] I decided to build my own library for Blazor based on [Material Design Component].

### Actually Key differences are:

- Build on Dotnet 5.0
- Wrap of Material Design Component 9.0
- Source of javascript code build in Typescript
- Embedded Google Roboto Fonts and Material Icons for scenarios with no Internet access

## How to use the library

Add in de services registration section in your Startup.cs file
```
services.AddMdcBlazor();    // Enable MdcBlazor services
```

##### In your _Host.cshtml add a link reference to:
#
```html
<link href="_content/Exentials.MdcBlazor/mdcBlazor.css" rel="stylesheet" />
```

##### Optionally for use the embedded Roboto fonts and Material Icons 
#
```html
<link href="_content/Exentials.MdcBlazor/roboto/roboto.css" rel="stylesheet" />
<link href="_content/Exentials.MdcBlazor/material-icons/material-icons.css" rel="stylesheet" />
```
##### and at the end after the blazor js script
```html
<script type="module" src="_content/Exentials.MdcBlazor/mdcBlazor.js"></script>
```

### Developed controls
|Component|
|-|
|MdcButton| 
|MdcCard|
|MdcCheckbox|
|MdcDrawer|
|MdcFab|
|MdcIcon|
|MdcIconButton|
|MdcTopAppBar|
|MdcTypography|

To see it action download and execute MdcBlazor.ServerDemo project

# Todos

- A lot of todos

License
----

MIT



[SamProf/MatBlazor]: <https://github.com/SamProf/MatBlazor>
[Material Design Component]: <https://material.io/components?platform=web>