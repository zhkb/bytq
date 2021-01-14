<template>
	<view>
		<uni-nav-bar leftImage="../../../static/bytq_logo.png" title="澳柯玛冷链仓储系统" ></uni-nav-bar>
		<view class="example-body">
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
		<uni-popup id="popupMessage" ref="popupMessage" type="message">
			<uni-popup-message type="success" :message="message" :duration="2000"></uni-popup-message>
		</uni-popup>
		<uni-popup id="dialogInput" ref="dialogInput" type="dialog" >
			<uni-popup-dialog mode="input" title="输入实际数量" :value="AcQty" placeholder="请输入数字" @confirm="dialogInputConfirm"></uni-popup-dialog>
		</uni-popup>
		<uni-popup id="popupDialog" ref="popupDialog" type="dialog" >
			<uni-popup-dialog  title="提示"  :content="content" :before-close="true" @confirm="dialogConfirm" @close="dialogClose"></uni-popup-dialog>
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
			this.$data.stackid = option.Stock_Activity_Id
			this.getList()
		},
		
		data() {
			// dataType = getApp().globalData.SelType;
			token = uni.getStorageSync("userInfo").ApiToken;
			return {
				dataType:getApp().globalData.SelType,//功能区分标志
				message:"",//提示信息
				AcQtyIndex:0,//明细队列选择序号
				AcQty:0,
				maindata:{},//单据信息
				stackid:"",//单据号
				content:""
			}
		},
		methods: {
			onLoad: function (option) { //option为object类型，会序列化上个页面传递的参数
				
				this.$data.stackid = option.Id
				this.getList()
			},
			Submit(){
				//保存数据
				this.SaveDraft();
				this.content = "确定提交单据【"+this.$data.stackid+"]吗？";
				this.$refs.popupDialog.open()
				
			},
			ReSet(){
				getList()
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
						
						if (data.statusCode == 200) {
							console.log(data);
							this.maindata = data.data.Data;
							
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
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
			font-size: 36rpx;
			padding-top: 10rpx;
			text-align: center;
			height: 90%;
			padding-right: 10rpx;
		}
		.de-input-show{
			width: 25%;
			font-size: 36rpx;
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
	
</style>
