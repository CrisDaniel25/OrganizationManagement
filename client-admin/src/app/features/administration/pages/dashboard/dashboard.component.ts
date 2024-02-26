import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseChartDirective } from 'ng2-charts';
import DataLabelsPlugin from 'chartjs-plugin-datalabels';
import { ChartConfiguration, ChartData, ChartType, ChartOptions } from 'chart.js';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;

  barChartData: ChartData<'bar'> = {
    labels: ['2006', '2007', '2008', '2009', '2010', '2011', '2012'],
    datasets: [
      {
        data: [65, 59, 80, 81, 56, 55, 40],
        label: 'Total',
        backgroundColor: 'rgba(201, 203, 207, 0.2)',
        hoverBackgroundColor: 'rgba(201, 203, 207, 0.2)',
        borderColor: 'rgba(201, 203, 207, 0.2)'
      },
      {
        data: [28, 48, 40, 19, 86, 27, 90],
        label: 'Closed',
        backgroundColor: 'rgba(75, 192, 192, 0.2)',
        hoverBackgroundColor: 'rgba(75, 192, 192, 0.2)',
        borderColor: 'rgba(75, 192, 192, 0.2)'
      },
      {
        data: [28, 48, 0, 1, 86, 27, 90],
        label: 'Open',
        backgroundColor: 'rgba(255, 159, 64, 0.2)',
        hoverBackgroundColor: 'rgba(255, 159, 64, 0.2)',
        borderColor: 'rgba(255, 159, 64, 0.2)'
      },
      {
        data: [8, 48, 40, 19, 86, 27, 90],
        label: 'Overdue',
        backgroundColor: 'rgba(255, 99, 132, 0.2)',
        hoverBackgroundColor: 'rgba(255, 99, 132, 0.2)',
        borderColor: 'rgba(255, 99, 132, 0.2)'
      },
    ]
  };

  barChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    /* We use these empty structures as placeholders for dynamic theming. */
    scales: {
      x: {},
      y: {}
    },
    plugins: {
      legend: {
        display: true,
      },
      datalabels: {
        anchor: 'end',
        align: 'end'
      }
    }
  };
  barChartType: ChartType = 'bar';
  barChartPlugins = [
    DataLabelsPlugin
  ];


  // Pie
  public pieChartOptions: ChartOptions<'pie'> = {
    responsive: false,
  };
  public pieChartLabels = [['Download', 'Sales'], ['In', 'Store', 'Sales'], 'Mail Sales'];
  public pieChartDatasets = [{
    data: [300, 500, 100]
  }];
  public pieChartLegend = true;
  public pieChartPlugins = [];

  constructor() { }

  ngOnInit(): void { }
}