(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/Detail/PickDetail"],{"0bf4":function(t,n,e){"use strict";var o=e("3878"),i=e.n(o);i.a},"346c":function(t,n,e){"use strict";e.d(n,"b",(function(){return i})),e.d(n,"c",(function(){return c})),e.d(n,"a",(function(){return o}));var o={uniNavBar:function(){return e.e("components/uni-nav-bar/uni-nav-bar").then(e.bind(null,"9f0d"))},uniSegmentedControl:function(){return e.e("components/uni-segmented-control/uni-segmented-control").then(e.bind(null,"8185"))},uniCollapse:function(){return e.e("components/uni-collapse/uni-collapse").then(e.bind(null,"54c5"))},uniCollapseItem:function(){return e.e("components/uni-collapse-item/uni-collapse-item").then(e.bind(null,"ca61"))},uniList:function(){return e.e("components/uni-list/uni-list").then(e.bind(null,"82e2"))},uniListItem:function(){return e.e("components/uni-list-item/uni-list-item").then(e.bind(null,"c19e"))},uniPopup:function(){return Promise.all([e.e("common/vendor"),e.e("components/uni-popup/uni-popup")]).then(e.bind(null,"ff31"))}},i=function(){var t=this,n=t.$createElement;t._self._c},c=[]},3878:function(t,n,e){},"61d8":function(t,n,e){"use strict";e.r(n);var o=e("b1a7"),i=e.n(o);for(var c in o)"default"!==c&&function(t){e.d(n,t,(function(){return o[t]}))}(c);n["default"]=i.a},a52b:function(t,n,e){"use strict";e.r(n);var o=e("346c"),i=e("61d8");for(var c in i)"default"!==c&&function(t){e.d(n,t,(function(){return i[t]}))}(c);e("0bf4");var a,s=e("f0c5"),u=Object(s["a"])(i["default"],o["b"],o["c"],!1,null,"7f0758a3",null,!1,o["a"],a);n["default"]=u.exports},b1a7:function(t,n,e){"use strict";(function(t){Object.defineProperty(n,"__esModule",{value:!0}),n.default=void 0;var o,i=function(){e.e("components/uni-collapse/uni-collapse").then(function(){return resolve(e("54c5"))}.bind(null,e)).catch(e.oe)},c=function(){e.e("components/uni-collapse-item/uni-collapse-item").then(function(){return resolve(e("ca61"))}.bind(null,e)).catch(e.oe)},a=function(){Promise.all([e.e("common/vendor"),e.e("components/uni-popup/uni-popup")]).then(function(){return resolve(e("ff31"))}.bind(null,e)).catch(e.oe)},s=function(){e.e("components/uni-popup/uni-popup-message").then(function(){return resolve(e("9bf6"))}.bind(null,e)).catch(e.oe)},u=function(){e.e("components/uni-popup/uni-popup-dialog").then(function(){return resolve(e("4a32"))}.bind(null,e)).catch(e.oe)},l={components:{uniCollapse:i,uniCollapseItem:c,uniPopup:a,uniPopupMessage:s,uniPopupDialog:u},onLoad:function(t){this.getWindowSize(),console.log(t),this.$data.stackid=t.Id,this.getList()},onUnload:function(){t.$off("SavePick")},data:function(){return o=t.getStorageSync("userInfo").ApiToken,{items:["基本明细","批次明细"],current:0,stackid:"",AcQtyIndex:0,AcQty:0,message:"",dataType:getApp().globalData.SelType,maindata:{},content:"",winSize:{},showShade:!1,showPop:!1,popButton:["新建批次","编辑批次","删除批次"],popStyle:"",pickerUserIndex:-1,selIndex:0}},methods:{onClickItem:function(t){this.current!==t.currentIndex&&(this.current=t.currentIndex)},Submit:function(){},AddBatch:function(t){this.$data.AcQtyIndex=t,this.$data.maindata.StockRecordList[t].Id="0",this.SaveForm()},Back:function(){this.content="确定回退到草稿状态吗？",this.$refs.popupBackDialog.open()},getList:function(){var n=this;console.log(o),console.log(this.$data.stackid),t.request({url:"http://192.168.1.26:5001/StockActivityIn/GetForm",data:{orderId:this.$data.stackid},method:"GET",success:function(t){console.log(t),200==t.statusCode&&(console.log(t),n.maindata=t.data.Data)},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},openMesPuop:function(t){"2"==this.dataType?(console.log(t),this.$data.AcQtyIndex=t,this.$data.AcQty=this.$data.maindata.StockRecordList[t].Qty,this.$refs.dialogInput.open()):(this.message="不能修改明细数量",this.$refs.popupMessage.open())},SaveForm:function(){var n=this,e=this.$data.maindata;e.Token=o,console.log(e),t.request({url:"http://192.168.1.26:5001/StockActivityIn/SaveForm",data:e,method:"POST",success:function(t){200==t.statusCode&&(console.log(t),n.getList())},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},dialogInputConfirm:function(n,e){console.log(e),/(^[0-9]\d*$)/.test(e)?(console.log(e),this.$data.maindata.StockRecordList[this.$data.AcQtyIndex].Qty=e,this.SaveForm(),n()):(t.showLoading({title:"输入的内容不是数字"}),setTimeout((function(){t.hideLoading()}),1e3))},dialogConfirm:function(t,n){console.log("点击确认"),console.log("1132321"),console.log(this.selIndex),this.$data.maindata.StockRecordList[this.selIndex].Qty=0,this.SaveForm(),t()},dialogClose:function(t){t()},dialogBackConfirm:function(n,e){console.log("点击确认"),n(),t.request({url:"http://192.168.1.26:5001/StockActivityIn/StockActivityInApprove",data:{Stock_Activity_Id:this.$data.stackid,Is_forward:!1,Token:o},method:"GET",success:function(n){200==n.statusCode&&(console.log(n),"1"==n.data.Tag&&t.navigateBack({success:function(){beforePage.onLoad()}}))},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},dialogBackClose:function(t){t()},listTap:function(){this.showShade||console.log("列表触摸事件触发")},getListData:function(){for(var t=[],n=0;n<20;n++)t.push({name:"第".concat(n+1,"个用户"),time:"5月20日",info:"这是第".concat(n+1,"个用户的聊天信息")});this.userList=t},getWindowSize:function(){var n=this;t.getSystemInfo({success:function(t){n.winSize={witdh:t.windowWidth,height:t.windowHeight}}})},onLongPress:function(t){var n=this,e=[t.touches[0],"",t.currentTarget.dataset.index],o=e[0],i=e[1],c=e[2];i=o.clientY>this.winSize.height/2?"bottom:".concat(this.winSize.height-o.clientY,"px;"):"top:".concat(o.clientY,"px;"),o.clientX>this.winSize.witdh/2?i+="right:".concat(this.winSize.witdh-o.clientX,"px"):i+="left:".concat(o.clientX,"px"),this.popStyle=i,this.pickerUserIndex=Number(c),this.showShade=!0,this.$nextTick((function(){setTimeout((function(){n.showPop=!0}),10)}))},hidePop:function(){var t=this;this.showPop=!1,this.pickerUserIndex=-1,setTimeout((function(){t.showShade=!1}),250)},pickerMenu:function(n){var e=Number(n.currentTarget.dataset.index);console.log("第".concat(this.pickerUserIndex+1,"个用户,第").concat(e+1,"个按钮"));var o=this;0==e?this.AddBatch(this.pickerUserIndex):1==e?(getApp().globalData.PickEntity=this.maindata.StockRecordList[this.pickerUserIndex],t.navigateTo({url:"./PopDetail"}),t.$on("SavePick",(function(t){"1"==t&&(console.log("8888"),o.SaveForm())}))):2==e&&(this.content="确定删除批次【"+this.maindata.StockRecordList[this.pickerUserIndex].Part_Name+"]吗？",console.log(this.pickerUserIndex),this.$data.selIndex=this.pickerUserIndex,this.$refs.popupDialog.open()),this.hidePop()}}};n.default=l}).call(this,e("8adf")["default"])},d193:function(t,n,e){"use strict";(function(t){e("588f");o(e("66fd"));var n=o(e("a52b"));function o(t){return t&&t.__esModule?t:{default:t}}t(n.default)}).call(this,e("8adf")["createPage"])}},[["d193","common/runtime","common/vendor"]]]);