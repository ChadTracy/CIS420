/*
@license
dhtmlxScheduler.Net v.3.3.23 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){e._get_url_nav=function(){for(var e={},t=(document.location.hash||"").replace("#","").split(","),a=0;a<t.length;a++){var n=t[a].split("=");2==n.length&&(e[n[0]]=n[1])}return e},e.attachEvent("onTemplatesReady",function(){function t(t){r=t,e.getEvent(t)&&e.showEvent(t)}var a=!0,n=e.date.str_to_date("%Y-%m-%d"),i=e.date.date_to_str("%Y-%m-%d"),r=e._get_url_nav().event||null;e.attachEvent("onAfterEventDisplay",function(e){return r=null,!0}),e.attachEvent("onBeforeViewChange",function(o,d,l,s){
if(a){a=!1;var _=e._get_url_nav();if(_.event)try{if(e.getEvent(_.event))return t(_.event),!1;var c=e.attachEvent("onXLE",function(){t(_.event),e.detachEvent(c)})}catch(h){}if(_.date||_.mode){try{this.setCurrentView(_.date?n(_.date):null,_.mode||null)}catch(h){this.setCurrentView(_.date?n(_.date):null,l)}return!1}}var u=["date="+i(s||d),"mode="+(l||o)];r&&u.push("event="+r);var p="#"+u.join(",");return document.location.hash=p,!0})})});