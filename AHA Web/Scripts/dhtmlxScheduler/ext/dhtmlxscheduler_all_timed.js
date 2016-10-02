/*
@license
dhtmlxScheduler.Net v.3.3.23 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){!function(){e.config.all_timed="short";var t=function(e){return!((e.end_date-e.start_date)/36e5>=24)};e._safe_copy=function(t){var a=null,i=null;return t.event_pid&&(a=e.getEvent(t.event_pid)),a&&a.isPrototypeOf(t)?(i=e._copy_event(t),delete i.event_length,delete i.event_pid,delete i.rec_pattern,delete i.rec_type):i=e._lame_clone(t),i};var a=e._pre_render_events_line;e._pre_render_events_line=function(i,n){function l(e){var t=r(e.start_date);return+e.end_date>+t}function r(t){
var a=e.date.add(t,1,"day");return a=e.date.date_part(a)}function o(t,a){var i=e.date.date_part(new Date(t));return i.setHours(a),i}if(!this.config.all_timed)return a.call(this,i,n);for(var d=0;d<i.length;d++){var s=i[d];if(!s._timed)if("short"!=this.config.all_timed||t(s)){var _=this._safe_copy(s);_.start_date=new Date(_.start_date),l(s)?(_.end_date=r(_.start_date),24!=this.config.last_hour&&(_.end_date=o(_.start_date,this.config.last_hour))):_.end_date=new Date(s.end_date);var c=!1;_.start_date<this._max_date&&_.end_date>this._min_date&&_.start_date<_.end_date&&(i[d]=_,
c=!0);var u=this._safe_copy(s);if(u.end_date=new Date(u.end_date),u.start_date=u.start_date<this._min_date?o(this._min_date,this.config.first_hour):o(r(s.start_date),this.config.first_hour),u.start_date<this._max_date&&u.start_date<u.end_date){if(!c){i[d--]=u;continue}i.splice(d+1,0,u)}}else i.splice(d--,1)}var h="move"==this._drag_mode?!1:n;return a.call(this,i,h)};var i=e.get_visible_events;e.get_visible_events=function(e){return this.config.all_timed&&this.config.multi_day?i.call(this,!1):i.call(this,e);

},e.attachEvent("onBeforeViewChange",function(t,a,i,n){return e._allow_dnd="day"==i||"week"==i,!0}),e._is_main_area_event=function(e){return!!(e._timed||this.config.all_timed===!0||"short"==this.config.all_timed&&t(e))};var n=e.updateEvent;e.updateEvent=function(t){var a,i=e.config.all_timed&&!(e.isOneDayEvent(e._events[t])||e.getState().drag_id);i&&(a=e.config.update_render,e.config.update_render=!0),n.apply(e,arguments),i&&(e.config.update_render=a)}}()});