<ApexChart TItem="XyItem"
           Title="@Heading"
           Height="@Height"
           Options="@_chartOptions">

    @if (DataSet != null)
    {
        @foreach (var item in DataSet.OrderBy(x => x.Data.Name))
        {
            <ApexPointSeries TItem="XyItem"
                     Items="@item.Data.XY"
                     Name="@($"{item.Data.DisplayName} ({item.Data.Aggregation})")"
                     SeriesType="@(item.ChartType == ChartTypeEnum.Line ? SeriesType.Line : SeriesType.Bar)"
                     YValue = "@(e => e.Value)"
                     XValue="@(e => DateTime.SpecifyKind(e.Date,DateTimeKind.Utc).ToString(Global.DateTimeFormatXyStatResponse))"
                     Color="@item.ChartColor"
                     DataPointMutator="x => SetCustomData(item.Data,x)" />
        }
    }
</ApexChart>
