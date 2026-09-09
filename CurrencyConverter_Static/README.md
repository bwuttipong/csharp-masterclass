# Currency Converter — WPF (C#)

Tutorial: [Build a Currency Converter Application Using WPF in C# with Static Data](https://tutorials.eu/build-a-currency-converter-application-using-wpf-in-c-with-static-data/)  
Author: Denis Panjuta · Published: 24 March 2023  
Category: C# · [tutorials.eu](https://tutorials.eu/)

> In this article, you will learn how to create a C# Currency Converter using WPF. All you need to have is a good knowledge of C#.

---

## What is a Currency Converter?

A **Currency Converter** is a WPF application designed to convert one currency into another to check its corresponding value. The program is generally part of a website, or it forms a mobile app. It is based on the current market or bank exchange rates.

To convert one currency into another, all you need to do is enter an amount of money (e.g., `1000`) and choose the currency (e.g., "United States Dollar"). You can try multiple monetary selections. The application then calculates the entered amount with the exchange value and displays the corresponding amount of money.

---

## What is WPF?

**WPF** stands for **Windows Presentation Foundation**. WPF is a UI framework that creates desktop client applications. It is part of .NET. It supports a broad set of application development features, including resources, an application model, layout, data binding, documents, controls, graphics, and security.

WPF uses **Extensible Application Markup Language (XAML)** to provide a declarative model for application programming.

---

## Technical Requirements

Before moving further, the author assumes you are familiar with the following:

### 1. Programming basics

The core logic is written in **C#**.

> C# is a general-purpose, modern, and object-oriented programming language pronounced as "C sharp." Microsoft developed it. C# is widely used for developing web applications and desktop applications.

### 2. IDE (Integrated Development Environment)

Visual Studio is the recommended editor.

- [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)

---

## Step-by-Step Guide

### Create a new project

1. Open **Visual Studio** and select **Create a new project** under the **Get started** menu.
2. Select **WPF App (.Net Framework)**.
3. Click **Next**.

### Configure project

1. Enter the project name. The article uses `CurrencyConverter_Static`.
2. Select the location where you want to save the project.
3. Click **Create**.

Visual Studio creates the project with default pages:

- **MainWindow.xaml** — defines a WPF application and its resources; specifies the UI. Automatically shown when the application starts.
- **MainWindow.xaml.cs** — code-behind file that handles events declared in `MainWindow.xaml`. Contains a partial class for the window defined in XAML.
- **App.xaml** — the declarative starting point of the application. Subscribe to essential application events (start, unhandled exceptions, etc.). Code-behind: `App.xaml.cs`. Works like Windows Forms — two partial classes allowing work in both markup (XAML) and code-behind.
- **App.config** — XML file that can be changed as required. Controls which protected resources an application can access, which versions of assemblies it will use, and where remote applications and objects are located. Developers can put settings here (e.g., connection strings).

#### Default `MainWindow.xaml`

```xml
<Window x:Class="CurrencyConverter_Static.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CurrencyConverter_Static"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>

    </Grid>
</Window>
```

---

### Designing the Currency Converter application

Change the following properties in the XAML code for the `Window` element:

- Set **Title** to `"Currency Converter"`.
- Remove default **Height** and **Width** from the window tag and add **SizeToContent="WidthAndHeight"** to set the window size according to content.
- Set **WindowStartupLocation** to `"CenterScreen"` to center the window.
- Set **Icon="Images\money.png"** to set the application icon visible in the title bar.

#### Updated window properties

```xml
<Window x:Class="CurrencyConverter_Static.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CurrencyConverter_Static"
        mc:Ignorable="d"
        Title="Currency Converter" SizeToContent="WidthAndHeight" WindowStartupLocation="CenterScreen" Icon="Images\money.png">
    <Grid>

    </Grid>
</Window>
```

#### Add the Grid Row Definitions

Add the following between the `<Grid></Grid>` tag:

```xml
<Grid.RowDefinitions>
    <RowDefinition Height="60"></RowDefinition>
    <RowDefinition Height="80"></RowDefinition>
    <RowDefinition Height="150"></RowDefinition>
    <RowDefinition Height="100"></RowDefinition>
    <RowDefinition Height="150"></RowDefinition>
</Grid.RowDefinitions>
```

**Grid Panel** — provides a flexible area consisting of rows and columns. Child elements can be arranged in tabular form. Items can be added to any specific row and column using `Grid.Row` and `Grid.Column` properties. By default, the Grid panel is created with one row and one column. Multiple rows and columns are created by `RowDefinitions` and `ColumnDefinitions` properties.

#### Border and Gradient

**Border** in WPF works a bit differently. The Border in XAML has its own control that can be applied to other controls or XAML elements. For placing a border around an element, WPF provides the Border element. Border has `Width`, `Height`, `Background`, `HorizontalAlignment`, and `VerticalAlignment` properties.

```xml
<Border Grid.Row="2" Width="800" CornerRadius="10" BorderThickness="5">
    <Border.BorderBrush>
        <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
            <GradientStop Color="#ec2075" Offset="0.0" />
            <GradientStop Color="#f33944" Offset="0.50" />
        </LinearGradientBrush>
    </Border.BorderBrush>
    <Rectangle Grid.Row="2">
        <Rectangle.Fill>
            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                <GradientStop Color="#ec2075" Offset="0.0" />
                <GradientStop Color="#f33944" Offset="0.50" />
            </LinearGradientBrush>
        </Rectangle.Fill>
    </Rectangle>
</Border>
```

- **BorderThickness** — thickness of the border.
- **BorderBrush** — brush used to draw the border.
- **CornerRadius** — degree to which the corners of the border are rounded. Default is zero (sharp corners).

**LinearGradientBrush** — paints an area with a linear gradient. Default is diagonal. `StartPoint` and `EndPoint` represent the start and endpoints of a gradient.

**Gradient Stop properties:**

- **Color** — set using a predefined color name or hexadecimal notation.
- **Offset** — determines the position of the color between start and endpoints.

**Rectangle** — represents a rectangle shape. `Width` and `Height` represent the rectangle's dimensions. `Fill` fills the interior.

#### StackPanel design

```xml
<StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Height="50" Width="1000" VerticalAlignment="Center">
    <Label Height="50" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Currency Converter" FontSize="25" Foreground="#ec2075" FontWeight="Bold"></Label>
</StackPanel>
<StackPanel Grid.Row="1" Orientation="Vertical" HorizontalAlignment="Center" Height="80" Width="1000">
    <Label Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Converted Currency" FontSize="20"></Label>
    <Label Name="lblCurrency" Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" FontSize="20"></Label>
</StackPanel>
<StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Top" Height="60" Width="800">
    <Label Height="40" Width="150" Content="Enter Amount : " Margin="35 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
    <Label Height="40" Width="150" Content="From : " Margin="110 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
    <Label Height="40" Width="150" Content="To : " Margin="130 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
</StackPanel>
<StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" Height="90" Width="800" VerticalAlignment="Bottom">
    <TextBox Name="txtCurrency" Width="200" Height="30" Margin="40 0 0 0" PreviewTextInput="NumberValidationTextBox" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top"></TextBox>
    <ComboBox Name="cmbFromCurrency" Width="170" Height="30" Margin="60 0 40 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxDropDownHeight="150"></ComboBox>
    <fa:ImageAwesome Icon="Exchange" Height="30" Width="30" Foreground="White" VerticalAlignment="Top"></fa:ImageAwesome>
    <ComboBox Name="cmbToCurrency" Width="170" Height="30" Margin="40 0 0 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxDropDownHeight="150"></ComboBox>
</StackPanel>
<StackPanel Grid.Row="3" Height="100" Width="1000" Orientation="Horizontal">
    <Button Name="Convert" Height="40" Width="150" Content="Convert" Click="Convert_Click" Margin="350 0 20 0" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
        <Button.Background>
            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                <GradientStop Color="#ec2075" Offset="0.0"/>
                <GradientStop Color="#f33944" Offset="0.5"/>
            </LinearGradientBrush>
         </Button.Background>
    </Button>
    <Button Name="Clear" Height="40" Width="150" Content="Clear" Click="Clear_Click" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
         <Button.Background>
              <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                  <GradientStop Color="#ec2075" Offset="0.0"/>
                  <GradientStop Color="#f33944" Offset="0.5"/>
              </LinearGradientBrush>
         </Button.Background>
    </Button>
</StackPanel>
<StackPanel Grid.Row="4" Height="150" Width="800" HorizontalAlignment="Center" VerticalAlignment="Center" Orientation="Horizontal">
    <Image Height="150" Width="150" Source="Images\Logo.png" VerticalAlignment="Center" HorizontalAlignment="Center" Margin="325 0"/>
</StackPanel>
```

**StackPanel** — a useful and straightforward layout panel in XAML. Child elements are arranged in a single line, either horizontally or vertically, based on the `Orientation` property. Used whenever a list is about to be created.

- Any control in WPF can be placed within a grid using `Grid.Row` and `Grid.Column` properties (values start at 0).
- In the StackPanel tag, add controls used in the program: Label, TextBox, ComboBox, Button, Image, etc.
- Set control properties as required: `Height`, `Width`, `HorizontalAlignment`, `VerticalAlignment`, `Margin`, `FontSize`, `Foreground`, `Content`, `Name`, etc.
- `lblCurrency` label displays the converted currency name and value.
- `fa:ImageAwesome` tag shows the icon. To use this control, first add **"fontawesome.wpf"** to the library:
  - Open Solution Explorer
  - Right-click on the project name → **Manage NuGet Packages**
  - Select the **Browse** tab, search for **"fontawesome.wpf"**, select it, and click **Install**
- **Fontawesome** gives scalable vector icons that can instantly be customized.
- The `Click` attribute of the Button element adds the click event handler. `Click="Convert_Click"` is raised when the Button control is clicked.
- Between the button tag, put `<Button.Background>` to set the button background color.

#### App.xaml — ButtonRound style

Between the `<Application.Resources></Application.Resources>` tag in `App.xaml`, add:

```xml
<Style x:Key="ButtonRound" TargetType="Button">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="Button">
                <Border CornerRadius="5" Background="{TemplateBinding Background}" BorderThickness="0.5">
                    <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"></ContentPresenter>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

- **x:Key** — set name to `"ButtonRound"`. Use in the button with `Style="{StaticResource ButtonRound}"`.
- **TargetType** — sets the target controls to apply this style to.

#### MainWindow.xaml — final code

```xml
<Window x:Class="CurrencyConverter_Static.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CurrencyConverter_Static"
        xmlns:fa="http://schemas.fontawesome.io/icons/"
        mc:Ignorable="d"
        Title="Currency Converter" SizeToContent="WidthAndHeight" WindowStartupLocation="CenterScreen" Icon="Images\money.png">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="60"></RowDefinition>
            <RowDefinition Height="80"></RowDefinition>
            <RowDefinition Height="150"></RowDefinition>
            <RowDefinition Height="100"></RowDefinition>
            <RowDefinition Height="150"></RowDefinition>
        </Grid.RowDefinitions>
        <Border Grid.Row="2" Width="800" CornerRadius="10" BorderThickness="5">
            <Border.BorderBrush>
                <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                    <GradientStop Color="#ec2075" Offset="0.0" />
                    <GradientStop Color="#f33944" Offset="0.50" />
                </LinearGradientBrush>
            </Border.BorderBrush>
            <Rectangle Grid.Row="2">
                <Rectangle.Fill>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                        <GradientStop Color="#ec2075" Offset="0.0" />
                        <GradientStop Color="#f33944" Offset="0.50" />
                    </LinearGradientBrush>
                </Rectangle.Fill>
            </Rectangle>
        </Border>

        <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Height="50" Width="1000" VerticalAlignment="Center">
            <Label Height="50" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Currency Converter" FontSize="25" Foreground="#ec2075" FontWeight="Bold"></Label>
        </StackPanel>
        <StackPanel Grid.Row="1" Orientation="Vertical" HorizontalAlignment="Center" Height="80" Width="1000">
            <Label Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Converted Currency" FontSize="20"></Label>
            <Label Name="lblCurrency" Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" FontSize="20"></Label>
        </StackPanel>
        <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Top" Height="60" Width="800">
            <Label Height="40" Width="150" Content="Enter Amount : " Margin="35 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
            <Label Height="40" Width="150" Content="From : " Margin="110 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
            <Label Height="40" Width="150" Content="To : " Margin="130 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
        </StackPanel>
        <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" Height="90" Width="800" VerticalAlignment="Bottom">
            <TextBox Name="txtCurrency" Width="200" Height="30" Margin="40 0 0 0" PreviewTextInput="NumberValidationTextBox" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top"></TextBox>
            <ComboBox Name="cmbFromCurrency" Width="170" Height="30" Margin="60 0 40 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxDropDownHeight="150"></ComboBox>
            <fa:ImageAwesome Icon="Exchange" Height="30" Width="30" Foreground="White" VerticalAlignment="Top"></fa:ImageAwesome>
            <ComboBox Name="cmbToCurrency" Width="170" Height="30" Margin="40 0 0 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxDropDownHeight="150"></ComboBox>
        </StackPanel>
        <StackPanel Grid.Row="3" Height="100" Width="1000" Orientation="Horizontal">
            <Button Name="Convert" Height="40" Width="150" Content="Convert" Click="Convert_Click" Margin="350 0 20 0" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                <Button.Background>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                        <GradientStop Color="#ec2075" Offset="0.0"/>
                        <GradientStop Color="#f33944" Offset="0.5"/>
                    </LinearGradientBrush>
                </Button.Background>
            </Button>
            <Button Name="Clear" Height="40" Width="150" Content="Clear" Click="Clear_Click" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                 <Button.Background>
                      <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                          <GradientStop Color="#ec2075" Offset="0.0"/>
                          <GradientStop Color="#f33944" Offset="0.5"/>
                      </LinearGradientBrush>
                 </Button.Background>
            </Button>
        </StackPanel>
        <StackPanel Grid.Row="4" Height="150" Width="800" HorizontalAlignment="Center" VerticalAlignment="Center" Orientation="Horizontal">
            <Image Height="150" Width="150" Source="Images\Logo.png" VerticalAlignment="Center" HorizontalAlignment="Center" Margin="325 0"/>
        </StackPanel>

    </Grid>
</Window>
```

---

### Application core part

#### MainWindow.xaml.cs — default code

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverter_Static
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
```

- **namespace** — provides a way to keep one set of names separate from another. Class names declared in one namespace do not conflict with the same class names declared in another.
- **partial class** — a special feature of C# providing the ability to implement the functionality of a single class into multiple files. When the application is compiled, all files are combined into a single class file.
- **InitializeComponent()** — a method automatically written by the Form Designer when you create/change forms. Visual Studio adds code to the `InitializeComponent` method, called in the Form constructor.

> Remove unnecessary namespaces from the code.

```csharp
using System.Windows;

namespace CurrencyConverter_Static
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
```

#### Bind Currency From and To ComboBox

Create a private method `BindCurrency()`.

```csharp
private void BindCurrency()
{

}
```

- **private** — access modifier. Type or member can be accessed only by code in the same class or struct.
- **void** — used for method signatures to declare a method that does not return any value.

Create an object of DataTable:

```csharp
DataTable dtCurrency = new DataTable();
```

- Import namespace `using System.Data` on top of `MainWindow.xaml.cs`.
- The **DataTable** object represents tabular data as an in-memory, tabular cache of rows, columns, and constraints.

```csharp
// Add display column in DataTable
dtCurrency.Columns.Add("Text");

// Add value column in DataTable
dtCurrency.Columns.Add("Value");

// Add rows in Datatable with text and value
dtCurrency.Rows.Add("--SELECT--", 0);
dtCurrency.Rows.Add("INR", 1);
dtCurrency.Rows.Add("USD", 75);
dtCurrency.Rows.Add("EUR", 85);
dtCurrency.Rows.Add("SAR", 20);
dtCurrency.Rows.Add("POUND", 5);
dtCurrency.Rows.Add("DEM", 43);
```

- In DataTable add two columns: **Text** and **Value**.
- Add rows with data.

```csharp
// The data to currency ComboBox is assigned from DataTable
cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;

// DisplayMemberPath property is used to display data in ComboBox
cmbFromCurrency.DisplayMemberPath = "Text";

// SelectedValuePath property is used to set the value in ComboBox
cmbFromCurrency.SelectedValuePath = "Value";

// SelectedIndex property is used to bind hint in the ComboBox. Default value is Select.
cmbFromCurrency.SelectedIndex = 0;

// All properties are set for 'To Currency' ComboBox as 'From Currency' ComboBox
cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
cmbToCurrency.DisplayMemberPath = "Text";
cmbToCurrency.SelectedValuePath = "Value";
cmbToCurrency.SelectedIndex = 0;
```

- After adding data to the DataTable, assign data to the ComboBox using the `ItemsSource` attribute.
- Set the ComboBox `DisplayMemberPath` attribute — what to show in the ComboBox as display text.
- Set the ComboBox `SelectedValuePath` attribute — what to set as value.
- Make sure both properties are set with the same DataTable column name.
- After adding the `BindCurrency()` method, call it in `MainWindow()` method (called first when the application runs).

#### ClearControls

```csharp
// ClearControls used for clear all controls value
private void ClearControls()
{
    txtCurrency.Text = string.Empty;
    if (cmbFromCurrency.Items.Count > 0)
        cmbFromCurrency.SelectedIndex = 0;
    if (cmbToCurrency.Items.Count > 0)
        cmbToCurrency.SelectedIndex = 0;
    lblCurrency.Content = "";
    txtCurrency.Focus();
}
```

- Creates a new method for `ClearControls()`.
- Used to clear all control data which the user entered.
- Add the method call in `MainWindow()`.

#### Number Validation

```csharp
// Allow only the integer value in TextBox
private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
{
    // Regular Expression to add regex — add library using System.Text.RegularExpressions;
    Regex regex = new Regex("^[0-9]+");
    e.Handled = regex.IsMatch(e.Text);
}
```

- Creates a method `NumberValidationTextBox()`. Used for the Amount TextBox only, which allows the user to enter numbers. Uses Regular Expression.
- Import namespace `using System.Text.RegularExpressions` on top of `MainWindow.xaml.cs`.
- Import `using System.Windows.Input` namespace. `TextCompositionEventArgs` deals with changes while composing text.

#### Calculation of Currency Converter

```csharp
// Convert button click event
private void Convert_Click(object sender, RoutedEventArgs e)
{

}
```

- Add the convert button click event. Fires when the convert button is clicked.

```csharp
// Create a variable as ConvertedValue with double data type to store currency converted value
double ConvertedValue;

// Check amount textbox is Null or Blank
if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
{
    // If amount textbox is Null or Blank it will show the below message box
    MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

    // After clicking on message box OK sets the Focus on amount textbox
    txtCurrency.Focus();
    return;
}
// Else if the currency from is not selected or it is default text --SELECT--
else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
{
    // It will show the message
    MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

    // Set focus on From ComboBox
    cmbFromCurrency.Focus();
    return;
}
// Else if Currency To is not Selected or Select Default Text --SELECT--
else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
{
    // It will show the message
    MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

    // Set focus on To ComboBox
    cmbToCurrency.Focus();
    return;
}
```

- Declare a variable `ConvertedValue` with double datatype — stores the converted value and shows it in the label.
- Check validation: if Amount TextBox is blank → show "please enter amount".
- Check validation: if user did not select any currency from FromCurrency ComboBox → show "Please select currency from".
- Check validation: if user did not select any currency from ToCurrency ComboBox → show "Please select currency to".

```csharp
// If From and To ComboBox selected values are same
if (cmbFromCurrency.Text == cmbToCurrency.Text)
{
    // The amount textbox value set in ConvertedValue.
    // double.Parse is used to convert datatype String To Double.
    // TextBox text has string and ConvertedValue is double datatype
    ConvertedValue = double.Parse(txtCurrency.Text);

    // Show in label converted currency and converted currency name.
    // ToString("N3") is used to place 000 after the dot(.)
    lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
}
else
{
    // Calculation for currency converter: From Currency value multiply(*)
    // with amount textbox value and then the total is divided(/) with To Currency value
    ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());

    // Show in label converted currency and converted currency name.
    lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
}
```

- If **from currency** and **to currency** have the same name → store the amount textbox value in `ConvertedValue`. E.g., enter 10, select USD → USD, show "USD 10.000".
- If From and To Currency are not the same → else part executes.
- **From Currency** value is multiplied (`*`) with the Amount TextBox value, then that total is divided (`/`) by **To Currency** value → stored in `ConvertedValue`.
- Display the converted Currency name with ConvertedValue in the label.

```csharp
// Clear button click event
private void Clear_Click(object sender, RoutedEventArgs e)
{
    // ClearControls method is used to clear all control value
    ClearControls();
}
```

- Creates a clear button click event.
- Calls the `ClearControls()` method to clear all controls from the input.

#### MainWindow.xaml.cs — final code

```csharp
using System.Windows;
using System.Windows.Input;

// This library is used for Regular Expression
using System.Text.RegularExpressions;

// This library is used for DataTable
using System.Data;

namespace CurrencyConverter_Static
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ClearControls method is used to clear all control values
            ClearControls();

            // BindCurrency is used to bind currency name with the value in the ComboBox
            BindCurrency();
        }

        #region Bind Currency From and To ComboBox
        private void BindCurrency()
        {
            // Create a DataTable Object
            DataTable dtCurrency = new DataTable();

            // Add the text column in the DataTable
            dtCurrency.Columns.Add("Text");

            // Add the value column in the DataTable
            dtCurrency.Columns.Add("Value");

            // Add rows in the DataTable with text and value
            dtCurrency.Rows.Add("--SELECT--", 0);
            dtCurrency.Rows.Add("INR", 1);
            dtCurrency.Rows.Add("USD", 75);
            dtCurrency.Rows.Add("EUR", 85);
            dtCurrency.Rows.Add("SAR", 20);
            dtCurrency.Rows.Add("POUND", 5);
            dtCurrency.Rows.Add("DEM", 43);

            // DataTable data assigned from the currency ComboBox
            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;

            // DisplayMemberPath property is used to display data in the ComboBox
            cmbFromCurrency.DisplayMemberPath = "Text";

            // SelectedValuePath property is used to set the value in the ComboBox
            cmbFromCurrency.SelectedValuePath = "Value";

            // SelectedIndex property is used to bind the ComboBox to its default selected item
            cmbFromCurrency.SelectedIndex = 0;

            // All properties are set to To Currency ComboBox as it is in the From Currency ComboBox
            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }
        #endregion

        #region Button Click Event

        // Convert the button click event
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            // Create the variable as ConvertedValue with double datatype to store currency converted value
            double ConvertedValue;

            // Check if the amount textbox is Null or Blank
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                // If amount textbox is Null or Blank it will show this message box
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                // After clicking on messagebox OK set focus on amount textbox
                txtCurrency.Focus();
                return;
            }
            // Else if currency From is not selected or select default text --SELECT--
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                // Show the message
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                // Set focus on the From ComboBox
                cmbFromCurrency.Focus();
                return;
            }
            // Else if currency To is not selected or select default text --SELECT--
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                // Show the message
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                // Set focus on the To ComboBox
                cmbToCurrency.Focus();
                return;
            }

            // Check if From and To ComboBox selected values are same
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                // Amount textbox value set in ConvertedValue.
                // double.Parse is used for converting the datatype String To Double.
                // TextBox text has string and ConvertedValue is double Datatype
                ConvertedValue = double.Parse(txtCurrency.Text);

                // Show the label converted currency and converted currency name and ToString("N3") is used to place 000 after the dot(.)
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {
                // Calculation for currency converter: From Currency value multiply(*)
                // With the amount textbox value and then that total divided(/) with To Currency value
                ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());

                // Show the label converted currency and converted currency name.
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
        }

        // Clear Button click event
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // ClearControls method is used to clear all controls value
            ClearControls();
        }
        #endregion

        #region Extra Events

        // ClearControls method is used to clear all controls value
        private void ClearControls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;
            lblCurrency.Content = "";
            txtCurrency.Focus();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) // Allow Only Integer in Text Box
        {
            // Regular Expression is used to add regex.
            // Add Library using System.Text.RegularExpressions;
            Regex regex = new Regex("^[0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion
    }
}
```

---

## Summary

In this article, you learned how to create a **Currency Converter** application in **WPF**. So far, static data has been used to assign currency values. A future article will show how to do it using a database.

---

## Notes

- Article uses **FontAwesome.WPF** NuGet package for the exchange icon (`fa:ImageAwesome`). Latest stable version: `4.7.0.9` (.NET Framework). No stable newer version exists (newer releases are alpha).
- Images referenced: `Images\money.png` (app icon, 16×16), `Images\Logo.png` (display image, 150×150).
- Exchange rates used (static, INR base): INR=1, USD=75, EUR=85, SAR=20, POUND=5, DEM=43.

---

*Source: [tutorials.eu — Build a Currency Converter Application Using WPF in C# with Static Data](https://tutorials.eu/build-a-currency-converter-application-using-wpf-in-c-with-static-data/)*

---

# Currency Converter — WPF (C#) with Database

Tutorial: [Build a Currency Converter Application Using WPF in C# with Database](https://tutorials.eu/build-a-currency-converter-application-using-wpf-in-c-with-database/)  
Author: Denis Panjuta · Published: 1 October 2020  
Category: C# · [tutorials.eu](https://tutorials.eu/)

> In this article, you will learn how to create the "Currency Converter" application using WPF in C# with a database. In the previous article, I have shown you how to build a Currency Converter using static data. Now I will show you to build it using a database. So, let's start.

**NOTE:** In the previous article, ["Build a currency converter application using WPF in C# with static data"](https://tutorials.eu/build-a-currency-converter-application-using-wpf-in-c-with-static-data/), you learned everything about the currency converter application and "What is WPF?" etc. Check out that article first if you are new to this one.

---

## Technical Requirements

You are already familiar with the C# **Programming Language** and **IDE** (Visual Studio). Now for building the same application using a database you need to know about the **Basics of SQL**.

### Basic Knowledge of SQL

**SQL** stands for **Structured Query Language**. It is used to communicate with a database.

> Standard SQL commands such as "Create," "Insert," "Update," "Delete," "Drop," and "Select" will be used to accomplish almost everything that one needs to do with a database.

---

## Step-by-Step Guide for Building a Currency Converter Application Using WPF and C# with Database

In the previous article, you did almost similar steps. The author recommends creating a new project instead of making the previous project more complex.

### Create a new project

1. Open **Visual Studio** and select **Create a new project** under the **Get started** menu.
2. Select **WPF App (.Net Framework)**.
3. Click **Next**.

### Configure project

1. Enter the project name. The article uses `CurrencyConverter_Database`.
2. Choose the location where you want to save the project.
3. Click **Create**.

Visual Studio creates the project with default pages:

- **MainWindow.xaml**
- **MainWindow.xaml.cs**
- **App.xaml**
- **App.config**

(These files were explained in the previous static-data article.)

#### Default `MainWindow.xaml`

```xml
<Window x:Class="CurrencyConverter_Database.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CurrencyConverter_Database"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>

    </Grid>
</Window>
```

### Designing the application

Change the following properties in the XAML code for the `Window` element:

- Set **Title** to `"Currency Converter"`.
- Remove default **Height** and **Width** from the window tag and add **SizeToContent="WidthAndHeight"** to set the window size according to content.
- Set **WindowStartupLocation** to `"CenterScreen"` to center the window.
- Set **Icon="Images\money.png"** to set the application icon visible in the title bar.

#### Updated window properties

```xml
<Window x:Class="CurrencyConverter_Database.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CurrencyConverter_Database"
        mc:Ignorable="d"
        Title="Currency Converter" SizeToContent="WidthAndHeight" WindowStartupLocation="CenterScreen" Icon="Images\money.png">
    <Grid>

    </Grid>
</Window>
```

#### TabControl

The WPF **TabControl** is usually positioned on the top of the controller, which allows you to access it by clicking on the tab header. It splits your interface up into different areas. Tab controls are commonly used in Windows applications.

Each tab represents a **TabItem** element, where the `Header` property controls the text shown on it. You may define an element inside it that will be shown if the tab is active.

```xml
<TabControl Name="tbMain" TabStripPlacement="Top">
    <TabItem Name="tbConverter" Header="Currency Converter"></TabItem>
    <TabItem Name="tbMaster" Header="Currency Master"></TabItem>
</TabControl>
```

---

#### Designing the Currency Converter tab

Add the code below between the `<TabItem Name="tbConverter" Header="Currency Converter"></TabItem>` tag.

**Grid Panel** — provides a flexible area consisting of rows and columns. Child elements can be arranged in tabular form. Items can be added to any specific row and column using `Grid.Row` and `Grid.Column` properties. By default, the Grid panel is created with one row and one column. Multiple rows and columns are created by `RowDefinitions` and `ColumnDefinitions` properties.

```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="60"></RowDefinition>
        <RowDefinition Height="80"></RowDefinition>
        <RowDefinition Height="150"></RowDefinition>
        <RowDefinition Height="100"></RowDefinition>
        <RowDefinition Height="150"></RowDefinition>
    </Grid.RowDefinitions>
</Grid>
```

(Border and StackPanel usage is explained in the previous static-data article.)

#### Border

```xml
<Border Grid.Row="2" Width="800" CornerRadius="10" BorderThickness="5" Margin="100,0">
    <Border.BorderBrush>
        <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
            <GradientStop Color="#ec2075" Offset="0.0" />
            <GradientStop Color="#f33944" Offset="0.50" />
        </LinearGradientBrush>
    </Border.BorderBrush>
    <Rectangle Grid.Row="2">
        <Rectangle.Fill>
            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                <GradientStop Color="#ec2075" Offset="0.0" />
                <GradientStop Color="#f33944" Offset="0.50" />
            </LinearGradientBrush>
        </Rectangle.Fill>
    </Rectangle>
</Border>
```

#### StackPanels

```xml
<StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Height="50" Width="1000" VerticalAlignment="Center" Margin="0,5">
    <Label Height="50" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Currency Converter" FontSize="25" Foreground="#ec2075" FontWeight="Bold"></Label>
</StackPanel>

<StackPanel Grid.Row="1" Orientation="Vertical" HorizontalAlignment="Center" Height="80" Width="1000">
    <Label Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Converted Currency" FontSize="20"></Label>
    <Label Name="lblCurrency" Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" FontSize="20"></Label>
</StackPanel>

<StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Top" Height="60" Width="800" Margin="100,0">
    <Label Height="40" Width="150" Content="Enter Amount : " Margin="35 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
    <Label Height="40" Width="150" Content="From : " Margin="110 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
    <Label Height="40" Width="150" Content="To : " Margin="130 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
</StackPanel>

<StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" Height="90" Width="800" VerticalAlignment="Bottom" Margin="100,0">
    <TextBox Name="txtCurrency" Width="200" Height="30" Margin="40 0 0 0" PreviewTextInput="NumberValidationTextBox" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top"></TextBox>
    <ComboBox Name="cmbFromCurrency" Width="170" Height="30" Margin="60 0 40 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" SelectionChanged="cmbFromCurrency_SelectionChanged" PreviewKeyDown="cmbFromCurrency_PreviewKeyDown" MaxDropDownHeight="150"></ComboBox>
    <fa:ImageAwesome Icon="Exchange" Height="30" Width="30" Foreground="White" VerticalAlignment="Top"></fa:ImageAwesome>
    <ComboBox Name="cmbToCurrency" Width="170" Height="30" Margin="40 0 0 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" SelectionChanged="cmbToCurrency_SelectionChanged" PreviewKeyDown="cmbToCurrency_PreviewKeyDown" MaxDropDownHeight="150"></ComboBox>
</StackPanel>

<StackPanel Grid.Row="3" Height="100" Width="1000" Orientation="Horizontal">
    <Button Name="Convert" Height="40" Width="150" Content="Convert" Click="Convert_Click" Margin="350 0 20 0" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
        <Button.Background>
            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                <GradientStop Color="#ec2075" Offset="0.0"/>
                <GradientStop Color="#f33944" Offset="0.5"/>
            </LinearGradientBrush>
        </Button.Background>
    </Button>
    <Button Name="Clear" Height="40" Width="150" Content="Clear" Click="Clear_Click" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
        <Button.Background>
            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                <GradientStop Color="#ec2075" Offset="0.0"/>
                <GradientStop Color="#f33944" Offset="0.5"/>
            </LinearGradientBrush>
        </Button.Background>
    </Button>
</StackPanel>

<StackPanel Grid.Row="4" Height="150" Width="800" HorizontalAlignment="Center" VerticalAlignment="Center" Orientation="Horizontal">
    <Image Height="150" Width="150" Source="Images\Logo.png" VerticalAlignment="Center" HorizontalAlignment="Center" Margin="325 0"/>
</StackPanel>
```

#### App.xaml — ButtonRound style

```xml
<Style x:Key="ButtonRound" TargetType="Button">
    <Setter Property="Background" Value="AliceBlue"></Setter>
    <Setter Property="Foreground" Value="White"></Setter>
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="Button">
                <Border CornerRadius="5" Background="{TemplateBinding Background}" BorderThickness="0.5">
                    <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"></ContentPresenter>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

---

#### Designing the Currency Master tab

**DataGrid** control — enables you to edit and display data from many sources, such as a SQL database, or any other bindable data source.

DataGrid columns can display text, controls (such as a ComboBox), or any other WPF content (buttons, images, or content in a template). A `DataGridTemplateColumn` can be used to display data defined in a template.

DataGrid can be customized in appearance (color, size, cell font). It supports all templating functionality and styling of other WPF controls. It also includes default and customizable behaviors for sorting, editing, and validation.

```xml
<TabItem Name="tbMaster" Header="Currency Master">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="60"></RowDefinition>
            <RowDefinition Height="100"></RowDefinition>
            <RowDefinition Height="60"></RowDefinition>
            <RowDefinition Height="200"></RowDefinition>
            <RowDefinition Height="150"></RowDefinition>
        </Grid.RowDefinitions>
        <Border Grid.Row="1" Width="800" CornerRadius="10" BorderThickness="5" Margin="100,0">
            <Border.BorderBrush>
                <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                    <GradientStop Color="#ec2075" Offset="0.0" />
                    <GradientStop Color="#f33944" Offset="0.50" />
                </LinearGradientBrush>
            </Border.BorderBrush>
            <Rectangle Grid.Row="1">
                <Rectangle.Fill>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                        <GradientStop Color="#ec2075" Offset="0.0" />
                        <GradientStop Color="#f33944" Offset="0.50" />
                    </LinearGradientBrush>
                </Rectangle.Fill>
            </Rectangle>
        </Border>

        <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Height="50" Width="1000" VerticalAlignment="Center" Margin="0,5">
            <Label Height="50" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Currency Master" FontSize="25" Foreground="#ec2075" FontWeight="Bold"></Label>
        </StackPanel>
        <StackPanel Grid.Row="1" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Top" Height="40" Width="800" Margin="100,0">
            <Label Height="40" Width="180" Content="Enter Amount : " Margin="180 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
            <Label Height="40" Width="180" Content="Currency Name : " Margin="60 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
        </StackPanel>
        <StackPanel Grid.Row="1" Orientation="Horizontal" HorizontalAlignment="Center" Height="60" Width="800" VerticalAlignment="Bottom" Margin="100,0">
            <TextBox Name="txtAmount" Width="200" Height="30" Margin="180 0 0 0" PreviewTextInput="NumberValidationTextBox" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top"></TextBox>
            <TextBox Name="txtCurrencyName" Width="200" Height="30" Margin="40 0 0 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxLength="50" CharacterCasing="Upper"></TextBox>
        </StackPanel>
        <StackPanel Grid.Row="2" Height="60" Width="1000" Orientation="Horizontal">
            <Button Name="btnSave" Height="40" Width="150" Content="Save" Click="btnSave_Click" Margin="350 0 20 0" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                <Button.Background>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                        <GradientStop Color="#ec2075" Offset="0.0"/>
                        <GradientStop Color="#f33944" Offset="0.5"/>
                    </LinearGradientBrush>
                </Button.Background>
            </Button>
            <Button Name="btnCancel" Height="40" Width="150" Content="Cancel" Click="btnCancel_Click" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                <Button.Background>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                        <GradientStop Color="#ec2075" Offset="0.0"/>
                        <GradientStop Color="#f33944" Offset="0.5"/>
                    </LinearGradientBrush>
                </Button.Background>
            </Button>
        </StackPanel>
        <StackPanel Height="200" Width="800" Grid.Row="3" Margin="150,0" VerticalAlignment="Top">
            <DataGrid Name="dgvCurrency" AutoGenerateColumns="False" Height="180" Margin="10" Width="480" Background="Transparent" CanUserAddRows="False" SelectedCellsChanged="dgvCurrency_SelectedCellsChanged" SelectionUnit="Cell" VerticalScrollBarVisibility="Auto">
                <DataGrid.Columns>
                    <DataGridTextColumn x:Name="Id" Header="Id" Width="100" CanUserResize="False" Visibility="Hidden" Binding="{Binding Path=Id}"/>
                    <DataGridTemplateColumn Header="" Width="70" IsReadOnly="True" DisplayIndex="0">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Image Source="Images\edit-button.png" ToolTip="Edit" Width="20" Height="20"  x:Name="Revise"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>

                    <DataGridTemplateColumn Header="" Width="70" IsReadOnly="True" DisplayIndex="1">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Image Source="Images\delete-button.png" ToolTip="Delete" Width="20" Height="20"  x:Name="Delete"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>

                    <DataGridTextColumn x:Name="Amount" Header="Amount" Width="100" CanUserResize="False" CanUserReorder="False" Binding="{Binding Path=Amount}" IsReadOnly="True"/>
                    <DataGridTextColumn x:Name="CurrencyName" Header="Currency Name" Width="*" MinWidth="20" CanUserResize="False" CanUserReorder="False" Binding="{Binding Path=CurrencyName}" IsReadOnly="True"/>
                </DataGrid.Columns>
            </DataGrid>
        </StackPanel>
        <StackPanel Grid.Row="4" Height="150" Width="800" HorizontalAlignment="Center" VerticalAlignment="Center" Orientation="Horizontal">
            <Image Height="150" Width="150" Source="Images\Logo.png" VerticalAlignment="Center" HorizontalAlignment="Center" Margin="325 0"/>
        </StackPanel>
    </Grid>
</TabItem>
```

---

#### MainWindow.xaml — final code

```xml
<Window x:Class="CurrencyConverter_Database.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CurrencyConverter_Database"
        xmlns:fa="http://schemas.fontawesome.io/icons/"
        mc:Ignorable="d"
        Title="Currency Converter" SizeToContent="WidthAndHeight" WindowStartupLocation="CenterScreen" Icon="Images\money.png">
    <TabControl Name="tbMain" TabStripPlacement="Top">
        <TabItem Name="tbConverter" Header="Currency Converter">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="60"></RowDefinition>
                    <RowDefinition Height="80"></RowDefinition>
                    <RowDefinition Height="150"></RowDefinition>
                    <RowDefinition Height="100"></RowDefinition>
                    <RowDefinition Height="150"></RowDefinition>
                </Grid.RowDefinitions>
                <Border Grid.Row="2" Width="800" CornerRadius="10" BorderThickness="5" Margin="100,0">
                    <Border.BorderBrush>
                        <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                            <GradientStop Color="#ec2075" Offset="0.0" />
                            <GradientStop Color="#f33944" Offset="0.50" />
                        </LinearGradientBrush>
                    </Border.BorderBrush>
                    <Rectangle Grid.Row="2">
                        <Rectangle.Fill>
                            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                                <GradientStop Color="#ec2075" Offset="0.0" />
                                <GradientStop Color="#f33944" Offset="0.50" />
                            </LinearGradientBrush>
                        </Rectangle.Fill>
                    </Rectangle>
                </Border>

                <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Height="50" Width="1000" VerticalAlignment="Center" Margin="0,5">
                    <Label Height="50" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Currency Converter" FontSize="25" Foreground="#ec2075" FontWeight="Bold"></Label>
                </StackPanel>
                <StackPanel Grid.Row="1" Orientation="Vertical" HorizontalAlignment="Center" Height="80" Width="1000">
                    <Label Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Converted Currency" FontSize="20"></Label>
                    <Label Name="lblCurrency" Height="40" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" FontSize="20"></Label>
                </StackPanel>
                <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Top" Height="60" Width="800" Margin="100,0">
                    <Label Height="40" Width="150" Content="Enter Amount : " Margin="35 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
                    <Label Height="40" Width="150" Content="From : " Margin="110 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
                    <Label Height="40" Width="150" Content="To : " Margin="130 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
                </StackPanel>
                <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" Height="90" Width="800" VerticalAlignment="Bottom" Margin="100,0">
                    <TextBox Name="txtCurrency" Width="200" Height="30" Margin="40 0 0 0" PreviewTextInput="NumberValidationTextBox" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top"></TextBox>
                    <ComboBox Name="cmbFromCurrency" Width="170" Height="30" Margin="60 0 40 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" SelectionChanged="cmbFromCurrency_SelectionChanged" PreviewKeyDown="cmbFromCurrency_PreviewKeyDown" MaxDropDownHeight="150"></ComboBox>
                    <fa:ImageAwesome Icon="Exchange" Height="30" Width="30" Foreground="White" VerticalAlignment="Top"></fa:ImageAwesome>
                    <ComboBox Name="cmbToCurrency" Width="170" Height="30" Margin="40 0 0 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" SelectionChanged="cmbToCurrency_SelectionChanged" PreviewKeyDown="cmbToCurrency_PreviewKeyDown" MaxDropDownHeight="150"></ComboBox>
                </StackPanel>
                <StackPanel Grid.Row="3" Height="100" Width="1000" Orientation="Horizontal">
                    <Button Name="Convert" Height="40" Width="150" Content="Convert" Click="Convert_Click" Margin="350 0 20 0" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                        <Button.Background>
                            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                                <GradientStop Color="#ec2075" Offset="0.0"/>
                                <GradientStop Color="#f33944" Offset="0.5"/>
                            </LinearGradientBrush>
                        </Button.Background>
                    </Button>
                    <Button Name="Clear" Height="40" Width="150" Content="Clear" Click="Clear_Click" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                        <Button.Background>
                            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                                <GradientStop Color="#ec2075" Offset="0.0"/>
                                <GradientStop Color="#f33944" Offset="0.5"/>
                            </LinearGradientBrush>
                        </Button.Background>
                    </Button>
                </StackPanel>
                <StackPanel Grid.Row="4" Height="150" Width="800" HorizontalAlignment="Center" VerticalAlignment="Center" Orientation="Horizontal">
                    <Image Height="150" Width="150" Source="Images\Logo.png" VerticalAlignment="Center" HorizontalAlignment="Center" Margin="325 0"/>
                </StackPanel>
            </Grid>
        </TabItem>

        <TabItem Name="tbMaster" Header="Currency Master">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="60"></RowDefinition>
                    <RowDefinition Height="100"></RowDefinition>
                    <RowDefinition Height="60"></RowDefinition>
                    <RowDefinition Height="200"></RowDefinition>
                    <RowDefinition Height="150"></RowDefinition>
                </Grid.RowDefinitions>
                <Border Grid.Row="1" Width="800" CornerRadius="10" BorderThickness="5" Margin="100,0">
                    <Border.BorderBrush>
                        <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                            <GradientStop Color="#ec2075" Offset="0.0" />
                            <GradientStop Color="#f33944" Offset="0.50" />
                        </LinearGradientBrush>
                    </Border.BorderBrush>
                    <Rectangle Grid.Row="1">
                        <Rectangle.Fill>
                            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                                <GradientStop Color="#ec2075" Offset="0.0" />
                                <GradientStop Color="#f33944" Offset="0.50" />
                            </LinearGradientBrush>
                        </Rectangle.Fill>
                    </Rectangle>
                </Border>

                <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Height="50" Width="1000" VerticalAlignment="Center" Margin="0,5">
                    <Label Height="50" Width="1000" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="Currency Master" FontSize="25" Foreground="#ec2075" FontWeight="Bold"></Label>
                </StackPanel>
                <StackPanel Grid.Row="1" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Top" Height="40" Width="800" Margin="100,0">
                    <Label Height="40" Width="180" Content="Enter Amount : " Margin="180 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
                    <Label Height="40" Width="180" Content="Currency Name : " Margin="60 0 0 0" VerticalAlignment="Bottom" Foreground="White" FontSize="20"></Label>
                </StackPanel>
                <StackPanel Grid.Row="1" Orientation="Horizontal" HorizontalAlignment="Center" Height="60" Width="800" VerticalAlignment="Bottom" Margin="100,0">
                    <TextBox Name="txtAmount" Width="200" Height="30" Margin="180 0 0 0" PreviewTextInput="NumberValidationTextBox" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top"></TextBox>
                    <TextBox Name="txtCurrencyName" Width="200" Height="30" Margin="40 0 0 0" FontSize="18" VerticalContentAlignment="Center" VerticalAlignment="Top" MaxLength="50" CharacterCasing="Upper"></TextBox>
                </StackPanel>
                <StackPanel Grid.Row="2" Height="60" Width="1000" Orientation="Horizontal">
                    <Button Name="btnSave" Height="40" Width="150" Content="Save" Click="btnSave_Click" Margin="350 0 20 0" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                        <Button.Background>
                            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                                <GradientStop Color="#ec2075" Offset="0.0"/>
                                <GradientStop Color="#f33944" Offset="0.5"/>
                            </LinearGradientBrush>
                        </Button.Background>
                    </Button>
                    <Button Name="btnCancel" Height="40" Width="150" Content="Cancel" Click="btnCancel_Click" Foreground="White" FontSize="20" Style="{StaticResource ButtonRound}">
                        <Button.Background>
                            <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                                <GradientStop Color="#ec2075" Offset="0.0"/>
                                <GradientStop Color="#f33944" Offset="0.5"/>
                            </LinearGradientBrush>
                        </Button.Background>
                    </Button>
                </StackPanel>
                <StackPanel Height="200" Width="800" Grid.Row="3" Margin="150,0" VerticalAlignment="Top">
                    <DataGrid Name="dgvCurrency" AutoGenerateColumns="False" Height="180" Margin="10" Width="480" Background="Transparent" CanUserAddRows="False" SelectedCellsChanged="dgvCurrency_SelectedCellsChanged" SelectionUnit="Cell" VerticalScrollBarVisibility="Auto">
                        <DataGrid.Columns>
                            <DataGridTextColumn x:Name="Id" Header="Id" Width="100" CanUserResize="False" Visibility="Hidden" Binding="{Binding Path=Id}"/>
                            <DataGridTemplateColumn Header="" Width="70" IsReadOnly="True" DisplayIndex="0">
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Image Source="Images\edit-button.png" ToolTip="Edit" Width="20" Height="20"  x:Name="Revise"/>
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>

                            <DataGridTemplateColumn Header="" Width="70" IsReadOnly="True" DisplayIndex="1">
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Image Source="Images\delete-button.png" ToolTip="Delete" Width="20" Height="20"  x:Name="Delete"/>
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>

                            <DataGridTextColumn x:Name="Amount" Header="Amount" Width="100" CanUserResize="False" CanUserReorder="False" Binding="{Binding Path=Amount}" IsReadOnly="True"/>
                            <DataGridTextColumn x:Name="CurrencyName" Header="Currency Name" Width="*" MinWidth="20" CanUserResize="False" CanUserReorder="False" Binding="{Binding Path=CurrencyName}" IsReadOnly="True"/>
                        </DataGrid.Columns>
                    </DataGrid>
                </StackPanel>
                <StackPanel Grid.Row="4" Height="150" Width="800" HorizontalAlignment="Center" VerticalAlignment="Center" Orientation="Horizontal">
                    <Image Height="150" Width="150" Source="Images\Logo.png" VerticalAlignment="Center" HorizontalAlignment="Center" Margin="325 0"/>
                </StackPanel>
            </Grid>
        </TabItem>
    </TabControl>
</Window>
```

---

## Add Local SQL Database in Application

A database accessed through a server is called **a service-based database**. It uses an **MDF data file**, which is the SQL Server format. For connecting the SQL Server database, the SQL Server service must be running because it processes your requests and accesses the data file.

**A local database** is a database that can be used locally on a computer. It doesn't require a server. The advantage of using a local database is that you can easily migrate your project from one computer system to another (you don't need to set up/configure a database server). Microsoft provides a local database within Visual Studio, often called SQL CE (CE stands for Compact Edition).

A local database is essential for developing small-scale C# applications because it doesn't require a server to store it.

### Steps to create a local database

1. Open Solution Explorer.
2. Right-click on the application name → **Add > New Folder**.
3. Set folder name **Database**.
4. Right-click on **Database** folder → **Add > New Item**.
5. Select a **Service-Based Database** under the Data menu. Set the database name to **CurrencyConverter**. Database extension is `.mdf`.
6. Click **Add**.

After clicking Add, the database is created and shown in Solution Explorer under the Database folder. The database can be opened by double-clicking in **Server Explorer**, which roughly corresponds to SQL Server Management Studio.

#### Add table

Right-click on **Tables → Add New Table**. A new table is created with an ID field as a template. The window splits into two parts: **Design** and **T-SQL**. T-SQL script generates automatically.

Add three columns:

- **Id** — primary key with `int` datatype, set identity (1,1).
  - A **Primary Key** constraint uniquely identifies each record in a table. Primary keys cannot contain NULL values and must be UNIQUE. A table can have only one primary key.
  - **Identity:** `Identity(seed, increment)` — seed is the value of the first row loaded into the table. Default value of seed and increment is one, i.e., (1,1). Increment is the incremental value added to the identity value of the previous row.
- **Amount** — stores currency value, datatype `float`.
- **CurrencyName** — stores currency name, datatype `nvarchar(50)`.

After adding columns, use the T-SQL syntax below and click the **Update** button to save changes.

#### T-SQL Syntax

```sql
CREATE TABLE [dbo].[Currency_Master] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Amount]       FLOAT (53)    NULL,
    [CurrencyName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```

If you subsequently rename the table in the script, a completely new table will be created as a copy.

#### Adding a connection string to the database

The connection to the database can be found by opening the database → **Properties** and taking the values under **Connection String**. In this example, the data source shows local DB with the file path. Copy the connection string.

Example:
> Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hp\source\repos\CurrencyConverter_Database\Database\CurrencyConverter.mdf;Integrated Security=True

Open **App.config** from Solution Explorer. Add the connection string between the `<configuration></configuration>` tag.

```xml
<connectionStrings>
    <add name="ConnectionString" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hp\source\repos\CurrencyConverter_Database\Database\CurrencyConverter.mdf;Integrated Security=True"/>
</connectionStrings>
```

**In the connection string:**

- **Data Source** — identifies the server name (IP address, machine domain name, or local machine).
- **Initial Catalog** — identifies the database name.
- **Integrated Security** — using Windows authentication. `Integrated Security="True"` means database authentication login with server authentication. `Integrated Security="false"` means otherwise.
- **User Id** — name of the user configured in the SQL server.
- **Password** — password matching SQL server user id.

Now add the connection string and save the **App.config** file.

---

## Main Part of the Application

### MainWindow.xaml.cs — default code

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverter_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
```

**namespace** — provides a way to keep one set of names separate from another. Class names declared in one namespace do not conflict with the same class names declared in another.

**partial class** — a special feature of C# providing the ability to implement the functionality of a single class into multiple files. When the application is compiled, all files are combined into a single class file.

**InitializeComponent()** — a method automatically written by the Form Designer when you create/change forms. Visual Studio adds code to the `InitializeComponent` method, called in the Form constructor.

> Remove unnecessary namespaces from the code.

```csharp
using System.Windows;

namespace CurrencyConverter_Database
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
```

### Database objects

Create objects for SQL connection, SQL command, and SQL DataAdapter. Before working with the database, import the data provider namespace: `using System.Data.SqlClient`.

```csharp
using System.Windows;
using System.Data.SqlClient;

namespace CurrencyConverter_Database
{
    public partial class MainWindow : Window
    {
        // Create an object for SqlConnection
        SqlConnection con = new SqlConnection();

        // Create an object for SqlCommand
        SqlCommand cmd = new SqlCommand();

        // Create object for SqlDataAdapter
        SqlDataAdapter da = new SqlDataAdapter();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
```

- **SqlConnection** — represents a unique session to an SQL server data source. With a client/server database system, it is equivalent to a network connection to the server. Used with a SQL data adapter and SQL command to increase performance when connecting to a Microsoft SQL Server database.

Create a **mycon()** method to establish a connection with a SQL Server database.

- Add `using System` namespace (fundamental classes, base classes, value/reference data types, events, event handlers, interfaces, attributes, exception processing).
- To use **ConfigurationManager** class, add reference **System.Configuration**:
  - Open Solution Explorer → right-click on References → **Add Reference** → find **System.Configuration**, check the checkbox, click **OK**.
  - Add namespace `using System.Configuration` on top of `MainWindow.xaml.cs`.
- **con.Open()** — method opens a database connection with the property settings specified by the ConnectionString.

```csharp
public void mycon()
{
    // Database connection string
    String Conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    con = new SqlConnection(Conn);
    con.Open(); // Connection Open
}
```

---

### Bind Currency From and To ComboBox

Create a private method `BindCurrency()`.

```csharp
// Create a method for binding the currency name and currency value using From currency and To currency ComboBox
private void BindCurrency()
{

}
```

- **private** — access modifier. Type or member can be accessed only by code in the same class or struct.
- **void** — used for method signatures to declare a method that does not return any value.

- Add the **mycon()** method to connect with the database and open the database connection.
- To use DataTable, add namespace `using System.Data`.
- **DataTable** object represents tabular data as an in-memory, tabular cache of rows, columns, and constraints.
- `DataTable dt = new DataTable()` — creates an empty data table.
- `cmd = new SqlCommand()` — allows you to query and send commands to a database.
- **cmd.CommandType** — decides what type of object a command will execute.
- `da = new SqlDataAdapter(cmd)` — DataAdapter constructor accepts a parameter containing the command text of the object's select command property.
- **da.Fill(dt)** — DataAdapter serves as a bridge between a DataSet and a data source to retrieve and save data.

```csharp
mycon();

// Create an object for DataTable
DataTable dt = new DataTable();

// Write query for get data from Currency_Master table
cmd = new SqlCommand("select Id, CurrencyName from Currency_Master", con);

// CommandType define which type of command we use for write a query
cmd.CommandType = CommandType.Text;

// It accepts a parameter that contains the command text of the object's selectCommand property.
da = new SqlDataAdapter(cmd);

da.Fill(dt);
```

- **DataRow** class provides functionality to add a new row (new record) into the data table. DataRow object inherits the schema of the data table. Allows you to add values for each data column according to the specified data type.

Using the code below, insert one record into the data table. This record is set as default in the ComboBox.

```csharp
// Create an object for DataRow
DataRow newRow = dt.NewRow();

// Assign a value to Id column
newRow["Id"] = 0;

// Assign value to CurrencyName column
newRow["CurrencyName"] = "--SELECT--";

// Insert a new row in dt with the data at a 0 position
dt.Rows.InsertAt(newRow, 0);
```

- Assign data table data to ComboBox using **ItemsSource** property.
- Set ComboBox **DisplayMemberPath** property — what to show in ComboBox as display text (currency name).
- Set ComboBox **SelectedValuePath** property — what to set as value (Id used as value member).
- Make sure both properties are set with the same DataTable column name.
- After adding **BindCurrency()** method, call it in **MainWindow()** method (called first when the program runs).

```csharp
// The dt is not null and rows count greater than 0
if (dt != null && dt.Rows.Count > 0)
{
    // Assign the datatable data to from currency combobox using ItemSource property.
    cmbFromCurrency.ItemsSource = dt.DefaultView;

    // Assign the datatable data to to currency combobox using ItemSource property.
    cmbToCurrency.ItemsSource = dt.DefaultView;
}
con.Close();

// To display the underlying datasource for cmbFromCurrency
cmbFromCurrency.DisplayMemberPath = "CurrencyName";

// To use as the actual value for the items
cmbFromCurrency.SelectedValuePath = "Id";

// Show default item in combobox
cmbFromCurrency.SelectedValue = 0;

cmbToCurrency.DisplayMemberPath = "CurrencyName";
cmbToCurrency.SelectedValuePath = "Id";
cmbToCurrency.SelectedValue = 0;
```

**Output:** — In ComboBox no currency names are shown because no currency has been added to the database table yet.

### ClearControls

```csharp
// This method is used to clear all the controls input which user entered
private void ClearControls()
{
    try
    {
        // Clear amount textbox text
        txtCurrency.Text = string.Empty;

        // From currency combobox items count greater than 0
        if (cmbFromCurrency.Items.Count > 0)
        {
            // Set from currency combobox selected item hint
            cmbFromCurrency.SelectedIndex = 0;
        }

        // To currency combobox items count greater than 0
        if (cmbToCurrency.Items.Count > 0)
        {
            // Set to currency combobox selected item hint
            cmbToCurrency.SelectedIndex = 0;
        }

        // Clear a label text
        lblCurrency.Content = "";

        // Set focus on amount textbox
        txtCurrency.Focus();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
```

### Number Validation

```csharp
// Allow only integer in TextBox
private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
{
    // Regular Expression to add regex. Add library using System.Text.RegularExpressions;
    Regex regex = new Regex("[^0-9]+");
    e.Handled = regex.IsMatch(e.Text);
}
```

- Creates a method **NumberValidationTextBox()**. Used for Amount TextBox only, which allows the user to enter numbers. Uses Regular Expression.
- Import namespace `using System.Text.RegularExpressions`.
- Import `using System.Windows.Input` namespace (for `TextCompositionEventArgs`, used for input controls e.g. TextBox).

### ClearMaster

```csharp
// Method is used to clear all the input which the user has entered in currency master tab
private void ClearMaster()
{
    try
    {
        txtAmount.Text = string.Empty;
        txtCurrencyName.Text = string.Empty;
        btnSave.Content = "Save";
        GetData();
        CurrencyId = 0;
        BindCurrency();
        txtAmount.Focus();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
```

### Save button click event

```csharp
private void btnSave_Click(object sender, RoutedEventArgs e)
{

}
```

Add a try-catch block. A try-catch block placed around code that could throw an exception. If an exception is thrown, this try-catch block will handle the exception to ensure the application does not cause an unhandled exception, user error, or crash.

```csharp
try
{

}
catch (Exception ex)
{
    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
}
```

Check validation:

- If amount textbox is blank → show "Please enter amount."
- If currency name textbox is blank → show "Please enter currency name."

```csharp
// Check the validation
if (txtAmount.Text == null || txtAmount.Text.Trim() == "")
{
    MessageBox.Show("Please enter amount", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
    txtAmount.Focus();
    return;
}
else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "")
{
    MessageBox.Show("Please enter currency name", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
    txtCurrencyName.Focus();
    return;
}
```

Click on Save button if both textboxes are not blank → show confirmation message "Are you sure you want to save?". Click "Yes" → start save operation. Call **mycon()** for database connection and open connection. `cmd = new SqlCommand()` with insert query. Use **AddWithValue** to add parameters by specifying name and value. **ExecuteNonQuery** is used for executing queries that do not return any data (insert, update, delete).

```csharp
if (MessageBox.Show("Are you sure you want to Save ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
{
    mycon();
    DataTable dt = new DataTable();
    cmd = new SqlCommand("INSERT INTO Currency_Master(Amount, CurrencyName) VALUES(@Amount, @CurrencyName)", con);
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
    cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
    cmd.ExecuteNonQuery();
    con.Close();

    MessageBox.Show("Data saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
}
```

---

### Bind DataGrid

```csharp
// Bind Data in DataGrid View.
public void GetData()
{
    // The method is used for connect with database and open database connection
    mycon();

    // Create DataTable object
    DataTable dt = new DataTable();

    // Write SQL Query for Get data from database table. Query written in double quotes and after comma provide connection
    cmd = new SqlCommand("SELECT * FROM Currency_Master", con);

    // CommandType define Which type of command execute like Text, StoredProcedure, TableDirect.
    cmd.CommandType = CommandType.Text;

    // It accepts a parameter that contains the command text of the object's SelectCommand property.
    da = new SqlDataAdapter(cmd);

    // The DataAdapter serves as a bridge between a DataSet and a data source for retrieving and saving data. The Fill operation then adds the rows to destination DataTable objects in the DataSet
    da.Fill(dt);

    // dt is not null and rows count greater than 0
    if (dt != null && dt.Rows.Count > 0)
    {
        // Assign DataTable data to dgvCurrency using ItemSource property.
        dgvCurrency.ItemsSource = dt.DefaultView;
    }
    else
    {
        dgvCurrency.ItemsSource = null;
    }
    // Database connection Close
    con.Close();
}
```

---

### Edit and Delete Code

Create a DataGrid selected cell changed event to edit and delete.

- Create an object for DataGrid: `DataGrid grd = (DataGrid)sender`.
- **DataRowView** objects expose values as object arrays indexed by either the name or the column's ordinal reference in the underlying table. Access the DataRow presented by the DataRowView using the **Row** property.
- Select the DataRowView to identify the selected row records.
- The Id column is not shown in DataGrid because its `Visibility` property is set to `Hidden`. But it exists in DataGrid.
- Extract the Id from selected DataRowView and assign it to **CurrencyId** variable (used to update records).
- Check `if (grd.SelectedCells[0].Column.DisplayIndex == 0)` to edit records. Get amount and currency name to edit once condition is true.
- Check `if (grd.SelectedCells[0].Column.DisplayIndex == 1)` to delete records. Once condition is true, show confirmation message "Are you sure you want to delete?". If "Yes", delete query fires and deletes record using Id.
- After completing delete, message "Data deleted successfully" is shown.
- **CommandType** can be one of: Text, StoredProcedure, TableDirect. The property CommandText should contain the text of a query that must be run on the server when the value is CommandType.StoredProcedure (CommandText must be the name of a procedure to execute).

```csharp
// DataGrid selected cell changed event
private void dgvCurrency_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
{
    try
    {
        // Create object for DataGrid
        DataGrid grd = (DataGrid)sender;
        // Create object for DataRowView
        DataRowView row_selected = grd.CurrentItem as DataRowView;

        // row_selected is not null
        if (row_selected != null)
        {
            // dgvCurrency items count greater than zero
            if (dgvCurrency.Items.Count > 0)
            {
                if (grd.SelectedCells.Count > 0)
                {
                    // Get selected row Id column value and Set in CurrencyId variable
                    CurrencyId = Int32.Parse(row_selected["Id"].ToString());

                    // DisplayIndex is equal to zero than it is Edit cell
                    if (grd.SelectedCells[0].Column.DisplayIndex == 0)
                    {
                        // Get selected row Amount column value and Set in Amount textbox
                        txtAmount.Text = row_selected["Amount"].ToString();

                        // Get selected row CurrencyName column value and Set in CurrencyName textbox
                        txtCurrencyName.Text = row_selected["CurrencyName"].ToString();

                        // Change save button text Save to Update
                        btnSave.Content = "Update";
                    }

                    // DisplayIndex is equal to one than it is Delete cell
                    if (grd.SelectedCells[0].Column.DisplayIndex == 1)
                    {
                        // Show confirmation dialogue box
                        if (MessageBox.Show("Are you sure you want to delete ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            mycon();
                            DataTable dt = new DataTable();

                            // Execute delete query for delete record from table using Id
                            cmd = new SqlCommand("DELETE FROM Currency_Master WHERE Id = @Id", con);
                            cmd.CommandType = CommandType.Text;

                            // CurrencyId set in @Id parameter and send it in delete statement
                            cmd.Parameters.AddWithValue("@Id", CurrencyId);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Data deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearMaster();
                        }
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
```

---

### Update button code

Click on the edit button to update the amount and currency name in the textbox. Fill the textbox with this value and click the save button. The text changes from Save to Update.

Add the update code in the save button click event. Check the condition whether **CurrencyId** is not equal zero and greater than zero before displaying the confirmation dialogue to update the record. The record will be updated once the above condition is matched, and the update query gets executed.

```csharp
if (CurrencyId != 0 && CurrencyId > 0)
{
    if (MessageBox.Show("Are you sure you want to Update ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
    {
        mycon();
        DataTable dt = new DataTable();
        cmd = new SqlCommand("UPDATE Currency_Master SET Amount = @Amount, CurrencyName = @CurrencyName WHERE Id = @Id", con);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@Id", CurrencyId);
        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
        cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
        cmd.ExecuteNonQuery();
        con.Close();

        MessageBox.Show("Data Updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
```

---

### Cancel button click event

```csharp
// Cancel button click event
private void btnCancel_Click(object sender, RoutedEventArgs e)
{
    try
    {
        ClearMaster();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
```

---

### From currency ComboBox selection changed event

**SelectionChanged** event is issued when the ComboBox changes the currently selected item. If the user chooses the same item as currently selected, the selection is not changed, and therefore this event will not be triggered.

Check the condition if `cmbFromCurrency.SelectedValue` not equal to null and not equal to zero. Set from currency ComboBox selected value in **CurrencyFromId** variable. Execute select command which fetches amount from **Currency_Master** table using Id.

```csharp
// From currency combobox selection changed event for get amount of currency on selection change of currency name
private void cmbFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    try
    {
        // Check condition cmbFromCurrency.SelectedValue not equal to null and not equal to zero
        if (cmbFromCurrency.SelectedValue != null && int.Parse(cmbFromCurrency.SelectedValue.ToString()) != 0 && cmbFromCurrency.SelectedIndex != 0)
        {
            // cmbFromCurrency.SelectedValue set in CurrencyFromId variable
            int CurrencyFromId = int.Parse(cmbFromCurrency.SelectedValue.ToString());

            mycon();
            DataTable dt = new DataTable();

            // Select query for get Amount from database using id
            cmd = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @CurrencyFromId", con);
            cmd.CommandType = CommandType.Text;

            // CurrencyFromId set in @CurrencyFromId parameter and send parameter in our query
            if (CurrencyFromId != null && CurrencyFromId != 0)
            {
                cmd.Parameters.AddWithValue("@CurrencyFromId", CurrencyFromId);
            }
            da = new SqlDataAdapter(cmd);

            // Set the data that the query returns in the data table
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                // Get amount column value from datatable and set amount value in FromAmount variable which is declared globally
                FromAmount = double.Parse(dt.Rows[0]["Amount"].ToString());
            }
            con.Close();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
```

---

### To currency ComboBox selection changed event

```csharp
// To currency combobox selection changed event for get amount of currency on selection change of currency name
private void cmbToCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    try
    {
        // Check condition cmbToCurrency SelectedValue not equal to null and not equal to zero
        if (cmbToCurrency.SelectedValue != null && int.Parse(cmbToCurrency.SelectedValue.ToString()) != 0 && cmbToCurrency.SelectedIndex != 0)
        {
            // cmbToCurrency SelectedValue set in CurrencyToId variable
            int CurrencyToId = int.Parse(cmbToCurrency.SelectedValue.ToString());

            mycon();
            DataTable dt = new DataTable();

            // Select query for get Amount from database using id
            cmd = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @CurrencyToId", con);
            cmd.CommandType = CommandType.Text;

            // CurrencyToId set in @CurrencyToId parameter and send parameter in our query
            if (CurrencyToId != null && CurrencyToId != 0)
            {
                cmd.Parameters.AddWithValue("@CurrencyToId", CurrencyToId);
            }
            da = new SqlDataAdapter(cmd);

            // Set the data that the query returns in the data table
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                // Get amount column value from datatable and set amount value in ToAmount variable which is declared globally
                ToAmount = double.Parse(dt.Rows[0]["Amount"].ToString());
            }
            con.Close();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
```

---

### From and To currency ComboBox preview key down events

The **PreviewKeyDown** event is used to identify which key is pressed on the keyboard. Here Tab and Enter keys are used — if the user presses Tab or Enter key, then the selection changed event executes.

```csharp
// cmbFromCurrency preview key down event
private void cmbFromCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
{
    // If the user press Tab or Enter key then cmbFromCurrency_SelectionChanged event fire
    if (e.Key == Key.Tab || e.SystemKey == Key.Enter)
    {
        cmbFromCurrency_SelectionChanged(sender, null);
    }
}

// cmbToCurrency preview key down event
private void cmbToCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
{
    // If the user press Tab or Enter key then cmbToCurrency_SelectionChanged event fire
    if (e.Key == Key.Tab || e.SystemKey == Key.Enter)
    {
        cmbToCurrency_SelectionChanged(sender, null);
    }
}
```

---

### Calculation of Currency Converter

```csharp
// Convert button click event
private void Convert_Click(object sender, RoutedEventArgs e)
{

}
```

Create a convert button click event. Fires when the convert button is clicked.

- Declare a variable **ConvertedValue** with double datatype. Used to store converted value and shown in the label.
- Check validation: if Amount TextBox is blank → show "please enter amount."
- Check validation: if user does not select any currency from FromCurrency ComboBox → show "Please select currency from."
- Check validation: if user does not select any currency from ToCurrency ComboBox → show "Please select currency to."

```csharp
// Declare ConvertedValue with double data type for store currency converted value
double ConvertedValue;

// Check amount textbox is Null or Blank
if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
{
    // If amount Textbox is Null or Blank show the below message box
    MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
    // After click on OK button set focus on amount textbox
    txtCurrency.Focus();
    return;
}
// Else if currency From is not selected or select default text --SELECT--
else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
{
    // Show the message
    MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

    // Set focus to From ComboBox
    cmbFromCurrency.Focus();
    return;
}
// Else if currency To is not selected or select default text --SELECT--
else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
{
    // Show the message
    MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

    // Set focus to To ComboBox
    cmbToCurrency.Focus();
    return;
}
```

- Check condition: if **from currency** and **to currency** select the same currency name → store amount textbox value in converted value variable. E.g., enter 10, select USD → USD → show "USD 10.000."
- If From and To currency are not the same → else part executes.
- From Currency Value Multiply (`*`) with Amount TextBox Value, then that total Divided (`/`) with To Currency Value → stored in **ConvertedValue** variable.
- Display in Label: Converted **Currency name** with **ConvertedValue**.

```csharp
// If From and To ComboBox selects same value
if (cmbFromCurrency.Text == cmbToCurrency.Text)
{
    // Amount textbox value set in ConvertedValue. double.Parse is used for change datatype from string to double.
    // TextBox text has string and ConvertedValue as double datatype
    ConvertedValue = double.Parse(txtCurrency.Text);

    // Show the label converted currency and converted currency name.
    // ToString("N3") is used to place 000 after the dot(.)
    lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
}
else
{
    // Calculation for currency converter: From currency value multiplied(*) with the amount textbox value and then the total is divided(/) with To currency value.
    ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());

    // Show the label converted currency and converted currency name.
    lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
}
```

- Create a clear button click event.
- Call **ClearControls()** method to clear all controls input which user entered.

```csharp
// Clear Button Click Event
private void Clear_Click(object sender, RoutedEventArgs e)
{
    // ClearControls Method for Clear All Control Value
    ClearControls();
}
```

---

### Final code of MainWindow.xaml.cs

```csharp
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;

// This namespace is used for DataTable
using System.Data;

// This namespace is used for Regular Expression
using System.Text.RegularExpressions;

// This namespace is used for SQL Classes
using System.Data.SqlClient;

// This namespace is used for ConfigurationManager and ConfigurationManager is used to fetch connection string from App.config file.
using System.Configuration;

// The class names declared in one namespace should not conflict with the same class names declared in another.
namespace CurrencyConverter_Database
{
    public partial class MainWindow : Window
    {
        // Create object for SqlConnection
        SqlConnection con = new SqlConnection();

        // Create an object for SqlCommand
        SqlCommand cmd = new SqlCommand();

        // Create object for SqlDataAdapter
        SqlDataAdapter da = new SqlDataAdapter();

        // Declare CurrencyId with int data type and assign value as 0.
        private int CurrencyId = 0;

        // Declare FromAmount with double data type and assign value 0.
        private double FromAmount = 0;

        // Declare ToAmount with double data type and assign value 0.
        private double ToAmount = 0;

        public MainWindow()
        {
            // We drag controls to the form in Visual Studio. Behind the scenes, Visual Studio adds code to the InitializeComponent method
            InitializeComponent();

            // ClearControls method to clear all controls value
            ClearControls();

            // BindCurrency is used for bind currency name with value in ComboBox
            BindCurrency();

            // GetData method is used to bind DataGrid
            GetData();
        }

        public void mycon()
        {
            // Database connection string
            String Conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(Conn);

            // Open the connection
            con.Open();
        }

        // Bind the currency name to From currency and To currency ComboBox.
        private void BindCurrency()
        {
            mycon();

            // Create Object for DataTable
            DataTable dt = new DataTable();

            // Write SQL Query for Get Data from Database Table.
            cmd = new SqlCommand("select Id, CurrencyName from Currency_Master", con);

            // CommandType Define Which type of Command we Use for Write a Query
            cmd.CommandType = CommandType.Text;

            // It accepts a parameter that contains the command text of the object's SelectCommand property.
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            // Create a DataRow object
            DataRow newRow = dt.NewRow();

            // Assign a value to Id column
            newRow["Id"] = 0;

            // Assign value to CurrencyName column
            newRow["CurrencyName"] = "--SELECT--";

            // Insert a new row in dt with a data at 0 position
            dt.Rows.InsertAt(newRow, 0);

            // dt is not null and rows count greater than 0
            if (dt != null && dt.Rows.Count > 0)
            {
                // Assign data table data to From currency ComboBox using item source property.
                cmbFromCurrency.ItemsSource = dt.DefaultView;

                // Assign data table data to To currency ComboBox using item source property.
                cmbToCurrency.ItemsSource = dt.DefaultView;
            }
            con.Close();

            // To display the underlying datasource for cmbFromCurrency
            cmbFromCurrency.DisplayMemberPath = "CurrencyName";

            // To use as the actual value for the items
            cmbFromCurrency.SelectedValuePath = "Id";

            // Show default item in ComboBox
            cmbFromCurrency.SelectedValue = 0;

            cmbToCurrency.DisplayMemberPath = "CurrencyName";
            cmbToCurrency.SelectedValuePath = "Id";
            cmbToCurrency.SelectedValue = 0;

        }

        #region Extra Events
        // Method is used to clear all the input which user entered
        private void ClearControls()
        {
            try
            {
                txtCurrency.Text = string.Empty;
                if (cmbFromCurrency.Items.Count > 0)
                    cmbFromCurrency.SelectedIndex = 0;
                if (cmbToCurrency.Items.Count > 0)
                    cmbToCurrency.SelectedIndex = 0;
                lblCurrency.Content = "";
                txtCurrency.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Allow only integer in the TextBox
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Regular expression to add Regex. Add library using System.Text.RegularExpressions;
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

        #region Currency Converter Tab Button Click Event

        // Assign the click event to convert button
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Declare ConvertedValue variable with double data type to store converted currency value
                double ConvertedValue;

                // Check amount textbox is Null or Blank
                if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
                {
                    // If amount Textbox is Null or Blank then show dialog box
                    MessageBox.Show("Please enter currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Set focus to amount textbox
                    txtCurrency.Focus();
                    return;
                }
                // If From currency selected value is null or default text as --SELECT--
                else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
                {
                    // Open Dialog box
                    MessageBox.Show("Please select from currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    cmbFromCurrency.Focus();
                    return;
                }
                else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select to currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    cmbToCurrency.Focus();
                    return;
                }

                if (cmbFromCurrency.SelectedValue == cmbToCurrency.SelectedValue)   // Check if From and To ComboBox Selected Same Value
                {
                    // Amount textbox value is set in ConvertedValue. The double.parse is used to change Datatype from String To Double.
                    // TextBox text has string, and ConvertedValue is double.
                    ConvertedValue = double.Parse(txtCurrency.Text);

                    // Show the label converted currency name and converted currency amount. The ToString("N3") is used for Placing 000 after the dot(.).
                    lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
                }
                else
                {
                    if (FromAmount != null && FromAmount != 0 && ToAmount != null && ToAmount != 0)
                    {
                        // Calculation for currency converter: From currency value Multiplied(*) with amount textbox value and then that total is divided(/) with To currency value.
                        ConvertedValue = FromAmount * double.Parse(txtCurrency.Text) / ToAmount;

                        // Show the label converted currency name and converted currency amount.
                        lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Assign the clear button click event
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // ClearControls method used to clear all the control values which user entered
            ClearControls();
        }
        #endregion

        #region Currency Master Button Click Event
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAmount.Text == null || txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter amount", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtAmount.Focus();
                    return;
                }
                else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter currency name", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCurrencyName.Focus();
                    return;
                }
                else
                {
                    // Edit time and set that record Id in CurrencyId variable.
                    // Code to Update. If CurrencyId greater than zero than it is go for update.
                    if (CurrencyId > 0)
                    {
                        // Show the confirmation message
                        if (MessageBox.Show("Are you sure you want to update ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            mycon();
                            DataTable dt = new DataTable();

                            // Update Query Record update using Id
                            cmd = new SqlCommand("UPDATE Currency_Master SET Amount = @Amount, CurrencyName = @CurrencyName WHERE Id = @Id", con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Id", CurrencyId);
                            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Data updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    // Code to Save
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to save ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            mycon();
                            // Insert query to Save data in the table
                            cmd = new SqlCommand("INSERT INTO Currency_Master(Amount, CurrencyName) VALUES(@Amount, @CurrencyName)", con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Data saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    ClearMaster();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Assign the cancel button click event
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        // Bind data to the DataGrid view.
        public void GetData()
        {
            // Method is used for connect with database and open database connection
            mycon();

            // Create DataTable object
            DataTable dt = new DataTable();

            // Write SQL query to get the data from database table. Query written in double quotes and after comma provide connection.
            cmd = new SqlCommand("SELECT * FROM Currency_Master", con);

            // CommandType define which type of command will execute like Text, StoredProcedure, TableDirect.
            cmd.CommandType = CommandType.Text;

            // It accepts a parameter that contains the command text of the object's SelectCommand property.
            da = new SqlDataAdapter(cmd);

            // The DataAdapter serves as a bridge between a DataSet and a data source for retrieving and saving data.
            // The fill operation then adds the rows to destination DataTable objects in the DataSet
            da.Fill(dt);

            // dt is not null and rows count greater than 0
            if (dt != null && dt.Rows.Count > 0)
                // Assign DataTable data to dgvCurrency using item source property.
                dgvCurrency.ItemsSource = dt.DefaultView;
            else
                dgvCurrency.ItemsSource = null;

            // Database connection close
            con.Close();
        }

        // Method is used to clear all the input which user entered in currency master tab
        private void ClearMaster()
        {
            try
            {
                txtAmount.Text = string.Empty;
                txtCurrencyName.Text = string.Empty;
                btnSave.Content = "Save";
                GetData();
                CurrencyId = 0;
                BindCurrency();
                txtAmount.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // DataGrid selected cell changed event
        private void dgvCurrency_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                // Create object for DataGrid
                DataGrid grd = (DataGrid)sender;

                // Create an object for DataRowView
                DataRowView row_selected = grd.CurrentItem as DataRowView;

                // If row_selected is not null
                if (row_selected != null)
                {
                    // dgvCurrency items count greater than zero
                    if (dgvCurrency.Items.Count > 0)
                    {
                        if (grd.SelectedCells.Count > 0)
                        {
                            // Get selected row id column value and set it to the CurrencyId variable
                            CurrencyId = Int32.Parse(row_selected["Id"].ToString());

                            // DisplayIndex is equal to zero in the Edited cell
                            if (grd.SelectedCells[0].Column.DisplayIndex == 0)
                            {
                                // Get selected row amount column value and set to amount textbox
                                txtAmount.Text = row_selected["Amount"].ToString();

                                // Get selected row CurrencyName column value and set it to CurrencyName textbox
                                txtCurrencyName.Text = row_selected["CurrencyName"].ToString();
                                btnSave.Content = "Update";     // Change save button text Save to Update
                            }

                            // DisplayIndex is equal to one in the deleted cell
                            if (grd.SelectedCells[0].Column.DisplayIndex == 1)
                            {
                                // Show confirmation dialog box
                                if (MessageBox.Show("Are you sure you want to delete ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    mycon();
                                    DataTable dt = new DataTable();

                                    // Execute delete query to delete record from table using Id
                                    cmd = new SqlCommand("DELETE FROM Currency_Master WHERE Id = @Id", con);
                                    cmd.CommandType = CommandType.Text;

                                    // CurrencyId set in @Id parameter and send it in delete statement
                                    cmd.Parameters.AddWithValue("@Id", CurrencyId);
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    MessageBox.Show("Data deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                    ClearMaster();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region Selection Changed Events

        // From currency ComboBox selection changed event to get the amount of currency on selection change of currency name
        private void cmbFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // If cmbFromCurrency selected value is not equal to null and not equal to zero
                if (cmbFromCurrency.SelectedValue != null && int.Parse(cmbFromCurrency.SelectedValue.ToString()) != 0 && cmbFromCurrency.SelectedIndex != 0)
                {
                    // cmbFromCurrency selectedvalue set in CurrencyFromId variable
                    int CurrencyFromId = int.Parse(cmbFromCurrency.SelectedValue.ToString());

                    mycon();
                    DataTable dt = new DataTable();

                    // Select query to get amount from database using id
                    cmd = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @CurrencyFromId", con);
                    cmd.CommandType = CommandType.Text;

                    if (CurrencyFromId != null && CurrencyFromId != 0)
                        // CurrencyFromId set in @CurrencyFromId parameter and send parameter in our query
                        cmd.Parameters.AddWithValue("@CurrencyFromId", CurrencyFromId);

                    da = new SqlDataAdapter(cmd);

                    // Set the data that the query returns in the data table
                    da.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                        // Get amount column value from datatable and set amount value in FromAmount variable which is declared globally
                        FromAmount = double.Parse(dt.Rows[0]["Amount"].ToString());

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // To currency ComboBox selection changed event to get the amount of currency on selection change of currency name
        private void cmbToCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // If cmbToCurrency selectedvalue is not equal to null and not equal to zero
                if (cmbToCurrency.SelectedValue != null && int.Parse(cmbToCurrency.SelectedValue.ToString()) != 0 && cmbToCurrency.SelectedIndex != 0)
                {
                    // cmbToCurrency selectedvalue is set to CurrencyToId variable
                    int CurrencyToId = int.Parse(cmbToCurrency.SelectedValue.ToString());

                    mycon();

                    DataTable dt = new DataTable();
                    // Select query for get Amount from database using id
                    cmd = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @CurrencyToId", con);
                    cmd.CommandType = CommandType.Text;

                    if (CurrencyToId != null && CurrencyToId != 0)
                        // CurrencyToId set in @CurrencyToId parameter and send parameter in our query
                        cmd.Parameters.AddWithValue("@CurrencyToId", CurrencyToId);

                    da = new SqlDataAdapter(cmd);

                    // Set the data that the query returns in the data table
                    da.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                        // Get amount column value from datatable and set amount value in ToAmount variable which is declared globally
                        ToAmount = double.Parse(dt.Rows[0]["Amount"].ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Preview Key Down Events
        // cmbFromCurrency preview key down event
        private void cmbFromCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // If the user press Tab or Enter key then cmbFromCurrency_SelectionChanged event is executed
            if (e.Key == Key.Tab || e.SystemKey == Key.Enter)
            {
                cmbFromCurrency_SelectionChanged(sender, null);
            }
        }

        // cmbToCurrency preview key down event
        private void cmbToCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // If the user press Tab or Enter key then cmbToCurrency_SelectionChanged event is executed
            if (e.Key == Key.Tab || e.SystemKey == Key.Enter)
            {
                cmbToCurrency_SelectionChanged(sender, null);
            }
        }
        #endregion
    }
}
```

---

## Output

- **Insert currency amount and currency name:** ![](https://tutorials.eu/wp-content/uploads/2020/08/Dss_Insert-1.gif)
- **Edit and update record:** ![](https://tutorials.eu/wp-content/uploads/2020/08/Dss_Edit_Update.gif)
- **Delete record:** ![](https://tutorials.eu/wp-content/uploads/2020/08/Dss_Delete.gif)
- **Convert currency From and To currency same:** ![](https://tutorials.eu/wp-content/uploads/2020/08/Dss_CS.gif)
- **From and To currency is different:** ![](https://tutorials.eu/wp-content/uploads/2020/08/Dss_CD.gif)

---

## Summary

In this article, you learned how to create a **Currency Converter** in **WPF** using **C#**. Here, you have used the database to store a currency name and currency amount and perform CRUD operations on it.

---

## Notes

- Article uses **FontAwesome.WPF** NuGet package for the exchange icon (`fa:ImageAwesome`). Latest stable version: `4.7.0.9` (.NET Framework).
- Images referenced: `Images\money.png` (app icon), `Images\Logo.png` (display image), `Images\edit-button.png`, `Images\delete-button.png` (DataGrid action icons).
- Database: SQL Server LocalDB (`.mdf` file), table `Currency_Master` with columns `Id` (INT IDENTITY PK), `Amount` (FLOAT), `CurrencyName` (NVARCHAR(50)).
- Connection string stored in `App.config` under `<connectionStrings>`, referenced via `ConfigurationManager.ConnectionStrings["ConnectionString"]`.
- CRUD operations: Insert (`btnSave` when `CurrencyId == 0`), Update (`btnSave` when `CurrencyId > 0`), Delete (DataGrid delete-cell click), Read (BindCurrency for ComboBoxes, GetData for DataGrid).
- Conversion formula: `ConvertedValue = FromAmount * amount / ToAmount` when From ≠ To; same-value case just echoes the entered amount.

---

*Source: [tutorials.eu — Build a Currency Converter Application Using WPF in C# with Database](https://tutorials.eu/build-a-currency-converter-application-using-wpf-in-c-with-database/)*
