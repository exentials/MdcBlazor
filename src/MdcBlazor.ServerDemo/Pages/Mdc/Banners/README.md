## Using MdcBanner

```html
<MdcBanner @ref="banner1"
    Centered="centeredBanner"
    Fixed="fixedBanner"
    Icon="error_outline"
    Text="There was a problem processing a transaction on your credit card."
    PrimaryActionLabel="Learn more"
    SecondaryActionLabel="Fix it" />
```

```csharp
@code {

    MdcBanner banner1;
    bool fixedBanner;
    bool centeredBanner;

    void ShowBanner()
    {
        banner1.Open();
    }
}
```