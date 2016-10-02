/*
@license
dhtmlxScheduler.Net v.3.3.23 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){e.attachEvent("onTemplatesReady",function(){function t(t,n,i,r){if(!e.checkEvent("onBeforeExternalDragIn")||e.callEvent("onBeforeExternalDragIn",[t,n,i,r,a])){var d=e.attachEvent("onEventCreated",function(n){e.callEvent("onExternalDragIn",[n,t,a])||(this._drag_mode=this._drag_id=null,this.deleteEvent(n))}),l=e.getActionData(a),o={start_date:new Date(l.date)};if(e.matrix&&e.matrix[e._mode]){var s=e.matrix[e._mode];o[s.y_property]=l.section;var _=e._locate_cell_timeline(a);

o.start_date=s._trace_x[_.x],o.end_date=e.date.add(o.start_date,s.x_step,s.x_unit)}e._props&&e._props[e._mode]&&(o[e._props[e._mode].map_to]=l.section),e.addEventNow(o),e.detachEvent(d)}}var a,n=new dhtmlDragAndDropObject,i=n.stopDrag;n.stopDrag=function(e){return a=e||event,i.apply(this,arguments)},n.addDragLanding(e._els.dhx_cal_data[0],{_drag:function(e,a,n,i){t(e,a,n,i)},_dragIn:function(e,t){return e},_dragOut:function(e){return this}}),dhtmlx.DragControl&&dhtmlx.DragControl.addDrop(e._els.dhx_cal_data[0],{
onDrop:function(e,n,i,r){var d=dhtmlx.DragControl.getMaster(e);a=r,t(e,d,n,r.target||r.srcElement)},onDragIn:function(e,t,a){return t}},!0)})});