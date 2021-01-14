<template>
	<view>
		<uni-nav-bar leftImage="../../../static/bytq_logo.png" title="澳柯玛冷链仓储系统" ></uni-nav-bar>
		<view>
			<view class="uni-flex uni-row" >
				<label class="de-label-show">单 据 号:</label>
				<input class="de-input-show" type="text" disabled v-model="maindata.Stock_Activity_No"></input>
				<label class="de-label-show">业务单号:</label>
				<input class="de-input-show" type="text" disabled v-model="maindata.Bill_No"></input>
			</view>
		</view>
		<view >
			<view class="uni-flex uni-row">
				<label class="de-label-show">业务类别:</label>
				<input class="de-input-show" type="text" disabled v-model="maindata.Bill_Class_Name"></input>
				<label class="de-label-show">单据状态:</label>
				<input class="de-input-show" type="text" disabled v-model="maindata.Status_Name"></input>
			</view>
		</view>
		<view class="uni-padding-wrap uni-common-mt">
			<uni-segmented-control :current="current" :values="items" style-type="button" active-color="#007aff" @clickItem="onClickItem" />
		</view>

		<view class="content">
			<view v-if="current === 0" >
				<view v-for="(item, index) in maindata.StockDetailList" :key="index">
					<uni-collapse ref="add" class="warp" >
						<uni-collapse-item :title="item.Part_Name" :desc="item.Qty+''">
							<uni-list >
								<uni-list-item  title="品号" :note="item.Part_No"></uni-list-item>
							</uni-list>
							<uni-list>
								<uni-list-item  title="品名" :note="'产品'+item.Part_Name"></uni-list-item>
							</uni-list>
							<uni-list>
								<uni-list-item  title="规格型号" :note="item.Spection"></uni-list-item>
							</uni-list>
							<uni-list>
								<uni-list-item  title="订单数量" :note="item.Order_Qty+''"></uni-list-item>
							</uni-list>
							<uni-list >
								<uni-list-item  title="实际数量" :note="item.Qty+''"></uni-list-item>
							</uni-list>
						</uni-collapse-item>
					</uni-collapse>
				</view>
			</view>
			<view v-if="current === 1">
				<view class="list">
					<view class="flex_col"  :class="{'active':pickerUserIndex==index}" @tap="listTap" v-for="(item,index) in maindata.StockRecordList"
					 :key="index" :data-index="index">
						<view class="flex_grow">
							<view class="flex_col">
								<view class="flex_grow">{{item.Part_Name}}</view>
								<view class="time">{{item.Product_Date}}</view>
							</view>
							<view class="info">{{item.Part_No}},{{item.Spection}},{{item.Qty}}</view>
						</view>
					</view>
				</view>
				
			</view>
			<view v-if="current === 2">
			
				<view style="padding-top: 10rpx;">
					<uni-list >
						<template v-for="(item,index) in maindata.StockScanList">
							<view>
								<uni-list-item :title="item.Bar_Code"/>
							</view>
						</template>
					</uni-list>
					<!-- <uni-pagination title="数据展示" show-icon="true" :total="total" :current="current" @change="change"></uni-pagination> -->
					
				</view>
			</view>
			
			
		</view>
		<uni-popup id="popupMessage" ref="popupMessage" type="message">
			<uni-popup-message type="success" :message="message" :duration="2000"></uni-popup-message>
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
		},
		 
		onUnload() {  
		    // 移除监听事件  
		        uni.$off('SavePick');  
		},
		data() {
			// dataType = getApp().globalData.SelType;
			token = uni.getStorageSync("userInfo").ApiToken;
			return {
				items: ['基本明细', '批次明细','扫码明细'],
				current: 0,
				stackid:"",
				AcQtyIndex:0,//明细队列选择序号
				AcQty:0,
				message:"",
				dataType:getApp().globalData.SelType,
				maindata:{},
				barcode:"RK1-10101001-20201201",
				operid:1,
				opername:"增加",
				content:"",
				/* 窗口尺寸 */
				winSize: {},
				/* 显示遮罩 */
				showShade: false,
				/* 显示操作弹窗 */
				showPop: false,
				/* 弹窗按钮列表 */
				popButton: ["新建批次", "编辑批次", "删除批次"],
				/* 弹窗定位样式 */
				popStyle: "",
				/* 选择的用户下标 */
				pickerUserIndex: -1,
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
			
			Back(){
				this.content = "确定回退到草稿状态吗？";
				this.$refs.popupBackDialog.open()
			},
			
			getList() {
			    console.log(token)
				console.log(this.$data.stackid)
				uni.request({
					url: this.web_url+'/StockActivityOut/GetForm',
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
					url: this.web_url+'/StockActivityOut/SaveForm',
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
					 //this.$data.maindata.StockRecordList[this.pickerUserIndex].BaseIsDelete = "1";
					 // console.log("1132321")
					 // console.log(this.selIndex)
					 this.$data.maindata.StockRecordList[this.selIndex].Qty = 0;
					 this.SaveForm()
					 done()
			         // 需要执行 done 才能关闭对话框
			},
			dialogClose(done){
			    done()
			},
			
			dialogBackConfirm(done,value){
			         console.log('点击确认');
					 done()
			         // 需要执行 done 才能关闭对话框
					 uni.request({
					 	url: this.web_url+'/StockActivityOut/StockActivityOutApprove',
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
											beforePage.onLoad(); // 执行上一页的onLoad方法
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
					 done()
			         // 需要执行 done 才能关闭对话框
					 uni.request({
					 	url: this.web_url+'/StockActivityOut/StockActivityOutApprove',
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
											beforePage.onLoad(); // 执行上一页的onLoad方法
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
			
				//console.log("列表触摸事件触发")
			},
			
			/* 获取窗口尺寸 */
			getWindowSize() {
				uni.getSystemInfo({
					success: (res) => {
						this.winSize = {
							"width": res.windowWidth,
							"height": res.windowHeight
						}
					}
				})
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
			width: 20%;
			font-size: 32rpx;
			padding-top: 10rpx;
			text-align: center;
			height: 90%;
			padding-right: 10rpx;
		}
		.de-input-show{
			width: 25%;
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
				color: #333;
				background-color: #fff;
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
