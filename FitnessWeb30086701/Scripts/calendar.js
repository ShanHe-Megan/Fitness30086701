
$(function () {
    $('#datetimepicker').datetimepicker({
        format: 'YYYY-MM-DD',
        locale: moment.locale('zh-cn')
    });
    $('#datetimepicker2').datetimepicker({
        format: 'YYYY-MM-DD hh:mm',
        locale: moment.locale('zh-cn')
    });
});

$('#datetimepicker').datetimepicker({
    showClose: true,	//是否显示关闭 按钮
	viewMode: 'days',//天数模块展示，months则为以月展示
    daysOfWeekDisabled: false,//星期几 禁止选择,参数 [num],多个逗号隔开
    calendarWeeks: false,	//显示 周 是 今年第几周
    toolbarPlacement: 'default', //工具摆放的位置，top 则为上，默认为底
    showTodayButton: false,	//是否工具栏 显示 直达今天天数的 按钮，默认false
    showClear: false, //是否 工具栏显示  清空 输入框  的按钮。默认false
});