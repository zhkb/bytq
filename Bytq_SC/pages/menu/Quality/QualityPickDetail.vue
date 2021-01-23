<template>
	<view>
		<uni-nav-bar leftImage="../../../static/bytq_logo.png" :title="title"></uni-nav-bar>
		
		<view class="uni-padding-wrap uni-common-mt">
			<uni-segmented-control :current="current" :values="items" style-type="button" active-color="#007aff" @clickItem="onClickItem" />
		</view>

		<view class="content">
			<view v-if="current === 0" >
				<view>
					<view class="uni-flex uni-row" >
						<label class="de-label-show">质检单号:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Quality_No"></input>
					</view>
					<view class="uni-flex uni-row" >
						<label class="de-label-show">质检日期:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Quality_Date"></input>
					</view>	
				
					<view class="uni-flex uni-row">
						<label class="de-label-show">质检人员:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Check_Employee_Name"></input>
					</view>
					<view class="uni-flex uni-row">
						<label class="de-label-show">供应商:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Object_Merger_Name"></input>
					</view>
					<view class="uni-flex uni-row">
						<label class="de-label-show">产品编号:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Part_No"></input>
					</view>
					<view class="uni-flex uni-row">
						<label class="de-label-show">质检产品:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Part_Name"></input>
					</view>
					<view class="uni-flex uni-row">
						<label class="de-label-show">货品类型:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Product_Line_Name"></input>
					</view>
					<view class="uni-flex uni-row">
						<label class="de-label-show">报检数量:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Apply_Qty"></input>
					</view>
					<view class="uni-flex uni-row">
						<label class="de-label-show">合格数量:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Qualified_Qty"></input>
					</view>
					
					<view class="uni-flex uni-row">
						<label class="de-label-show">质检结果:</label>
						<picker mode="selector" :value="maindata.Quality_Result_Name"  @change="bindResultChange" :range="LocalList" range-key="Node_Path_Name">
							<input class="de-input-show" type="text" disabled v-model="maindata.Quality_Result_Name"></input>
						</picker>
					</view>
					<view class="uni-flex uni-row">
						<label class="de-label-show">批次日期:</label>
						<input class="de-input-show" type="text"  v-model="maindata.Product_Date" @confirm="SaveForm"></input>
					</view>
					<view class="uni-flex uni-row">
						<label class="de-label-show">仓库:</label>
						<input class="de-input-show" type="text" disabled v-model="maindata.Warehouse_Name"></input>
					</view>
				</view>
				<!-- <view  class="uni-bottom-view">
					<view class="uni-flex uni-row">
						<button class="flex-item" type="primary" size="mini" @click="SaveForm">保存</button>
					
					</view>
				</view> -->
				
			</view>
			<view v-if="current === 1">
				<view>
					<view class="list">
						<view class="flex_col" @longpress="onFirstPress" :class="{'active':FpickerUserIndex==index}" @tap="listTap" v-for="(item,index) in maindata.QualityDetailList"
						 :key="index" :data-index="index">
							<view class="flex_grow">
								<view class="flex_col">
									<view class="flex_grow">{{item.Bill_No}}</view>
									<view class="time">{{item.Product_Date}}</view>
								</view>
								<view class="info">{{item.Quality_Detail_Id}},{{item.Part_Name}},{{item.Qty}}</view>
							</view>
						</view>
					</view>
					
				</view>
				
			</view>
			<view v-if="current === 2" >
				<view>
					<view class="list">
						<view class="flex_col" @longpress="onLongPress" :class="{'active':SpickerUserIndex==index}" @tap="listTap" v-for="(item,index) in maindata.QualityItemList"
						 :key="index" :data-index="index">
							<view class="flex_grow">
								<view class="flex_col">
									<view class="flex_grow">{{item.Item_Name}}</view>
									<view class="time">{{item.Result_Desc}}</view>
								</view>
								<view class="info">{{item.Item_Desc}}</view>
							</view>
						</view>
					</view>
				</view>
				
			</view>
			<view  class="uni-bottom-view">
				<view class="uni-flex uni-row">
					<button class="flex-item" type="primary" size="mini" @click="Submit">提交</button>
					<button class="flex-item" type="primary" size="mini" @click="Back">回退</button>
				</view>
			</view>
		</view>
	  
		<view class="shade" v-show="FshowShade" @tap="FhidePop">
			<view class="pop" :style="FpopStyle" :class="{'show':FshowPop}">
				<view v-for="(item,index) in FpopButton" :key="index" @tap="FpickerMenu" :data-index="index">{{item}}</view>
			</view>
		</view>
		<view class="shade" v-show="SshowShade" @tap="ShidePop">
			<view class="pop" :style="SpopStyle" :class="{'show':SshowPop}">
				<view v-for="(item,index) in SpopButton" :key="index" @tap="SpickerMenu" :data-index="index">{{item}}</view>
			</view>
		</view>
		
		<uni-popup id="popupMessage" ref="popupMessage" type="message">
			<uni-popup-message type="success" :message="message" :duration="2000"></uni-popup-message>
		</uni-popup>
		<uni-popup id="dialogInput" ref="dialogInput" type="dialog" >
			<uni-popup-dialog mode="input" title="输入实际数量" :value="AcQty" placeholder="请输入数字" @confirm="dialogInputConfirm"></uni-popup-dialog>
		</uni-popup>
		<uni-popup id="popupDialog" ref="popupDialog" type="dialog" >
			<uni-popup-dialog  title="提示"  :content="content" :before-close="true" @confirm="dialogConfirm" @close="dialogClose"></uni-popup-dialog>
		</uni-popup>
		<uni-popup id="popupBackDialog" ref="popupBackDialog" type="dialog" >
			<uni-popup-dialog  title="提示"  :content="content" :before-close="true" @confirm="dialogBackConfirm" @close="dialogBackClose"></uni-popup-dialog>
		</uni-popup>
		<uni-popup id="popupSubmitDialog" ref="popupSubmitDialog" type="dialog" >
			<uni-popup-dialog  title="提示"  :content="content" :before-close="true" @confirm="dialogSubmitConfirm" @close="dialogSubmitClose"></uni-popup-dialog>
		</uni-popup>
		
		
	</view>
	
</template>

<script>
	import uniCollapse from '@/components/uni-collapse/uni-collapse.vue'
	import uniCollapseItem from '@/components/uni-collapse-item/uni-collapse-item.vue'
	import uniPopup from '@/components/uni-popup/uni-popup.vue'
	import uniPopupMessage from '@/components/uni-popup/uni-popup-message.vue'
	import uniPopupDialog from '@/components/uni-popup/uni-popup-dialog.vue'
	var token;
	export default {
		components: {
			uniCollapse,
			uniCollapseItem,
			uniPopup,
			uniPopupMessage,
			uniPopupDialog
		},
		onLoad: function (option) { //option为object类型，会序列化上个页面传递的参数
		    this.getWindowSize();
			console.log(option)
			this.$data.stackid = option.Id
			this.getList()
			this.getFMenuAuthList()
			this.getSMenuAuthList()
		},
		 
		onUnload() {  
		    // 移除监听事件  
		        uni.$off('SavePick');  
		},
		data() {
			// dataType = getApp().globalData.SelType;
			token = uni.getStorageSync("userInfo").ApiToken;
			return {
				items: ['基本明细','批次明细','质检项目'],
				title:getApp().globalData.SelName,
				current: 0,
				stackid:"",
				AcQtyIndex:0,//明细队列选择序号
				AcQty:0,
				message:"",
				dataType:getApp().globalData.SelType,
				maindata:{},
				content:"",
				/* 窗口尺寸 */
				winSize: {},
				/* 显示遮罩 */
				FshowShade: false,
				SshowShade: false,
				/* 显示操作弹窗 */
				FshowPop: false,
				SshowPop: false,
				/* 弹窗按钮列表 */
				FpopButton: ["新建批次", "编辑批次", "删除批次"],
				SpopButton: ["新建批次", "编辑批次", "删除批次"],
				/* 弹窗定位样式 */
				FpopStyle: "",
				SpopStyle: "",
				/* 选择的用户下标 */
				FpickerUserIndex: -1,
				SpickerUserIndex: -1,
				selIndex:0
			}
		},
		methods: {
			onClickItem(e) {
				if (this.current !== e.currentIndex) {
					this.current = e.currentIndex
				}
			},
			
			Submit(){
				this.content = "确定提交单据【"+this.$data.stackid+"】到已完成状态吗？";
				this.$refs.popupSubmitDialog.open()
			},
			AddFBatch(str){
				//this.$data.AcQtyIndex = str;
				this.$data.maindata.QualityItemList[str].Id = "0";
				console.log(this.$data.maindata)
				this.SaveForm()
			},
			AddSBatch(str){
				//this.$data.AcQtyIndex = str;
				
			    this.$data.maindata.QualityDetailList[str].Id = "0";
				console.log(this.$data.maindata)
				this.SaveForm()
			},
			Back(){
				this.content = "确定回退到草稿状态吗？";
				this.$refs.popupBackDialog.open()
			},
			
			getList() {
			    console.log(token)
				console.log(this.$data.stackid)
				uni.request({
					url: this.web_url+'/StockQuality/GetForm',
					data: {
						orderId:this.$data.stackid
					},
					method:"GET",
					success: data => {
						console.log(data)
						if (data.statusCode == 200) {
							console.log(data);
							this.maindata = data.data.Data;
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
			},
			openMesPuop(str){
				if(this.dataType == "2"){
					console.log(str)
					this.$data.AcQtyIndex = str
					this.$data.AcQty = this.$data.maindata.StockRecordList[str].Qty
					this.$refs.dialogInput.open()
					
				}else{
					this.message = "不能修改明细数量"
					this.$refs.popupMessage.open()
				}
			},	
			SaveForm(){
				var mdata = this.$data.maindata
				mdata.Token = token
				console.log(mdata)
				uni.request({
					url: this.web_url+'/StockQuality/SaveForm',
					data:mdata,
					method:"POST",
					success: data => {
						if (data.statusCode == 200) {
							console.log(data);
							this.getList()
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
			},
			dialogInputConfirm(done, val) {
				console.log(val)
				if(/(^[0-9]\d*$)/.test(val)){
					console.log(val)
					this.$data.maindata.StockRecordList[this.$data.AcQtyIndex].Qty = val
					this.SaveForm()
					done()
				}
				else{
					uni.showLoading({
						title: '输入的内容不是数字'
					})
					setTimeout(() => {
						uni.hideLoading()
						// 关闭窗口后，恢复默认内容
					}, 1000)
				}
			},
			dialogConfirm(done,value){
			         console.log('点击确认');
					 this.$data.maindata.QualityDetailList[this.selIndex].Qty = 0;
					 this.SaveForm()
					 done()
			         // 需要执行 done 才能关闭对话框
			},
			dialogClose(done){
			    done()
			},
			
			dialogBackConfirm(done,value){
			         console.log('点击确认');
					 console.log(this.$data.stackid)
					 console.log(token)
					 done()
			         // 需要执行 done 才能关闭对话框
					 uni.request({
					 	url: this.web_url+'/StockQuality/StockActivityInApprove',
					 	data:{
							Stock_Activity_Id:this.$data.stackid,
							Is_forward:false,
							Token:token
						},
					 	method:"GET",
					 	success: data => {
					 		if (data.statusCode == 200) {
					 			console.log(data);
								if(data.data.Tag =="1"){
									uni.navigateBack({
										success: function() {
											// beforePage.onLoad(); // 执行上一页的onLoad方法
										}
									})
								}
					 		}
					 	},
					 	fail: (data, code) => {
					 		console.log('fail' + JSON.stringify(data));
					 	}
					 });
			         
					
			},
			dialogBackClose(done){
			    done()
			},
			dialogSubmitConfirm(done,value){
			         console.log('点击确认');
					 console.log(this.$data.stackid)
					 done()
			         // 需要执行 done 才能关闭对话框
					 uni.request({
					 	url: this.web_url+'/StockQuality/StockActivityInApprove',
					 	data:{
							Stock_Activity_Id:this.$data.stackid,
							Is_forward:true,
							Token:token
						},
					 	method:"GET",
					 	success: data => {
					 		if (data.statusCode == 200) {
					 			console.log(data);
								if(data.data.Tag =="1"){
									uni.navigateBack({
										success: function() {
											// beforePage.onLoad(); // 执行上一页的onLoad方法
										}
									})
								}else{
									uni.showToast({
										title: data.data.Description,
										icon: "none",
										mask: true,
										duration: 2000
									});
								}
					 		}
					 	},
					 	fail: (data, code) => {
					 		console.log('fail' + JSON.stringify(data));
					 	}
					 });
			         
					
			},
			dialogSubmitClose(done){
			    done()
			},
			/* 列表触摸事件 */
			listTap() {
				/* 因弹出遮罩问题，所以需要在遮罩弹出的情况下阻止列表事件的触发 */
				if (this.showShade) {
					return;
				}
			
				console.log("列表触摸事件触发")
			},
			/* 获取列表数据 */
			getListData() {
				let list = [];
				for (let i = 0; i < 20; i++) {
					list.push({
						"name": `第${i+1}个用户`,
						"time": '5月20日',
						"info": `这是第${i+1}个用户的聊天信息`
					})
				}
				this.userList = list;
			},
			/* 获取窗口尺寸 */
			getWindowSize() {
				uni.getSystemInfo({
					success: (res) => {
						this.winSize = {
							"widh": res.windowWidth,
							"height": res.windowHeight
						}
					}
				})
			},
			getFMenuAuthList(){
				uni.request({
					url: this.web_url+'/ReportList/GetMenuAuthList',
					data:{
						BusinessId:this.$data.dataType,
						Token:token,
						TypeId:1
					},
					method:"GET",
					success: data => {
						console.log("权限列表")
						console.log(data)
						this.$data.FpopButton=[] 
						var sda = data.data.Data
						console.log(sda.length)
						
						for (var i = 0; i < sda.length; i++) {
							this.$data.FpopButton.push(sda[i].Auth_Name);
						}
						
						
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
				
			},
			getSMenuAuthList(){
				uni.request({
					url: this.web_url+'/ReportList/GetMenuAuthList',
					data:{
						BusinessId:this.$data.dataType,
						Token:token,
						TypeId:2
					},
					method:"GET",
					success: data => {
						console.log("权限列表")
						console.log(data)
						this.$data.SpopButton=[]
						var sda = data.data.Data
						console.log(sda)
						for (var i = 0; i < sda.length; i++) {
							this.$data.SpopButton.push(sda[i].Auth_Name);
						}
						
						
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
				
			},
			onFirstPress(e){
				// if(this.$data.maindata.Status_Id=="1"){
					console.log(this.$data.FpopButton)
					let [touches, style, index] = [e.touches[0], "", e.currentTarget.dataset.index];
								
					/* 因 非H5端不兼容 style 属性绑定 Object ，所以拼接字符 */
					if (touches.clientY > (this.winSize.height / 2)) {
						style = `bottom:${this.winSize.height-touches.clientY}px;`;
					} else {
						style = `top:${touches.clientY}px;`;
					}
					if (touches.clientX > (this.winSize.witdh / 2)) {
						style += `right:${this.winSize.width-touches.clientX}px`;
					} else {
						style += `left:${touches.clientX}px`;
					}
								
					this.FpopStyle = style;
					this.FpickerUserIndex = Number(index);
					this.FshowShade = true;
					this.$nextTick(() => {
						setTimeout(() => {
							this.FshowPop = true;
						}, 10);
					});
				// }
			},
			/* 长按监听 */
			onLongPress(e) {
				console.log(this.$data.SpopButton)
				let [touches, style, index] = [e.touches[0], "", e.currentTarget.dataset.index];
							
				/* 因 非H5端不兼容 style 属性绑定 Object ，所以拼接字符 */
				if (touches.clientY > (this.winSize.height / 2)) {
					style = `bottom:${this.winSize.height-touches.clientY}px;`;
				} else {
					style = `top:${touches.clientY}px;`;
				}
				if (touches.clientX > (this.winSize.witdh / 2)) {
					style += `right:${this.winSize.width-touches.clientX}px`;
				} else {
					style += `left:${touches.clientX}px`;
				}
							
				this.SpopStyle = style;
				this.SpickerUserIndex = Number(index);
				this.SshowShade = true;
				this.$nextTick(() => {
					setTimeout(() => {
						this.SshowPop = true;
					}, 10);
				});				
					
			},
			/* 隐藏弹窗 */
			FhidePop() {
				this.FshowPop = false;
				this.FpickerUserIndex = -1;
				setTimeout(() => {
					this.FshowShade = false;
				}, 250);
			},
			ShidePop() {
				this.SshowPop = false;
				this.SpickerUserIndex = -1;
				setTimeout(() => {
					this.SshowShade = false;
				}, 250);
			},
			/* 选择菜单 */
			FpickerMenu(e) {
				let index = Number(e.currentTarget.dataset.index);
				console.log(`第${this.FpickerUserIndex+1}个用户,第${index+1}个按钮`);
				var vthis = this;
				// 在这里开启你的代码秀
				var menustr = this.$data.FpopButton[index]
			    if(menustr == '新增编辑'){//新建
					this.AddFBatch(this.FpickerUserIndex)
					console.log(menustr)
					
				}else if(menustr == '修改编辑'){//编辑
					
					console.log(menustr)
					getApp().globalData.PickQuaEntity = this.maindata.QualityDetailList[this.FpickerUserIndex];
					var find = this.FpickerUserIndex
					uni.navigateTo({
						url:'./QualityModifyDetail'
					});
					uni.$on('SavePick',function(data){
						
						if(data=='1'){
							//vthis.SaveForm()
							
						}else{
							
						}
					})
							
				}else if(menustr == ' 删  除 '){//删除
					this.content = "确定删除批次【"+ this.maindata.QualityDetailList[this.FpickerUserIndex].Part_Name+"]吗？";

					this.$data.selIndex = this.FpickerUserIndex
					this.$refs.popupDialog.open()
					console.log(menustr)
				}
				
				/* 
				 因为隐藏弹窗方法中会将当前选择的用户下标还原为-1,
				 如果行的菜单方法存在异步情况，请在隐藏之前将该值保存，或通过参数传入异步函数中
				 */
				this.FhidePop();
			},
			/* 选择菜单 */
			SpickerMenu(e) {
				let index = Number(e.currentTarget.dataset.index);
				console.log(`第${this.SpickerUserIndex+1}个用户,第${index+1}个按钮`);
				var vthis = this;
				// 在这里开启你的代码秀
				var menustr = this.$data.SpopButton[index]
			    if(menustr == '新增编辑'){//新建
					// this.AddBatch(this.pickerUserIndex)
					console.log(menustr)
					
				}else if(menustr == '修改编辑'){//编辑
				
					console.log(menustr)
					getApp().globalData.PickQuaEntity = this.maindata.QualityItemList[this.SpickerUserIndex];
					uni.navigateTo({
						url:'./QualityModifyDetail'
					});
					
							
				}else if(menustr == ' 删  除 '){//删除
					// this.content = "确定删除批次【"+ this.maindata.StockRecordList[this.pickerUserIndex].Part_Name+"]吗？";
					// // this.pickerUserIndex = this.
					// console.log(this.pickerUserIndex)
					// this.$data.selIndex = this.pickerUserIndex
					// this.$refs.popupDialog.open()
					console.log(menustr)
				}
				
				/* 
				 因为隐藏弹窗方法中会将当前选择的用户下标还原为-1,
				 如果行的菜单方法存在异步情况，请在隐藏之前将该值保存，或通过参数传入异步函数中
				 */
				this.ShidePop();
			}
			
		}
	}
</script>

<style lang="scss" scoped>
	@import '@/uni.scss';
		.uni-padding-wrap {
			padding-bottom: 0px;
			
		}
		.uni-common-mt {
			margin-top: 10px;
		}
		.uni-bottom-view{
			
			padding-top: 30rpx;
		}
			
		.content{
			padding-top:10rpx;
			height: 750rpx;
		}
		.content-text {
			font-size: 18px;
			color: #333;
		}
		.flex-item {
			width: 35%;
			height: 100rpx;
			text-align: center;
			line-height: 100rpx;
		}
		.flex-item-show{
			width: 25%;
			height: 100%;
		}
		.de-label-show{
			width: 25%;
			font-size: 32rpx;
			padding-top: 10rpx;
			text-align: center;
			height: 90%;
			padding-right: 10rpx;
		}
		.de-input-show{
			width: 60%;
			font-size: 32rpx;
			margin-top: 20rpx;
			height: 90%;
			background-color: #ebebeb;
			padding-right: 10rpx;
		}
		.ne-input-show{
			width: 75%;
			font-size: 36rpx;
			margin-top: 20rpx;
			height: 90%;
			background-color: #ebebeb;
		}
		.input-show{
			width: 70%;
			height: 100%;
			font-size: 44rpx;
			background-color: #ebebeb;
			text-align: center;
			margin-left: 20rpx;
			margin-top: 5rpx;
		}
			
		.btn-show{
			width: 25%;
			font-size: 32rpx;
			text-align: center;
			height: 80%;
		}
	    .uni-picker-tips {
	    	font-size: 12px;
	    	color: #666;
	    	margin-bottom: 15px;
	    	padding: 0 15px;
	    	/* text-align: right; */
	    }
		/* 列式弹性盒子 */
		.flex_col {
			display: flex;
			flex-direction: row;
			flex-wrap: nowrap;
			justify-content: flex-start;
			align-items: center;
			align-content: center;
		}
		
		/* 弹性盒子弹性容器 */
		.flex_col .flex_grow {
			width: 0;
			-webkit-box-flex: 1;
			-ms-flex-positive: 1;
			flex-grow: 1;
		}
		
		.flex_row .flex_grow {
			-webkit-box-flex: 1;
			-ms-flex-positive: 1;
			flex-grow: 1;
		}
		
		/* 弹性盒子允许换行 */
		.flex_col.flex_wrap {
			-ms-flex-wrap: wrap;
			flex-wrap: wrap;
		}
		
		/* 列表 */
		.list {
			background-color: #fff;
			font-size: 28upx;
			color: #333;
			user-select: none;
			touch-callout: none;
		
			&>view {
				padding: 24upx 30upx;
				position: relative;
		
				&:active,
				&.active {
					background-color: #f3f3f3;
				}
		
				image {
					height: 80upx;
					width: 80upx;
					border-radius: 4px;
					margin-right: 20upx;
				}
		
				&>view {
					line-height: 40upx;
		
					.time,
					.info {
						color: #999;
						font-size: 24upx;
					}
		
					.time {
						width: 150upx;
						text-align: right;
					}
		
					.info {
						overflow: hidden;
						text-overflow: ellipsis;
						white-space: nowrap;
					}
				}
			}
		
			&>view:not(:first-child) {
				margin-top: 1px;
		
				&::after {
					content: '';
					display: block;
					height: 0;
					border-top: #CCC solid 1px;
					width: 620upx;
					position: absolute;
					top: -1px;
					right: 0;
					transform:scaleY(0.5);	/* 1px像素 */
				}
			}
		}
		
		/* 遮罩 */
		.shade {
			position: fixed;
			z-index: 100;
			top: 0;
			right: 0;
			bottom: 0;
			left: 0;
			-webkit-touch-callout: none;
		
			.pop {
				position: fixed;
				z-index: 101;
				width: 200upx;
				box-sizing: border-box;
				font-size: 40rpx;
				text-align: center;
				color: #ffd700;
				background-color: #00007f;
				box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
				line-height: 100upx;
				transition: transform 0.15s ease-in-out 0s;
				user-select: none;
				-webkit-touch-callout: none;
				transform: scale(0, 0);
		
				&.show {
					transform: scale(1, 1);
				}
		
				&>view {
					padding: 0 20upx;
					overflow: hidden;
					text-overflow: ellipsis;
					white-space: nowrap;
					user-select: none;
					-webkit-touch-callout: none;
		
					&:active {
						background-color: #f3f3f3;
					}
				}
			}
		}
</style>
