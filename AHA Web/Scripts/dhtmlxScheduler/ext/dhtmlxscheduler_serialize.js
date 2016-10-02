/*
@license
dhtmlxScheduler.Net v.3.3.23 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){e._get_serializable_data=function(){var e={};for(var t in this._events){var a=this._events[t];-1==a.id.toString().indexOf("#")&&(e[a.id]=a)}return e},e.data_attributes=function(){var t=[],a=e.templates.xml_format,n=this._get_serializable_data();for(var i in n){var r=n[i];for(var d in r)"_"!=d.substr(0,1)&&t.push([d,"start_date"==d||"end_date"==d?a:null]);break}return t},e.toXML=function(e){var t=[],a=this.data_attributes(),n=this._get_serializable_data();for(var i in n){
var r=n[i];t.push("<event>");for(var d=0;d<a.length;d++)t.push("<"+a[d][0]+"><![CDATA["+(a[d][1]?a[d][1](r[a[d][0]]):r[a[d][0]])+"]]></"+a[d][0]+">");t.push("</event>")}return(e||"")+"<data>"+t.join("\n")+"</data>"},e._serialize_json_value=function(e){return null===e||"boolean"==typeof e?e=""+e:(e||0===e||(e=""),e='"'+e.toString().replace(/\n/g,"").replace(/\\/g,"\\\\").replace(/\"/g,'\\"')+'"'),e},e.toJSON=function(){var e=[],t="",a=this.data_attributes(),n=this._get_serializable_data();for(var i in n){
for(var r=n[i],d=[],o=0;o<a.length;o++)t=a[o][1]?a[o][1](r[a[o][0]]):r[a[o][0]],d.push(' "'+a[o][0]+'": '+this._serialize_json_value(t));e.push("{"+d.join(",")+"}")}return"["+e.join(",\n")+"]"},e.toICal=function(t){var a="BEGIN:VCALENDAR\nVERSION:2.0\nPRODID:-//dhtmlXScheduler//NONSGML v2.2//EN\nDESCRIPTION:",n="END:VCALENDAR",i=e.date.date_to_str("%Y%m%dT%H%i%s"),r=e.date.date_to_str("%Y%m%d"),d=[],o=this._get_serializable_data();for(var l in o){var s=o[l];d.push("BEGIN:VEVENT"),d.push(s._timed&&(s.start_date.getHours()||s.start_date.getMinutes())?"DTSTART:"+i(s.start_date):"DTSTART:"+r(s.start_date)),
d.push(s._timed&&(s.end_date.getHours()||s.end_date.getMinutes())?"DTEND:"+i(s.end_date):"DTEND:"+r(s.end_date)),d.push("SUMMARY:"+s.text),d.push("END:VEVENT")}return a+(t||"")+"\n"+d.join("\n")+"\n"+n}});