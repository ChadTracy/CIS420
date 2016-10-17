/*
@license
dhtmlxScheduler.Net v.3.3.23 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){!function(){function t(e){var t={};for(var a in e)0!==a.indexOf("_")&&(t[a]=e[a]);return l.use_id||delete t.id,t}function a(){clearTimeout(d),d=setTimeout(function(){e.updateView()},1)}function n(e){e._loading=!0,e._not_render=!0,e.callEvent("onXLS",[])}function i(e){e._not_render=!1,e._render_wait&&e.render_view_data(),e._loading=!1,e.callEvent("onXLE",[])}function r(e){return l.use_id?e.id:e.cid}var d,l={use_id:!1};e.backbone=function(d,o){function s(){_.length&&(e.parse(_,"json"),
_=[])}o&&(l=o),d.bind("change",function(t,n){var i=r(t),d=e._events[i]=t.toJSON();d.id=i,e._init_event(d),a()}),d.bind("remove",function(t,a){var n=r(t);e._events[n]&&e.deleteEvent(n)});var _=[];d.bind("add",function(t,a){var n=r(t);if(!e._events[n]){var i=t.toJSON();i.id=n,e._init_event(i),_.push(i),1==_.length&&setTimeout(s,1)}}),d.bind("request",function(t){t instanceof Backbone.Collection&&n(e)}),d.bind("sync",function(t){t instanceof Backbone.Collection&&i(e)}),d.bind("error",function(t){t instanceof Backbone.Collection&&i(e);

}),e.attachEvent("onEventCreated",function(t){var a=new d.model(e.getEvent(t));return e._events[t]=a.toJSON(),e._events[t].id=t,!0}),e.attachEvent("onEventAdded",function(a){if(!d.get(a)){var n=t(e.getEvent(a)),i=new d.model(n),l=r(i);l!=a&&this.changeEventId(a,l),d.add(i),d.trigger("scheduler:add",i)}return!0}),e.attachEvent("onEventChanged",function(a){var n=d.get(a),i=t(e.getEvent(a));return n.set(i),d.trigger("scheduler:change",n),!0}),e.attachEvent("onEventDeleted",function(e){var t=d.get(e);

return t&&(d.trigger("scheduler:remove",t),d.remove(e)),!0})}}()});