/*
@license
dhtmlxScheduler.Net v.3.3.23 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){e._temp_key_scope=function(){function t(e){e=e||window.event,d.x=e.clientX,d.y=e.clientY}function a(){for(var t=document.elementFromPoint(d.x,d.y);t&&t!=e._obj;)t=t.parentNode;return!(t!=e._obj)}function n(e){delete e.rec_type,delete e.rec_pattern,delete e.event_pid,delete e.event_length}e.config.key_nav=!0;var i,r,l=null,d={};document.body?dhtmlxEvent(document.body,"mousemove",t):dhtmlxEvent(window,"load",function(){dhtmlxEvent(document.body,"mousemove",t)}),e.attachEvent("onMouseMove",function(t,a){
i=e.getActionData(a).date,r=e.getActionData(a).section}),e._make_pasted_event=function(t){var a=t.end_date-t.start_date,l=e._lame_copy({},t);if(n(l),l.start_date=new Date(i),l.end_date=new Date(l.start_date.valueOf()+a),r){var d=e._get_section_property();l[d]=e.config.multisection?t[d]:r}return l},e._do_paste=function(t,a,n){e.addEvent(a),e.callEvent("onEventPasted",[t,a,n])},e._is_key_nav_active=function(){return this._is_initialized()&&!this._is_lightbox_open()&&this.config.key_nav?!0:!1},dhtmlxEvent(document,_isOpera?"keypress":"keydown",function(t){
if(!e._is_key_nav_active())return!0;if(t=t||event,37==t.keyCode||39==t.keyCode){t.cancelBubble=!0;var n=e.date.add(e._date,37==t.keyCode?-1:1,e._mode);return e.setCurrentView(n),!0}var i=e._select_id;if(t.ctrlKey&&67==t.keyCode)return i&&(e._buffer_id=i,l=!0,e.callEvent("onEventCopied",[e.getEvent(i)])),!0;if(t.ctrlKey&&88==t.keyCode&&i){l=!1,e._buffer_id=i;var r=e.getEvent(i);e.updateEvent(r.id),e.callEvent("onEventCut",[r])}if(t.ctrlKey&&86==t.keyCode&&a(t)){var r=e.getEvent(e._buffer_id);if(r){
var d=e._make_pasted_event(r);if(l)d.id=e.uid(),e._do_paste(l,d,r);else{var o=e.callEvent("onBeforeEventChanged",[d,t,!1,r]);o&&(e._do_paste(l,d,r),l=!0)}}return!0}})},e._temp_key_scope()});