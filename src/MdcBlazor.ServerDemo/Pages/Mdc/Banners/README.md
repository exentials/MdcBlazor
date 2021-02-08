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

## API

**MdcBanner properties**

|Property|Type|Description|
|-|-|-|
|Centered|boolean|By default, banners are positioned as leading but they can optionally be displayed centered|
|Fixed|boolean|When used below top app bars, banners should remain fixed at the top of the screen|
|Icon|string|The material icon name displayed|
|Text|string|The banner text displayed|
|PrimaryActionLabel|string|The label to display for the primary button|
|SecondaryActionLabel|string|The label to display for the secondary button|

**MdcBanner events**

|Property|Arguments|Description|
|-|-|-|
|OnPrimaryActionClick|-|Handle the primary action button click event|
|OnSecondaryActionClick|-|Handle the secondary action button click event|
|OnClosed|-|Handle the banner close event|
