<template>
	<view>
		<uni-nav-bar leftImage="../../../static/bytq_logo.png" :title="title"></uni-nav-bar>
		<view>
			<view class="uni-flex uni-row">
				<view  class="text">质检项目:</view>
				<input  class="zh-text" type="text" v-model="Item_Name" disabled  style="-webkit-flex: 1;flex: 1;"/>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">质检描述:</view>
				<input  class="zh-text" type="text" v-model="Item_Desc" disabled  style="-webkit-flex: 1;flex: 1;"/>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">质检结果:</view>
				<input  class="zh-text" type="text" v-model="Result_Desc" disabled  style="-webkit-flex: 1;flex: 1;"/>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">质检时间:</view>
				 <picker mode="date" :value="Last_Modify_Date" :start="startDate" :end="endDate" @change="bindDateChange">
				    <input   class="zh-text"  type="text" disabled v-model="Last_Modify_Date" style="-webkit-flex: 1;flex: 1;"/>
				 </picker>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">报检数量:</view>
				<input  class="zh-text" type="text" v-model="Apply_Qty" disabled  style="-webkit-flex: 1;flex: 1;"/>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">合格数量:</view>
				<uni-number-box  :min="0" :max="999999" style="-webkit-flex: 1;flex: 1; " :value="Qty" @change="bindChange" ></uni-number-box>
				<!-- <input   class="zh-text"  type="text" v-model="ActualQty" style="-webkit-flex: 1;flex: 1;"/> -->
				
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">货位名称:</view>
				<picker mode="selector" :value="Location_Id"  @change="bindStoreChange" :range="LocalList" range-key="Node_Path_Name">
				   <input   class="zh-text"  type="text" disabled v-model="Location_Id" style="-webkit-flex: 1;flex: 1;"/>
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
				entity:getApp().globalData.PickQuaEntity,
				Part_Name:getApp().globalData.PickQuaEntity.Part_Name,
				Spection:getApp().globalData.PickQuaEntity.Spection,
				Class_Name:getApp().globalData.PickQuaEntity.Class_Name,
				Product_Date:getApp().globalData.PickQuaEntity.Product_Date,
				Apply_Qty:getApp().globalData.PickQuaEntity.Apply_Qty,
				Qty:getApp().globalData.PickQuaEntity.Qty,
				Location_Id:getApp().globalData.PickQuaEntity.Location_Id,
				Location_Name:getApp().globalData.PickQuaEntity.Location_Name,
				
				
				startDate:'1999-01-01',
				endDate:'2100-01-01',
				title:getApp().globalData.SelName,
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
						PartId:"1",
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
			  
				this.entity=getApp().globalData.PickQuaEntity,
				this.Part_Name=getApp().globalData.PickQuaEntity.Part_Name,
				this.Spection=getApp().globalData.PickQuaEntity.Spection,
				this.Class_Name=getApp().globalData.PickQuaEntity.Class_Name,
				this.Product_Date=getApp().globalData.PickQuaEntity.Product_Date,
				this.Apply_Qty=getApp().globalData.PickQuaEntity.Apply_Qty,
				this.Qty=getApp().globalData.PickQuaEntity.Qty,
				this.Location_Id=getApp().globalData.PickQuaEntity.Location_Id,
				this.Location_Name=getApp().globalData.PickQuaEntity.Location_Name
			},
			bindDateChange: function(e) {
				
			    this.Product_Date = e.target.value
			 },
			bindChange(value){
				this.Qty = value
			},
			bindStoreChange: function(e) {
				this.Location_Id = this.LocalList[e.detail.value].Location_Id
				this.Location_Name = this.LocalList[e.detail.value].Location_Name
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
