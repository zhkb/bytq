<template>
	<view>
		<uni-nav-bar leftImage="../../../static/bytq_logo.png" title="澳柯玛冷链仓储系统" ></uni-nav-bar>
		<view>
			<view class="uni-flex uni-row">
				<view  class="text">产品名称:</view>
				<input  class="zh-text" type="text" v-model="PorName" disabled  style="-webkit-flex: 1;flex: 1;"/>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">产品批次:</view>
				 <picker mode="date" :value="PickCode" :start="startDate" :end="endDate" @change="bindDateChange">
				    <input   class="zh-text"  type="text" disabled v-model="PickCode" style="-webkit-flex: 1;flex: 1;"/>
				 </picker>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">实际数量:</view>
				<uni-number-box  :min="0" :max="999999" style="-webkit-flex: 1;flex: 1; " :value="ActualQty" @change="bindChange" ></uni-number-box>
				<!-- <input   class="zh-text"  type="text" v-model="ActualQty" style="-webkit-flex: 1;flex: 1;"/> -->
				
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">货位:</view>
				<picker mode="selector" :value="StoreCode"  @change="bindStoreChange" :range="LocalList" range-key="Node_Path_Name">
				   <input   class="zh-text"  type="text" disabled v-model="StoreCode" style="-webkit-flex: 1;flex: 1;"/>
				</picker>
				
			</view>
			
			
		</view>
		<view class="uni-bottom-view">
			<view class="uni-flex uni-row">
				<button class="flex-item" type="primary" size="mini" @click="SavePick">保存</button>
				<button class="flex-item" type="primary" size="mini" @click="ResetPick">重置</button>
				<button class="flex-item" type="primary" size="mini" @click="BackPick">退出</button>
			</view>
		</view>
	</view>
</template>

<script>
	import uniNumberBox from "@/components/uni-number-box/uni-number-box.vue"
	var token;
	export default {
		components: {uniNumberBox},
		onLoad() {
			console.log("aaaaa")
			this.getLocalList()
			console.log(this.entity)
		   // this.entity.Part_Name = "123"
		},
		data() {
			token = uni.getStorageSync("userInfo").ApiToken;
			return {
				LocalList:[],
				entity:getApp().globalData.PickEntity,
				PorName:getApp().globalData.PickEntity.Part_Name,
				PickCode:getApp().globalData.PickEntity.Product_Date,
				ActualQty:getApp().globalData.PickEntity.Qty,
				StoreCode:getApp().globalData.PickEntity.Location_Id,
				startDate:'1999-01-01',
				endDate:'2100-01-01'
			}
		},
		
		methods: {
			getLocalList(){
				//console.log("aaaaa")
				uni.request({
					url: this.web_url+'/ReportList/GetLocationList',
					data:{
						BusinessId:getApp().globalData.SelType,
						PostId:"1",
						PartId:getApp().globalData.PickEntity.Part_Id,
						WarehouseId:getApp().globalData.Warehouse_Id,
						Token:token
					},
					method:"GET",
					success: data => {
						if (data.statusCode == 200) {
							console.log(data);
							this.LocalList = data.data.Data;
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
			},	
			SavePick(){
				getApp().globalData.PickEntity.Product_Date = this.PickCode
				console.log(this.ActualQty)
				getApp().globalData.PickEntity.Qty = this.ActualQty
				getApp().globalData.PickEntity.Location_Id = this.StoreCode
				uni.$emit('SavePick', '1');
				uni.navigateBack({
					//getApp().globalData.SaveFlag = true
				})
			},
			BackPick(){
				uni.$emit('SavePick', '0');
				uni.navigateBack({
					//getApp().globalData.SaveFlag = false
				})
			},
			ResetPick(){
			
				this.PickCode=getApp().globalData.PickEntity.Product_Date
				this.ActualQty=getApp().globalData.PickEntity.Qty
				this.StoreCode=getApp().globalData.PickEntity.Location_Id
			},
			bindDateChange: function(e) {
				
			    this.PickCode = e.target.value
			 },
			bindChange(value){
				this.ActualQty = value
			},
			bindStoreChange: function(e) {
				this.StoreCode = this.LocalList[e.detail.value].Location_Id
			}
			
		}
	}
</script>

<style>

	.flex-item {
		width: 30%;
		height: 75rpx;
		text-align: center;
		line-height: 75rpx;
	}
	
	.flex-item-V {
		width: 100%;
		height: 150rpx;
		text-align: center;
		line-height: 150rpx;
	}
	
	.text {
		margin: 15rpx 10rpx;
		padding: 0 20rpx;
		background-color: #8F8F94;
		height: 70rpx;
		line-height: 70rpx;
		text-align: center;
		color: #000000;
		font-size: 30rpx;
	}
	.button-text{
		margin: 15rpx 10rpx;
		padding: 0 20rpx;
		background-color: #ebebeb;
		height: 70rpx;
		line-height: 70rpx;
		text-align: center;
		color: #777;
		font-size: 26rpx;
	}
	.zh-text{
		margin: 15rpx 10rpx;
		padding: 0 20rpx;
		background-color: #ebebeb;
		height: 70rpx;
		line-height: 70rpx;
		text-align: left;
		color: #777;
		font-size: 30rpx;
	
	}
	.uni-bottom-view{
		padding-top: 30rpx;
	}
	.desc {
		/* text-indent: 40rpx; */
	}
</style>
