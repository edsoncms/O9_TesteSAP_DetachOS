﻿/*
 Highcharts JS v4.1.4 (2015-03-10)

 (c) 2009-2014 Torstein Honsi

 License: www.highcharts.com/license
*/
(function(k,D){function K(a,b,c){this.init.call(this,a,b,c)}var P=k.arrayMin,Q=k.arrayMax,u=k.each,H=k.extend,o=k.merge,R=k.map,q=k.pick,x=k.pInt,p=k.getOptions().plotOptions,g=k.seriesTypes,v=k.extendClass,L=k.splat,s=k.wrap,M=k.Axis,y=k.Tick,I=k.Point,S=k.Pointer,T=k.CenteredSeriesMixin,z=k.TrackerMixin,t=k.Series,w=Math,E=w.round,B=w.floor,N=w.max,U=k.Color,r=function(){};H(K.prototype,{init:function(a,b,c){var d=this,e=d.defaultOptions;d.chart=b;if(b.angular)e.background={};d.options=a=o(e,a);
(a=a.background)&&u([].concat(L(a)).reverse(),function(a){var h=a.backgroundColor,b=c.userOptions,a=o(d.defaultBackgroundOptions,a);if(h)a.backgroundColor=h;a.color=a.backgroundColor;c.options.plotBands.unshift(a);b.plotBands=b.plotBands||[];b.plotBands.unshift(a)})},defaultOptions:{center:["50%","50%"],size:"85%",startAngle:0},defaultBackgroundOptions:{shape:"circle",borderWidth:1,borderColor:"silver",backgroundColor:{linearGradient:{x1:0,y1:0,x2:0,y2:1},stops:[[0,"#FFF"],[1,"#DDD"]]},from:-Number.MAX_VALUE,
innerRadius:0,to:Number.MAX_VALUE,outerRadius:"105%"}});var G=M.prototype,y=y.prototype,V={getOffset:r,redraw:function(){this.isDirty=!1},render:function(){this.isDirty=!1},setScale:r,setCategories:r,setTitle:r},O={isRadial:!0,defaultRadialGaugeOptions:{labels:{align:"center",x:0,y:null},minorGridLineWidth:0,minorTickInterval:"auto",minorTickLength:10,minorTickPosition:"inside",minorTickWidth:1,tickLength:10,tickPosition:"inside",tickWidth:2,title:{rotation:0},zIndex:2},defaultRadialXOptions:{gridLineWidth:1,
labels:{align:null,distance:15,x:0,y:null},maxPadding:0,minPadding:0,showLastLabel:!1,tickLength:0},defaultRadialYOptions:{gridLineInterpolation:"circle",labels:{align:"right",x:-3,y:-2},showLastLabel:!1,title:{x:4,text:null,rotation:90}},setOptions:function(a){a=this.options=o(this.defaultOptions,this.defaultRadialOptions,a);if(!a.plotBands)a.plotBands=[]},getOffset:function(){G.getOffset.call(this);this.chart.axisOffset[this.side]=0;this.center=this.pane.center=T.getCenter.call(this.pane)},getLinePath:function(a,
b){var c=this.center,b=q(b,c[2]/2-this.offset);return this.chart.renderer.symbols.arc(this.left+c[0],this.top+c[1],b,b,{start:this.startAngleRad,end:this.endAngleRad,open:!0,innerR:0})},setAxisTranslation:function(){G.setAxisTranslation.call(this);if(this.center)this.transA=this.isCircular?(this.endAngleRad-this.startAngleRad)/(this.max-this.min||1):this.center[2]/2/(this.max-this.min||1),this.minPixelPadding=this.isXAxis?this.transA*this.minPointOffset:0},beforeSetTickPositions:function(){this.autoConnect&&
(this.max+=this.categories&&1||this.pointRange||this.closestPointRange||0)},setAxisSize:function(){G.setAxisSize.call(this);if(this.isRadial){this.center=this.pane.center=k.CenteredSeriesMixin.getCenter.call(this.pane);if(this.isCircular)this.sector=this.endAngleRad-this.startAngleRad;this.len=this.width=this.height=this.center[2]*q(this.sector,1)/2}},getPosition:function(a,b){return this.postTranslate(this.isCircular?this.translate(a):0,q(this.isCircular?b:this.translate(a),this.center[2]/2)-this.offset)},
postTranslate:function(a,b){var c=this.chart,d=this.center,a=this.startAngleRad+a;return{x:c.plotLeft+d[0]+Math.cos(a)*b,y:c.plotTop+d[1]+Math.sin(a)*b}},getPlotBandPath:function(a,b,c){var d=this.center,e=this.startAngleRad,f=d[2]/2,h=[q(c.outerRadius,"100%"),c.innerRadius,q(c.thickness,10)],i=/%$/,l,m=this.isCircular;this.options.gridLineInterpolation==="polygon"?d=this.getPlotLinePath(a).concat(this.getPlotLinePath(b,!0)):(a=Math.max(a,this.min),b=Math.min(b,this.max),m||(h[0]=this.translate(a),
h[1]=this.translate(b)),h=R(h,function(a){i.test(a)&&(a=x(a,10)*f/100);return a}),c.shape==="circle"||!m?(a=-Math.PI/2,b=Math.PI*1.5,l=!0):(a=e+this.translate(a),b=e+this.translate(b)),d=this.chart.renderer.symbols.arc(this.left+d[0],this.top+d[1],h[0],h[0],{start:Math.min(a,b),end:Math.max(a,b),innerR:q(h[1],h[0]-h[2]),open:l}));return d},getPlotLinePath:function(a,b){var c=this,d=c.center,e=c.chart,f=c.getPosition(a),h,i,l;c.isCircular?l=["M",d[0]+e.plotLeft,d[1]+e.plotTop,"L",f.x,f.y]:c.options.gridLineInterpolation===
"circle"?(a=c.translate(a))&&(l=c.getLinePath(0,a)):(u(e.xAxis,function(a){a.pane===c.pane&&(h=a)}),l=[],a=c.translate(a),d=h.tickPositions,h.autoConnect&&(d=d.concat([d[0]])),b&&(d=[].concat(d).reverse()),u(d,function(f,c){i=h.getPosition(f,a);l.push(c?"L":"M",i.x,i.y)}));return l},getTitlePosition:function(){var a=this.center,b=this.chart,c=this.options.title;return{x:b.plotLeft+a[0]+(c.x||0),y:b.plotTop+a[1]-{high:0.5,middle:0.25,low:0}[c.align]*a[2]+(c.y||0)}}};s(G,"init",function(a,b,c){var j;
var d=b.angular,e=b.polar,f=c.isX,h=d&&f,i,l;l=b.options;var m=c.pane||0;if(d){if(H(this,h?V:O),i=!f)this.defaultRadialOptions=this.defaultRadialGaugeOptions}else if(e)H(this,O),this.defaultRadialOptions=(i=f)?this.defaultRadialXOptions:o(this.defaultYAxisOptions,this.defaultRadialYOptions);a.call(this,b,c);if(!h&&(d||e)){a=this.options;if(!b.panes)b.panes=[];this.pane=(j=b.panes[m]=b.panes[m]||new K(L(l.pane)[m],b,this),m=j);m=m.options;b.inverted=!1;l.chart.zoomType=null;this.startAngleRad=b=(m.startAngle-
90)*Math.PI/180;this.endAngleRad=l=(q(m.endAngle,m.startAngle+360)-90)*Math.PI/180;this.offset=a.offset||0;if((this.isCircular=i)&&c.max===D&&l-b===2*Math.PI)this.autoConnect=!0}});s(y,"getPosition",function(a,b,c,d,e){var f=this.axis;return f.getPosition?f.getPosition(c):a.call(this,b,c,d,e)});s(y,"getLabelPosition",function(a,b,c,d,e,f,h,i,l){var m=this.axis,j=f.y,n=20,g=f.align,A=(m.translate(this.pos)+m.startAngleRad+Math.PI/2)/Math.PI*180%360;m.isRadial?(a=m.getPosition(this.pos,m.center[2]/
2+q(f.distance,-25)),f.rotation==="auto"?d.attr({rotation:A}):j===null&&(j=m.chart.renderer.fontMetrics(d.styles.fontSize).b-d.getBBox().height/2),g===null&&(m.isCircular?(this.label.getBBox().width>m.len*m.tickInterval/(m.max-m.min)&&(n=0),g=A>n&&A<180-n?"left":A>180+n&&A<360-n?"right":"center"):g="center",d.attr({align:g})),a.x+=f.x,a.y+=j):a=a.call(this,b,c,d,e,f,h,i,l);return a});s(y,"getMarkPath",function(a,b,c,d,e,f,h){var i=this.axis;i.isRadial?(a=i.getPosition(this.pos,i.center[2]/2+d),b=
["M",b,c,"L",a.x,a.y]):b=a.call(this,b,c,d,e,f,h);return b});p.arearange=o(p.area,{lineWidth:1,marker:null,threshold:null,tooltip:{pointFormat:'<span style="color:{series.color}">●</span> {series.name}: <b>{point.low}</b> - <b>{point.high}</b><br/>'},trackByArea:!0,dataLabels:{align:null,verticalAlign:null,xLow:0,xHigh:0,yLow:0,yHigh:0},states:{hover:{halo:!1}}});g.arearange=v(g.area,{type:"arearange",pointArrayMap:["low","high"],toYData:function(a){return[a.low,a.high]},pointValKey:"low",deferTranslatePolar:!0,
highToXY:function(a){var b=this.chart,c=this.xAxis.postTranslate(a.rectPlotX,this.yAxis.len-a.plotHigh);a.plotHighX=c.x-b.plotLeft;a.plotHigh=c.y-b.plotTop},getSegments:function(){var a=this;u(a.points,function(b){if(!a.options.connectNulls&&(b.low===null||b.high===null))b.y=null;else if(b.low===null&&b.high!==null)b.y=b.high});t.prototype.getSegments.call(this)},translate:function(){var a=this,b=a.yAxis;g.area.prototype.translate.apply(a);u(a.points,function(a){var d=a.low,e=a.high,f=a.plotY;e===
null&&d===null?a.y=null:d===null?(a.plotLow=a.plotY=null,a.plotHigh=b.translate(e,0,1,0,1)):e===null?(a.plotLow=f,a.plotHigh=null):(a.plotLow=f,a.plotHigh=b.translate(e,0,1,0,1))});this.chart.polar&&u(this.points,function(c){a.highToXY(c)})},getSegmentPath:function(a){var b,c=[],d=a.length,e=t.prototype.getSegmentPath,f,h;h=this.options;var i=h.step;for(b=HighchartsAdapter.grep(a,function(a){return a.plotLow!==null});d--;)f=a[d],f.plotHigh!==null&&c.push({plotX:f.plotHighX||f.plotX,plotY:f.plotHigh});
a=e.call(this,b);if(i)i===!0&&(i="left"),h.step={left:"right",center:"center",right:"left"}[i];c=e.call(this,c);h.step=i;h=[].concat(a,c);this.chart.polar||(c[0]="L");this.areaPath=this.areaPath.concat(a,c);return h},drawDataLabels:function(){var a=this.data,b=a.length,c,d=[],e=t.prototype,f=this.options.dataLabels,h=f.align,i,l=this.chart.inverted;if(f.enabled||this._hasPointLabels){for(c=b;c--;)if(i=a[c],i.y=i.high,i._plotY=i.plotY,i.plotY=i.plotHigh,d[c]=i.dataLabel,i.dataLabel=i.dataLabelUpper,
i.below=!1,l){if(!h)f.align="left";f.x=f.xHigh}else f.y=f.yHigh;e.drawDataLabels&&e.drawDataLabels.apply(this,arguments);for(c=b;c--;)if(i=a[c],i.dataLabelUpper=i.dataLabel,i.dataLabel=d[c],i.y=i.low,i.plotY=i._plotY,i.below=!0,l){if(!h)f.align="right";f.x=f.xLow}else f.y=f.yLow;e.drawDataLabels&&e.drawDataLabels.apply(this,arguments)}f.align=h},alignDataLabel:function(){g.column.prototype.alignDataLabel.apply(this,arguments)},setStackedPoints:r,getSymbol:r,drawPoints:r});p.areasplinerange=o(p.arearange);
g.areasplinerange=v(g.arearange,{type:"areasplinerange",getPointSpline:g.spline.prototype.getPointSpline});(function(){var a=g.column.prototype;p.columnrange=o(p.column,p.arearange,{lineWidth:1,pointRange:null});g.columnrange=v(g.arearange,{type:"columnrange",translate:function(){var b=this,c=b.yAxis,d;a.translate.apply(b);u(b.points,function(a){var f=a.shapeArgs,h=b.options.minPointLength,i;a.tooltipPos=null;a.plotHigh=d=c.translate(a.high,0,1,0,1);a.plotLow=a.plotY;i=d;a=a.plotY-d;a<h&&(h-=a,a+=
h,i-=h/2);f.height=a;f.y=i})},directTouch:!0,trackerGroups:["group","dataLabelsGroup"],drawGraph:r,pointAttrToOptions:a.pointAttrToOptions,drawPoints:a.drawPoints,drawTracker:a.drawTracker,animate:a.animate,getColumnMetrics:a.getColumnMetrics})})();p.gauge=o(p.line,{dataLabels:{enabled:!0,defer:!1,y:15,borderWidth:1,borderColor:"silver",borderRadius:3,crop:!1,verticalAlign:"top",zIndex:2},dial:{},pivot:{},tooltip:{headerFormat:""},showInLegend:!1});z={type:"gauge",pointClass:v(I,{setState:function(a){this.state=
a}}),angular:!0,drawGraph:r,fixedBox:!0,forceDL:!0,trackerGroups:["group","dataLabelsGroup"],translate:function(){var a=this.yAxis,b=this.options,c=a.center;this.generatePoints();u(this.points,function(d){var e=o(b.dial,d.dial),f=x(q(e.radius,80))*c[2]/200,h=x(q(e.baseLength,70))*f/100,i=x(q(e.rearLength,10))*f/100,l=e.baseWidth||3,m=e.topWidth||1,j=b.overshoot,n=a.startAngleRad+a.translate(d.y,null,null,null,!0);j&&typeof j==="number"?(j=j/180*Math.PI,n=Math.max(a.startAngleRad-j,Math.min(a.endAngleRad+
j,n))):b.wrap===!1&&(n=Math.max(a.startAngleRad,Math.min(a.endAngleRad,n)));n=n*180/Math.PI;d.shapeType="path";d.shapeArgs={d:e.path||["M",-i,-l/2,"L",h,-l/2,f,-m/2,f,m/2,h,l/2,-i,l/2,"z"],translateX:c[0],translateY:c[1],rotation:n};d.plotX=c[0];d.plotY=c[1]})},drawPoints:function(){var a=this,b=a.yAxis.center,c=a.pivot,d=a.options,e=d.pivot,f=a.chart.renderer;u(a.points,function(c){var b=c.graphic,e=c.shapeArgs,m=e.d,j=o(d.dial,c.dial);b?(b.animate(e),e.d=m):c.graphic=f[c.shapeType](e).attr({stroke:j.borderColor||
"none","stroke-width":j.borderWidth||0,fill:j.backgroundColor||"black",rotation:e.rotation}).add(a.group)});c?c.animate({translateX:b[0],translateY:b[1]}):a.pivot=f.circle(0,0,q(e.radius,5)).attr({"stroke-width":e.borderWidth||0,stroke:e.borderColor||"silver",fill:e.backgroundColor||"black"}).translate(b[0],b[1]).add(a.group)},animate:function(a){var b=this;if(!a)u(b.points,function(a){var d=a.graphic;d&&(d.attr({rotation:b.yAxis.startAngleRad*180/Math.PI}),d.animate({rotation:a.shapeArgs.rotation},
b.options.animation))}),b.animate=null},render:function(){this.group=this.plotGroup("group","series",this.visible?"visible":"hidden",this.options.zIndex,this.chart.seriesGroup);t.prototype.render.call(this);this.group.clip(this.chart.clipRect)},setData:function(a,b){t.prototype.setData.call(this,a,!1);this.processData();this.generatePoints();q(b,!0)&&this.chart.redraw()},drawTracker:z&&z.drawTrackerPoint};g.gauge=v(g.line,z);p.boxplot=o(p.column,{fillColor:"#FFFFFF",lineWidth:1,medianWidth:2,states:{hover:{brightness:-0.3}},
threshold:null,tooltip:{pointFormat:'<span style="color:{point.color}">●</span> <b> {series.name}</b><br/>Maximum: {point.high}<br/>Upper quartile: {point.q3}<br/>Median: {point.median}<br/>Lower quartile: {point.q1}<br/>Minimum: {point.low}<br/>'},whiskerLength:"50%",whiskerWidth:2});g.boxplot=v(g.column,{type:"boxplot",pointArrayMap:["low","q1","median","q3","high"],toYData:function(a){return[a.low,a.q1,a.median,a.q3,a.high]},pointValKey:"high",pointAttrToOptions:{fill:"fillColor",stroke:"color",
"stroke-width":"lineWidth"},drawDataLabels:r,translate:function(){var a=this.yAxis,b=this.pointArrayMap;g.column.prototype.translate.apply(this);u(this.points,function(c){u(b,function(b){c[b]!==null&&(c[b+"Plot"]=a.translate(c[b],0,1,0,1))})})},drawPoints:function(){var a=this,b=a.points,c=a.options,d=a.chart.renderer,e,f,h,i,l,m,j,n,g,A,k,J,p,o,s,r,v,t,w,x,z,y,F=a.doQuartiles!==!1,C=parseInt(a.options.whiskerLength,10)/100;u(b,function(b){g=b.graphic;z=b.shapeArgs;k={};o={};r={};y=b.color||a.color;
if(b.plotY!==D)if(e=b.pointAttr[b.selected?"selected":""],v=z.width,t=B(z.x),w=t+v,x=E(v/2),f=B(F?b.q1Plot:b.lowPlot),h=B(F?b.q3Plot:b.lowPlot),i=B(b.highPlot),l=B(b.lowPlot),k.stroke=b.stemColor||c.stemColor||y,k["stroke-width"]=q(b.stemWidth,c.stemWidth,c.lineWidth),k.dashstyle=b.stemDashStyle||c.stemDashStyle,o.stroke=b.whiskerColor||c.whiskerColor||y,o["stroke-width"]=q(b.whiskerWidth,c.whiskerWidth,c.lineWidth),r.stroke=b.medianColor||c.medianColor||y,r["stroke-width"]=q(b.medianWidth,c.medianWidth,
c.lineWidth),j=k["stroke-width"]%2/2,n=t+x+j,A=["M",n,h,"L",n,i,"M",n,f,"L",n,l],F&&(j=e["stroke-width"]%2/2,n=B(n)+j,f=B(f)+j,h=B(h)+j,t+=j,w+=j,J=["M",t,h,"L",t,f,"L",w,f,"L",w,h,"L",t,h,"z"]),C&&(j=o["stroke-width"]%2/2,i+=j,l+=j,p=["M",n-x*C,i,"L",n+x*C,i,"M",n-x*C,l,"L",n+x*C,l]),j=r["stroke-width"]%2/2,m=E(b.medianPlot)+j,s=["M",t,m,"L",w,m],g)b.stem.animate({d:A}),C&&b.whiskers.animate({d:p}),F&&b.box.animate({d:J}),b.medianShape.animate({d:s});else{b.graphic=g=d.g().add(a.group);b.stem=d.path(A).attr(k).add(g);
if(C)b.whiskers=d.path(p).attr(o).add(g);if(F)b.box=d.path(J).attr(e).add(g);b.medianShape=d.path(s).attr(r).add(g)}})},setStackedPoints:r});p.errorbar=o(p.boxplot,{color:"#000000",grouping:!1,linkedTo:":previous",tooltip:{pointFormat:'<span style="color:{point.color}">●</span> {series.name}: <b>{point.low}</b> - <b>{point.high}</b><br/>'},whiskerWidth:null});g.errorbar=v(g.boxplot,{type:"errorbar",pointArrayMap:["low","high"],toYData:function(a){return[a.low,a.high]},pointValKey:"high",doQuartiles:!1,
drawDataLabels:g.arearange?g.arearange.prototype.drawDataLabels:r,getColumnMetrics:function(){return this.linkedParent&&this.linkedParent.columnMetrics||g.column.prototype.getColumnMetrics.call(this)}});p.waterfall=o(p.column,{lineWidth:1,lineColor:"#333",dashStyle:"dot",borderColor:"#333",dataLabels:{inside:!0},states:{hover:{lineWidthPlus:0}}});g.waterfall=v(g.column,{type:"waterfall",upColorProp:"fill",pointArrayMap:["low","y"],pointValKey:"y",translate:function(){var a=this.options,b=this.yAxis,
c,d,e,f,h,i,l,m,j,n=a.threshold,k=a.stacking;g.column.prototype.translate.apply(this);l=m=n;d=this.points;for(c=0,a=d.length;c<a;c++){e=d[c];i=this.processedYData[c];f=e.shapeArgs;j=(h=k&&b.stacks[(this.negStacks&&i<n?"-":"")+this.stackKey])?h[e.x].points[this.index+","+c]:[0,i];if(e.isSum)e.y=i;else if(e.isIntermediateSum)e.y=i-m;h=N(l,l+e.y)+j[0];f.y=b.translate(h,0,1);if(e.isSum)f.y=b.translate(j[1],0,1),f.height=b.translate(j[0],0,1)-f.y;else if(e.isIntermediateSum)f.y=b.translate(j[1],0,1),f.height=
b.translate(m,0,1)-f.y,m=j[1];else{if(l!==0)f.height=i>0?b.translate(l,0,1)-f.y:b.translate(l,0,1)-b.translate(l-i,0,1);l+=i}e.plotY=f.y=E(f.y)-this.borderWidth%2/2;f.height=N(E(f.height),0.001);e.yBottom=f.y+f.height;f=e.plotY+(e.negative?f.height:0);this.chart.inverted?e.tooltipPos[0]=b.len-f:e.tooltipPos[1]=f}},processData:function(a){var b=this.yData,c=this.options.data,d,e=b.length,f,h,i,l,m,j;h=f=i=l=this.options.threshold||0;for(j=0;j<e;j++)m=b[j],d=c&&c[j]?c[j]:{},m==="sum"||d.isSum?b[j]=
h:m==="intermediateSum"||d.isIntermediateSum?b[j]=f:(h+=m,f+=m),i=Math.min(h,i),l=Math.max(h,l);t.prototype.processData.call(this,a);this.dataMin=i;this.dataMax=l},toYData:function(a){if(a.isSum)return a.x===0?null:"sum";else if(a.isIntermediateSum)return a.x===0?null:"intermediateSum";return a.y},getAttribs:function(){g.column.prototype.getAttribs.apply(this,arguments);var a=this,b=a.options,c=b.states,d=b.upColor||a.color,b=k.Color(d).brighten(0.1).get(),e=o(a.pointAttr),f=a.upColorProp;e[""][f]=
d;e.hover[f]=c.hover.upColor||b;e.select[f]=c.select.upColor||d;u(a.points,function(b){if(!b.options.color)b.y>0?(b.pointAttr=e,b.color=d):b.pointAttr=a.pointAttr})},getGraphPath:function(){var a=this.data,b=a.length,c=E(this.options.lineWidth+this.borderWidth)%2/2,d=[],e,f,h;for(h=1;h<b;h++)f=a[h].shapeArgs,e=a[h-1].shapeArgs,f=["M",e.x+e.width,e.y+c,"L",f.x,e.y+c],a[h-1].y<0&&(f[2]+=e.height,f[5]+=e.height),d=d.concat(f);return d},getExtremes:r,drawGraph:t.prototype.drawGraph});p.polygon=o(p.scatter,
{marker:{enabled:!1}});g.polygon=v(g.scatter,{type:"polygon",fillGraph:!0,getSegmentPath:function(a){return t.prototype.getSegmentPath.call(this,a).concat("z")},drawGraph:t.prototype.drawGraph,drawLegendSymbol:k.LegendSymbolMixin.drawRectangle});p.bubble=o(p.scatter,{dataLabels:{formatter:function(){return this.point.z},inside:!0,verticalAlign:"middle"},marker:{lineColor:null,lineWidth:1},minSize:8,maxSize:"20%",states:{hover:{halo:{size:5}}},tooltip:{pointFormat:"({point.x}, {point.y}), Size: {point.z}"},
turboThreshold:0,zThreshold:0,zoneAxis:"z"});z=v(I,{haloPath:function(){return I.prototype.haloPath.call(this,this.shapeArgs.r+this.series.options.states.hover.halo.size)},ttBelow:!1});g.bubble=v(g.scatter,{type:"bubble",pointClass:z,pointArrayMap:["y","z"],parallelArrays:["x","y","z"],trackerGroups:["group","dataLabelsGroup"],bubblePadding:!0,zoneAxis:"z",pointAttrToOptions:{stroke:"lineColor","stroke-width":"lineWidth",fill:"fillColor"},applyOpacity:function(a){var b=this.options.marker,c=q(b.fillOpacity,
0.5),a=a||b.fillColor||this.color;c!==1&&(a=U(a).setOpacity(c).get("rgba"));return a},convertAttribs:function(){var a=t.prototype.convertAttribs.apply(this,arguments);a.fill=this.applyOpacity(a.fill);return a},getRadii:function(a,b,c,d){var e,f,h,i=this.zData,l=[],m=this.options.sizeBy!=="width";for(f=0,e=i.length;f<e;f++)h=b-a,h=h>0?(i[f]-a)/(b-a):0.5,m&&h>=0&&(h=Math.sqrt(h)),l.push(w.ceil(c+h*(d-c))/2);this.radii=l},animate:function(a){var b=this.options.animation;if(!a)u(this.points,function(a){var d=
a.graphic,a=a.shapeArgs;d&&a&&(d.attr("r",1),d.animate({r:a.r},b))}),this.animate=null},translate:function(){var a,b=this.data,c,d,e=this.radii;g.scatter.prototype.translate.call(this);for(a=b.length;a--;)c=b[a],d=e?e[a]:0,d>=this.minPxSize/2?(c.shapeType="circle",c.shapeArgs={x:c.plotX,y:c.plotY,r:d},c.dlBox={x:c.plotX-d,y:c.plotY-d,width:2*d,height:2*d}):c.shapeArgs=c.plotY=c.dlBox=D},drawLegendSymbol:function(a,b){var c=x(a.itemStyle.fontSize)/2;b.legendSymbol=this.chart.renderer.circle(c,a.baseline-
c,c).attr({zIndex:3}).add(b.legendGroup);b.legendSymbol.isMarker=!0},drawPoints:g.column.prototype.drawPoints,alignDataLabel:g.column.prototype.alignDataLabel,buildKDTree:r,applyZones:r});M.prototype.beforePadding=function(){var a=this,b=this.len,c=this.chart,d=0,e=b,f=this.isXAxis,h=f?"xData":"yData",i=this.min,l={},m=w.min(c.plotWidth,c.plotHeight),j=Number.MAX_VALUE,n=-Number.MAX_VALUE,g=this.max-i,k=b/g,p=[];u(this.series,function(b){var h=b.options;if(b.bubblePadding&&(b.visible||!c.options.chart.ignoreHiddenSeries))if(a.allowZoomOutside=
!0,p.push(b),f)u(["minSize","maxSize"],function(a){var b=h[a],f=/%$/.test(b),b=x(b);l[a]=f?m*b/100:b}),b.minPxSize=l.minSize,b=b.zData,b.length&&(j=q(h.zMin,w.min(j,w.max(P(b),h.displayNegative===!1?h.zThreshold:-Number.MAX_VALUE))),n=q(h.zMax,w.max(n,Q(b))))});u(p,function(a){var b=a[h],c=b.length,m;f&&a.getRadii(j,n,l.minSize,l.maxSize);if(g>0)for(;c--;)typeof b[c]==="number"&&(m=a.radii[c],d=Math.min((b[c]-i)*k-m,d),e=Math.max((b[c]-i)*k+m,e))});p.length&&g>0&&q(this.options.min,this.userMin)===
D&&q(this.options.max,this.userMax)===D&&(e-=b,k*=(b+d-e)/b,this.min+=d/k,this.max+=e/k)};(function(){function a(a,b,c){a.call(this,b,c);if(this.chart.polar)this.closeSegment=function(a){var b=this.xAxis.center;a.push("L",b[0],b[1])},this.closedStacks=!0}function b(a,b){var c=this.chart,d=this.options.animation,e=this.group,j=this.markerGroup,n=this.xAxis.center,g=c.plotLeft,k=c.plotTop;if(c.polar){if(c.renderer.isSVG)d===!0&&(d={}),b?(c={translateX:n[0]+g,translateY:n[1]+k,scaleX:0.001,scaleY:0.001},
e.attr(c),j&&j.attr(c)):(c={translateX:g,translateY:k,scaleX:1,scaleY:1},e.animate(c,d),j&&j.animate(c,d),this.animate=null)}else a.call(this,b)}var c=t.prototype,d=S.prototype,e;c.searchPolarPoint=function(a){var b=this.chart,c=this.xAxis.pane.center,d=a.chartX-c[0]-b.plotLeft,a=a.chartY-c[1]-b.plotTop;this.kdAxisArray=["clientX"];a={clientX:180+Math.atan2(d,a)*(-180/Math.PI)};return this.searchKDTree(a)};s(c,"buildKDTree",function(a){if(this.chart.polar)this.kdAxisArray=["clientX"];a.apply(this)});
s(c,"searchPoint",function(a,b){return this.chart.polar?this.searchPolarPoint(b):a.call(this,b)});c.toXY=function(a){var b,c=this.chart,d=a.plotX;b=a.plotY;a.rectPlotX=d;a.rectPlotY=b;d=(d/Math.PI*180+this.xAxis.pane.options.startAngle)%360;d<0&&(d+=360);a.clientX=d;b=this.xAxis.postTranslate(a.plotX,this.yAxis.len-b);a.plotX=a.polarPlotX=b.x-c.plotLeft;a.plotY=a.polarPlotY=b.y-c.plotTop};g.area&&s(g.area.prototype,"init",a);g.areaspline&&s(g.areaspline.prototype,"init",a);g.spline&&s(g.spline.prototype,
"getPointSpline",function(a,b,c,d){var e,j,n,g,k,p,o;if(this.chart.polar){e=c.plotX;j=c.plotY;a=b[d-1];n=b[d+1];this.connectEnds&&(a||(a=b[b.length-2]),n||(n=b[1]));if(a&&n)g=a.plotX,k=a.plotY,b=n.plotX,p=n.plotY,g=(1.5*e+g)/2.5,k=(1.5*j+k)/2.5,n=(1.5*e+b)/2.5,o=(1.5*j+p)/2.5,b=Math.sqrt(Math.pow(g-e,2)+Math.pow(k-j,2)),p=Math.sqrt(Math.pow(n-e,2)+Math.pow(o-j,2)),g=Math.atan2(k-j,g-e),k=Math.atan2(o-j,n-e),o=Math.PI/2+(g+k)/2,Math.abs(g-o)>Math.PI/2&&(o-=Math.PI),g=e+Math.cos(o)*b,k=j+Math.sin(o)*
b,n=e+Math.cos(Math.PI+o)*p,o=j+Math.sin(Math.PI+o)*p,c.rightContX=n,c.rightContY=o;d?(c=["C",a.rightContX||a.plotX,a.rightContY||a.plotY,g||e,k||j,e,j],a.rightContX=a.rightContY=null):c=["M",e,j]}else c=a.call(this,b,c,d);return c});s(c,"translate",function(a){a.call(this);if(this.chart.polar&&!this.preventPostTranslate)for(var a=this.points,b=a.length;b--;)this.toXY(a[b])});s(c,"getSegmentPath",function(a,b){var c=this.points;if(this.chart.polar&&this.options.connectEnds!==!1&&b[b.length-1]===c[c.length-
1]&&c[0].y!==null)this.connectEnds=!0,b=[].concat(b,[c[0]]);return a.call(this,b)});s(c,"animate",b);if(g.column)e=g.column.prototype,s(e,"animate",b),s(e,"translate",function(a){var b=this.xAxis,c=this.yAxis.len,d=b.center,e=b.startAngleRad,j=this.chart.renderer,g,k;this.preventPostTranslate=!0;a.call(this);if(b.isRadial){b=this.points;for(k=b.length;k--;)g=b[k],a=g.barX+e,g.shapeType="path",g.shapeArgs={d:j.symbols.arc(d[0],d[1],c-g.plotY,null,{start:a,end:a+g.pointWidth,innerR:c-q(g.yBottom,c)})},
this.toXY(g),g.tooltipPos=[g.plotX,g.plotY],g.ttBelow=g.plotY>d[1]}}),s(e,"alignDataLabel",function(a,b,d,e,g,j){if(this.chart.polar){a=b.rectPlotX/Math.PI*180;if(e.align===null)e.align=a>20&&a<160?"left":a>200&&a<340?"right":"center";if(e.verticalAlign===null)e.verticalAlign=a<45||a>315?"bottom":a>135&&a<225?"top":"middle";c.alignDataLabel.call(this,b,d,e,g,j)}else a.call(this,b,d,e,g,j)});s(d,"getCoordinates",function(a,b){var c=this.chart,d={xAxis:[],yAxis:[]};c.polar?u(c.axes,function(a){var e=
a.isXAxis,f=a.center,g=b.chartX-f[0]-c.plotLeft,f=b.chartY-f[1]-c.plotTop;d[e?"xAxis":"yAxis"].push({axis:a,value:a.translate(e?Math.PI-Math.atan2(g,f):Math.sqrt(Math.pow(g,2)+Math.pow(f,2)),!0)})}):d=a.call(this,b);return d})})()})(Highcharts);



outsystems.initChartCore = function(divId,widgetId,hasDrilldown){
    var $chart_div = outsystems.internal.$('#' + divId);
    this.$chart_div = $chart_div;
    this.chart_div = $chart_div[0];
    
    this.noOp = function(){return true;}
    
    // Drilldown functions
    if(hasDrilldown){
        this.mouseover = function () {
               $chart_div.find('div:first-child').css('cursor', 'pointer'); 
        };
        this.mouseout = function () {        
               $chart_div.find('div:first-child').css('cursor', ''); 
        };
        this.click = function(message){
            return function(){
                $chart_div.find('div:first-child').css('cursor', 'pointer'); 
                OsNotifyWidget(widgetId, message);
            }
        };
    }
    
    // Bring plotline and plotband labels to front
    var fixZIndex = function(chart, axis){
        if(chart[axis]){
            for(var i = 0; i < chart[axis].length; i++){
                if(chart[axis][i].plotLinesAndBands){
                    for(var j = 0; j < chart[axis][i].plotLinesAndBands.length; j++){
                        if(chart[axis][i].plotLinesAndBands[j].label){
                            chart[axis][i].plotLinesAndBands[j].label.attr({zIndex:3}).add();
                        }
                    }
                }
            }
        }
    }
    
    // Callback function
    this.callback = function(chart){
        fixZIndex(chart,'xAxis');
        fixZIndex(chart,'yAxis');
        outsystems.internal.$('path[stroke-opacity]').each(function(){
            outsystems.internal.$(this).attr('opacity', outsystems.internal.$(this).attr('stroke-opacity'));
        });
        chart.setSize($chart_div.width(), $chart_div.height(), false);
        chart.hasUserSize = false; 
        // We need this last hack for very low height charts, because in that case HighCharts would try to grow to its default size.
    }
}

outsystems.hasTouch = function () {
    return document.documentElement.ontouchstart !== undefined || (window.navigator.msMaxTouchPoints && window.navigator.msMaxTouchPoints > 0);
}

outsystems.ext = function(json, jsonExt) { return outsystems.internal.$.extend(true, json, jsonExt); }

outsystems.internal.$(window).load(function() {
    setTimeout("outsystems.internal.$(window).resize()", 750);
});

outsystems.internal.RichWidgets_Tabs_ClientSide_HighCharts_Resize = function() {
    var i;
    var length = Highcharts.charts.length;
    for(i = 0; i < length; i++) {
        var chart = Highcharts.charts[i];
        var container = Highcharts.charts[i].container.parentElement;
        if( typeof container !== 'undefined' && container != null) {
            var isOSChart = container.className.indexOf('OSChart');
            var hasInvalidSize = $(container).height() == 0 || $(container).width() == 0;
            
            if (isOSChart >= 0 && !hasInvalidSize) {     
                chart.setSize($(container).width(), $(container).height(), false);
            }
        }
    }
}

//#599152 Charts need to be resized when a client tab becomes visible, as its height is zero when rendered in a hidden div.
outsystems.internal.$(function(){
    if (!(typeof(outsystems.internal.Tab_Show_Callback_Register) == 'undefined')) {
        outsystems.internal.Tab_Show_Callback_Register(outsystems.internal.RichWidgets_Tabs_ClientSide_HighCharts_Resize);
    } else if(!(typeof(Tab_Show_Callback_Register) == 'undefined')) {
        Tab_Show_Callback_Register(outsystems.internal.RichWidgets_Tabs_ClientSide_HighCharts_Resize);
    }
});

Highcharts.Chart.prototype.callbacks.push(function(chart) {
  var hasTouch = outsystems.hasTouch(),
      mouseTracker = chart.pointer,
      container = chart.container,
      mouseMove;  
  
  mouseMove = function (e) {    
    if (hasTouch) {
        if (e && e.touches && e.touches.length > 1 && chart.options.chart.zoomType) {
            mouseTracker.onContainerTouchMove(e);
        } else {
            return;
        }
    } else {
      mouseTracker.onContainerMouseMove(e);
    }
  };
  
  click = function (e) {    
    if (hasTouch) { 
        mouseTracker.onContainerMouseMove(e);      
    }
    mouseTracker.onContainerClick(e);    
  }

  container.onclick = click;

  if (window.navigator.msPointerEnabled && hasTouch) {
    container.onmousemove = null;
    container.onmousedown = null;
  } else {
    container.onmousemove = container.ontouchstart = container.ontouchmove = mouseMove;
  }
});

outsystems.chartColors = ['#0082c8','#a6ccea','#cc1439','#e68c7c','#53b336','#a5d38e','#e68a00','#f3da61','#976bb3', '#ccb8cc'];

outsystems.internal.$(function ($) {
    $div = $('<div style=""color: transparent""></div>');
    $div.appendTo('body');
    divColor = $div.css('color');
    for (i=1; i<=10; i++) {            
        $span = $('<span class="Chart_Color' + i + '"></span>');    
        $span.appendTo($div);
        color = $span.css('color');
        if (color != divColor) {
            outsystems.chartColors[i-1] = color;
        } else {
            break;
        }
    }
    $div.remove();
    Highcharts.setOptions({colors: outsystems.chartColors});
});

