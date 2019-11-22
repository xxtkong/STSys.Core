//咨询转换率
function CosultRate(timeDate, preData, curData, containerId) {
    var consultation_left_option = {
        title: { text: null, subtext: null },
        tooltip: { trigger: 'axis' },
        calculable: true,
        xAxis: [
            {
                type: 'category',
                boundaryGap: false,
                splitLine: { show: false },//去除网格线
                data: timeDate,//['03-01','03-02','03-03','03-04','03-05','03-06','03-07','03-08','03-09','03-10','03-10','03-12','03-13','03-14','03-15','03-15','03-17','03-18','03-19','03-20','03-21','03-22','03-23','03-24','03-25','03-26','03-26','03-26','03-26','03-26','03-26',],
                axisLine: { show: false },
                axisTick: { show: false },
                axisLabel: { interval: 5 },//如果是周统计 注释此项

            }
        ],
        yAxis: [
            {
                type: 'value',
                scale: true,
                splitLine: { show: false },//去除网格线
                axisTick: { show: false },
                axisLine: { show: false },
                axisLabel: {
                    show: true,
                    interval: 'auto',
                    formatter: '{value} %'
                },
            }
        ],
        series: [
            {
                name: '上周',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        color: "#2181f7"
                    }
                },
                data: preData//[10, 30, 0, 0, 0, 10, 40, 10, 30, 10, 12, 20, 12, 12, 0, 0, 17, 10,12, 0, 0, 17, 7, 0, 0, 17, 9, 0, 0, 17, 9,]
            },
            {
                name: '本周',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        color: "#edf3fd",
                        areaStyle: { type: 'default' }
                    }
                },
                data: curData//[30, 50, 0, 12, 0, 0, 17, 15, 12, 15, 10, 17, 12, 8, 12, 0, 0, 17, 10, 12, 0, 0, 17, 9,0, 0, 17, 9, 0, 0, 17, 9,]
            },

        ]
    };
    var consultation_left = echarts.init(document.getElementById(containerId)).setOption(consultation_left_option);
}
//客单价
function UnitPrice(timeData,preData,curData,containerId) {
    var consultation_right_option = {
        title: { text: null, subtext: null },
        tooltip: { trigger: 'axis' },
        calculable: true,
        xAxis: [
            {
                type: 'category',
                boundaryGap: false,
                splitLine: { show: false },//去除网格线
                data: timeData,//['03-01', '03-02', '03-03', '03-04', '03-05', '03-06', '03-07', '03-08', '03-09', '03-10', '03-10', '03-12', '03-13', '03-14', '03-15', '03-15', '03-17', '03-18', '03-19', '03-20', '03-21', '03-22', '03-23', '03-24', '03-25', '03-26', '03-26', '03-26', '03-26', '03-26', '03-26',],
                axisLine: { show: false },
                axisTick: { show: false },
                axisLabel: { interval: 5 },

            }
        ],
        yAxis: [
            {
                type: 'value',
                scale: true,
                splitLine: { show: false },//去除网格线
                axisTick: { show: false },
                axisLine: { show: false },
            }
        ],
        series: [
            {
                name: '上周',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        color: "#2181f7"
                    }
                },
                data: preData//[10, 30, 0, 0, 0, 10, 40, 10, 30, 10, 12, 20, 12, 12, 0, 0, 17, 10, 12, 0, 0, 17, 7, 0, 0, 17, 9, 0, 0, 17, 9,]
            },
            {
                name: '本周',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        color: "#edf3fd",
                        areaStyle: { type: 'default' }
                    }
                },
                data: curData//[30, 50, 0, 12, 0, 0, 17, 15, 12, 15, 10, 17, 12, 8000, 12, 0, 0, 17, 10, 12, 0, 0, 17, 9, 0, 0, 17, 9, 0, 0, 17, 9,]
            },

        ]
    };

    var consultation_right = echarts.init(document.getElementById(containerId)).setOption(consultation_right_option);
}