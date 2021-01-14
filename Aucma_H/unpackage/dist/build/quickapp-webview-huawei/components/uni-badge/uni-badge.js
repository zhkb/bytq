(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["components/uni-badge/uni-badge"],{"0290":function(t,e,n){"use strict";var u=n("c119"),i=n.n(u);i.a},"438e":function(t,e,n){"use strict";Object.defineProperty(e,"__esModule",{value:!0}),e.default=void 0;var u={name:"UniBadge",props:{type:{type:String,default:"default"},inverted:{type:Boolean,default:!1},text:{type:[String,Number],default:""},size:{type:String,default:"normal"}},data:function(){return{badgeStyle:""}},watch:{text:function(){this.setStyle()}},mounted:function(){this.setStyle()},methods:{setStyle:function(){this.badgeStyle="width: ".concat(8*String(this.text).length+12,"px")},onClick:function(){this.$emit("click")}}};e.default=u},"4e8e":function(t,e,n){"use strict";var u;n.d(e,"b",(function(){return i})),n.d(e,"c",(function(){return a})),n.d(e,"a",(function(){return u}));var i=function(){var t=this,e=t.$createElement;t._self._c},a=[]},"8a22":function(t,e,n){"use strict";n.r(e);var u=n("4e8e"),i=n("d36b");for(var a in i)"default"!==a&&function(t){n.d(e,t,(function(){return i[t]}))}(a);n("0290");var r,c=n("f0c5"),o=Object(c["a"])(i["default"],u["b"],u["c"],!1,null,"f952f9e2",null,!1,u["a"],r);e["default"]=o.exports},c119:function(t,e,n){},d36b:function(t,e,n){"use strict";n.r(e);var u=n("438e"),i=n.n(u);for(var a in u)"default"!==a&&function(t){n.d(e,t,(function(){return u[t]}))}(a);e["default"]=i.a}}]);
;(global["webpackJsonp"] = global["webpackJsonp"] || []).push([
    'components/uni-badge/uni-badge-create-component',
    {
        'components/uni-badge/uni-badge-create-component':(function(module, exports, __webpack_require__){
            __webpack_require__('8adf')['createComponent'](__webpack_require__("8a22"))
        })
    },
    [['components/uni-badge/uni-badge-create-component']]
]);
