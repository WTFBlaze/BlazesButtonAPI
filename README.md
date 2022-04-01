# BlazesButtonAPI
A VRChat Button API Inspired by the old RubyButtonAPI Formatting

# A NOTE BEFORE USAGE!

I am **__NOT__** offering any support on this. You can figure it out on your own. I will not be adding anything to this either this is just out there because I know some people could use this considering how popular Ruby's Button API was on the old UI.
You are free to use this button API in your projects as long as you throw my name (WTFBlaze) in the credits of your client, mod, project. 
   

# Usage Examples

**__READ ME!__**
Parameter items surrounded by [] are optional!

```cs
// QMNestedMenu
// Parameters: Location (Menu Name, QMNestedButton, or QMTabMenu), X Position, Y Position, Button Text, ToolTip Text, Menu Title Text
var menu = new QMNestedButton("Menu_Dashboard", 1, 3, "Blaze's Client", "Blaze's Client created by WTFBlaze!", "Blaze's Client");

// QMSingleButton
// Paramters: Location (QMNestedButton or QMTabMenu), X Position, Y Position, Button Action, ToolTip Text, [Make Half Button (Boolean)]
var singleButton = new QMSingleButton(menu, 1, 0, "OwO", delegate
{
  Console.WriteLine("OwO Button Clicked!");
}, "Click me to write OwO in the Console!");

// QMToggleButton
// Parameters: Location (QMNestedButton or QMTabMenu), X Position, Y Position, Button Text, Toggle On Action, Toggle Off Action, ToolTip Text, [Default Toggle State (Boolean)]
var toggleButton = new QMToggleButton(menu, 2, 0, "UwU Toggle", delegate
{
  Console.WriteLine("UwU Toggle: On!");
}, delegate
{
  Console.WriteLine("UwU Toggle: Off!");
}, "Click to toggle the UwU button!");

// Tab Menu
// Parameters: ToolTip Text, Menu Title, [Sprite]
var tabMenu = new QMTabMenu("add your tooltip text here", "Menu Title", spriteVar);

// Slider
// Parameters: Menu or Transform, X Position, Y Position, Slider Label Text, Min Value, Max Value, Current Value, On Slider Changed Action
new QMSlider(tabMenu, -510, -740, "Sexy Ass Slider", 0.1f, 55, 25, delegate (float newValue)
{
  Console.WriteLine($"New Slider Value is: {newValue}");
});
```

# Exta Functions

Not only can you easily create buttons and menus but when you create these items with a variable attached you can modify them after they are created!

```cs
var exampleBtn = new QMSingleButton(menuVar, 1, 0, "Button Example", delegate {}, "Button ToolTip");

// Clicks the button (can be used inside other buttons)
exampleBtn.ClickMe();

// Destroys the button entirely
exampleBtn.DestroyMe();

// Changes the button location by the easy to use XY Axis system that you use when you initialize the item
exampleBtn.SetLocation(1, 1); // Takes 2 Floats as the parameters

// Changes whether the button can be clicked
exampleBtn.SetInteractable(true); // Takes a boolean as the parameter

// Change the tooltip text
exampleBtn.SetToolTip("UwU"); // Takes a string as the parameter

// Change what the button does when clicked
// Takes an Action as the parameter
exampleBtn.SetAction(delegate 
{
  Console.WriteLine("UwU");
});

// Toggles the button visibility on or off
exampleBtn.SetActive(true); // Takes a boolean as the parameter
```

There are much more available functions to list I am just too lazy to list them all lol

[Click me to go to Dubya's Github! (The creator of the old RubyButtonAPI)](https://github.com/DubyaDude)
