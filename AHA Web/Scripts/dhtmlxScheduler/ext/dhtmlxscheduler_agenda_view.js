/*
@license
dhtmlxScheduler.Net v.3.3.23 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){e.date.add_agenda=function(t){return e.date.add(t,1,"year")},e.templates.agenda_time=function(t,a,i){return i._timed?this.day_date(i.start_date,i.end_date,i)+" "+this.event_date(t):e.templates.day_date(t)+" &ndash; "+e.templates.day_date(a)},e.templates.agenda_text=function(e,t,a){return a.text},e.templates.agenda_date=function(){return""},e.date.agenda_start=function(){return e.date.date_part(e._currentDate())},e.attachEvent("onTemplatesReady",function(){function t(t){
if(t){var a=e.locale.labels;e._els.dhx_cal_header[0].innerHTML="<div class='dhx_agenda_line'><div>"+a.date+"</div><span style='padding-left:25px'>"+a.description+"</span></div>",e._table_view=!0,e.set_sizes()}}function a(){var t=(e._date,e.get_visible_events());t.sort(function(e,t){return e.start_date>t.start_date?1:-1});for(var a="<div class='dhx_agenda_area'>",i=0;i<t.length;i++){var n=t[i],l=n.color?"background:"+n.color+";":"",r=n.textColor?"color:"+n.textColor+";":"",o=e.templates.event_class(n.start_date,n.end_date,n);

a+="<div class='dhx_agenda_line"+(o?" "+o:"")+"' event_id='"+n.id+"' style='"+r+l+(n._text_style||"")+"'><div class='dhx_agenda_event_time'>"+e.templates.agenda_time(n.start_date,n.end_date,n)+"</div>",a+="<div class='dhx_event_icon icon_details'>&nbsp</div>",a+="<span>"+e.templates.agenda_text(n.start_date,n.end_date,n)+"</span></div>"}a+="<div class='dhx_v_border'></div></div>",e._els.dhx_cal_data[0].innerHTML=a,e._els.dhx_cal_data[0].childNodes[0].scrollTop=e._agendaScrollTop||0;var d=e._els.dhx_cal_data[0].childNodes[0],s=d.childNodes[d.childNodes.length-1];

s.style.height=d.offsetHeight<e._els.dhx_cal_data[0].offsetHeight?"100%":d.offsetHeight+"px";var _=e._els.dhx_cal_data[0].firstChild.childNodes;e._els.dhx_cal_date[0].innerHTML=e.templates.agenda_date(e._min_date,e._max_date,e._mode),e._rendered=[];for(var i=0;i<_.length-1;i++)e._rendered[i]=_[i]}var i=e.dblclick_dhx_cal_data;e.dblclick_dhx_cal_data=function(){if("agenda"==this._mode)!this.config.readonly&&this.config.dblclick_create&&this.addEventNow();else if(i)return i.apply(this,arguments)},e.attachEvent("onSchedulerResize",function(){
return"agenda"==this._mode?(this.agenda_view(!0),!1):!0});var n=e.render_data;e.render_data=function(e){return"agenda"!=this._mode?n.apply(this,arguments):void a()};var l=e.render_view_data;e.render_view_data=function(){return"agenda"==this._mode&&(e._agendaScrollTop=e._els.dhx_cal_data[0].childNodes[0].scrollTop,e._els.dhx_cal_data[0].childNodes[0].scrollTop=0),l.apply(this,arguments)},e.agenda_view=function(i){e._min_date=e.config.agenda_start||e.date.agenda_start(e._date),e._max_date=e.config.agenda_end||e.date.add_agenda(e._min_date,1),
e._table_view=!0,t(i),i&&a()}})});