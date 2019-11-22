//饼状图
function PieChart(data, containerId) {
  var pie_option = {
     chart:{
           plotBackgroundColor: null,
           plotBorderWidth: null,
           plotShadow: false,
           marginLeft: 1 // like content_left
       },
      credits: { enabled: false },//不显示LOGO 
      exporting: { enabled: false },
       title:{text:null,},
       tooltip:{
        pointFormat: '{point.percentage:.1f}%'
    },

    //colors:['#fee271','#f7849b','#0e5383','#ff9932','#7bccce','#0085f7',],//自定义颜色
    plotOptions:{
      pie: {
         allowPointSelect: true,
         cursor: 'pointer',
         dataLabels: {
            enabled: false,
         },
        showInLegend: true,
      },
   },
   legend: {//控制图例显示位置
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'right',
            symbolHeight: 24,
            symbolWidth: 24,
            symbolRadius: 12,
            symbol:"emptyCircle",
            itemStyle:{
                 fontSize: '16px', color: '#3E576F',fontWeight:"normal",left:"50px",
            },
            itemMarginBottom:10,
            symbolPadding:5,
            labelFormatter: function () {
                                return this.name + ' ：'+this.y+"%";
                        }
            
     },
    series:[{
      type: 'pie',
      name: ' </br>',
        data: data
      //      [{ name: '公司注册', color: '#fee271', y: 65 },  
      //        {name:'公司起名',color:'#f7849b',y:35},  
      //]
   }],  
    }
    $('#' + containerId).highcharts(pie_option);
}
//折线图
function DisassemblyChart(payData, growthRateData, categoriesData, containerId) {    
    var column_potion = {
        credits: { enabled: false },//不显示LOGO 
        exporting: { enabled: false },
        chart: {
            marginLeft: 80 // like content_left
        },
        plotOptions: {
            column: {
                borderWidth: 0,
                pointWidth: 10, //柱子宽度
                dataLabels: {
                    style: {
                        fontSize: 11
                    },

                    enabled: false
                }
            }
        },

        xAxis: {
            categories: categoriesData//['05-01', '05-02', '05-03', '05-04', '05-05', '05-06', '05-07'],  //x轴数据
        },
        title: {
            text: null,
        },
        legend: {
            verticalAlign: 'top', //垂直方向位置
            x: 0, //距离x轴的距离
            y: 0,//距离Y轴的距离
            align: 'center',
        },
        yAxis: [{
            lineWidth: 0,
            title: { text: null },
            tickInterval: 550,
            gridLineWidth: 0
        }, {
            lineWidth: 0,
            opposite: true,
            gridLineWidth: 0,
            title: { text: '' },
            labels: {
                format: '{value} %',
                style: {
                    color: '#4572A7'
                }
            },

        }],
        series: [{
            name: '实际支付金额',
            color: '#2181f7',
            type: 'column',
            data: payData//[550, 1100, 106.4, 129.2, 144.0, 176.0, 135.6,]
        }, {
            name: '上周同比增长率',
            data: growthRateData,//[23.0, 1.0, 800.6, 15.5, 16.4, -10.1, 10.6,],
            yAxis: 1,
            tooltip: {
                valueSuffix: ' %'
            },
            color: '#ff8533',
            marker: {
                lineWidth: 2,
                lineColor: Highcharts.getOptions().colors[3],
                fillColor: 'white'
            }
        }]
    }
    $('#' + containerId).highcharts(column_potion);
}