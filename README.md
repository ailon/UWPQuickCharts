# UWP QuickCharts

UWP QuickCharts is a simple charting library for Universal Windows Platform (XAML). It is a port of [amCharts QuickCharts for WPF, Silverlight and Windows Phone](https://github.com/ailon/amCharts-Quick-Charts).

## Features

- 4 chart types: Line, Area and Column (via SerialChart), and Pie
- Interactive value markers and tooltips
- Data binding support to enable automatic real-time updates
- Automatic adjustments based on control size: showing/hiding of axes, recalculaiton of tick marks and grid lines

## Usage

UWP QuickCharts is available [on Nuget](https://www.nuget.org/packages/UWPQuickCharts/):

`PM> Install-Package UWPQuickCharts`

To add charts to your XAML page add a using statement for `Ailon.QuickCharts` namespace:

`xmlns:qc="using:Ailon.QuickCharts"`

Line, Area and Column charts are handled by SerialChart control like this:

    <qc:SerialChart DataSource="{Binding Data}" CategoryValueMemberPath="XAxisData">
        <qc:SerialChart.Graphs>
            <qc:AreaGraph Title="Sample data 1" ValueMemberPath="SampleData1" />
            <qc:LineGraph Title="Sample data 2" ValueMemberPath="SampleData2" />
            <qc:ColumnGraph Title="Sample data 3" ValueMemberPath="SampleData3" />
        </qc:SerialChart.Graphs>
    </qc:SerialChart>

To add a Pie chart use PieChart control:

    <qc:PieChart DataSource="{Binding Data}" TitleMemberPath="Name" ValueMemberPath="Value" />
    
Refer to included DemoApp project for more examples on how to use and customize the controls.

