## Using MdcButton

```html
<MdcButton 
    ButtonType="MdcButtonType.Text"
    Label="TEXT BUTTON"
    Disabled="disabled"
    Icon="bookmark"
    TrailingIcon="trailingIcon"
    OnClick='() => ClickHandler("TEXT BUTTON")' />
```

```csharp
@code {

    bool disabled = false;
    bool trailingIcon = true;

    private Task ClickHandler(string command)
    {
        // Do something
        return Task.CompletedTask;
    }
}
```

