# UWP QuickCharts

UWP QuickCharts is a simple charting library for Universal Windows Platform (XAML). It is a port of [amCharts QuickCharts for WPF, Silverlight and Windows Phone](https://github.com/ailon/amCharts-Quick-Charts).

## Features

- 4 chart types: Line, Area and Column (via SerialChart), and Pie
- Interactive value markers and tooltips
- Data binding support to enable automatic real-time updates
- Automatic adjustments based on control size: showing/hiding of axes, recalculation of tick marks and grid lines

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

## Known issues

UWP QuickCharts is a crude port from the WPF/Silverlight/WP project developed in 2010 which in itself is based on now defunct amCharts WPF/Silverlight charts developed around 2008. (btw, the "real" [amCharts JavaScript charts and maps](https://www.amcharts.com/) are healthier than ever and are arguably the best charting controls for your web projects).

No code was modified from the 2010 version (except for namespace changes) unless it didn't work. So, obviously it doesn't adhere to the latest and greatest practices and doesn't use any APIs and techniques that were added in recent years. There's no doubt that the code can be substantially improved. Having said that, the controls are fully functional (few quirks notwithstanding) and can be used to enhance any UWP application with charting functionality.

Some known quirks:

- when charts are resized AND data is updated sometimes data labels may disappear
- tooltips in serial chart may not move along with mouse (users have to move mouse out of chart and back)

## Future plans and roadmap

The ultimate goal would be to add QuickCharts to [UWP Community Toolkit](http://www.uwpcommunitytoolkit.com) provided its stakeholders see the value. However, realistically, I realize that I won't be able to commit the time needed to adhere to all the ceremonies and changes required to meet [UWP Community Toolkit standards](https://github.com/Microsoft/UWPCommunityToolkit/blob/master/contributing.md). So if you are up to the task, please, get in touch and lead the way!

## License

UWP QuickCharts is released under the MIT license.

## Get in touch

The controls are developed by Alan Mendelevich. Contact me on Twitter at [@ailon](https://twitter.com/ailon) to discuss.
