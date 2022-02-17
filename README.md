# BlazesButtonAPI
A VRChat Button API Inspired by the old RubyButtonAPI Formatting

# A NOTE BEFORE USAGE!
I am **__NOT__** offering any support on this. You can figure it out on your own. I will not be adding anything to this either. This is just to be put out there because I know there are some people who could use this considering how popular Ruby's Button API was on the old ui.

You are free to use this button api in your projects as long as you throw my name (WTFBlaze) in the credits of your client / mod / project.

# Usage Examples

```cs
var menu = new QMNestedButton("Menu_Dashboard", "Blaze's Client", 1, 3, "Blaze's Client created by WTFBlaze!", "Blaze's Client");

var singleButton = new QMSingleButton(menu, 1, 0, "OwO", delegate
{
  Console.WriteLine("OwO Button Clicked!");
}, "Click me to write OwO in the Console!");

var toggleButton = new QMToggleButton(menu, 2, 0, "UwU Toggle", delegate
{
  Console.WriteLine("UwU Toggle: On!");
}, delegate
{
  Console.WriteLine("UwU Toggle: Off!");
}, "Click to toggle the UwU button!");

// Toggle buttons can also take a boolean input at the end to set the default starting state
var defaultStateToggle = new QMToggleButton(menu, 3, 0, "UwU Toggle", delegate
{
  Console.WriteLine("UwU Toggle: On!");
}, delegate
{
  Console.WriteLine("UwU Toggle: Off!");
}, "Click to toggle the UwU button!", true);

// Tab Buttons
var qmTabButton = new QMTabButton(delegate
{
  menu.OpenMe();
}, "Click me to do something!", btnIconVariable);
```

[Click me to go to Dubya's Github! (The creator of the old RubyButtonAPI)](https://github.com/DubyaDude)
