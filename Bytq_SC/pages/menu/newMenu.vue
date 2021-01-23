<template>
	<view>
		<uni-nav-bar leftImage="../../static/bytq_logo.png" title="澳柯玛冷链仓储系统" ></uni-nav-bar>
		<view >
			<view>
				<view v-for="(it, ind) in MainMenuList" :key="ind" style="background-color: #AFC18C;">
					<view class="uni-flex uni-row list-flew">
						<view class="uni-flex title-flex" >
							<image src="../../static/backimage.jpg" style="width: 120rpx;height: 140rpx;" mode="aspectFill"></image>
							<view style="font-size: 34rpx;">{{it}}</view>
						</view>
						<view class="uni-flex uni-column note-flex" >
							<view v-for="(item, index) in MenuList" :key="index">
								<view v-if="item.Menu_Type == it" class="text-flex" @click="openPage(index)">
									{{item.Menu_Name}}
								</view>
							</view>
						</view>
					</view>
				</view>
			</view>
		</view>
	</view>
</template>

<script>
	
	import uniCollapse from '@/components/uni-collapse/uni-collapse.vue'
	import UniCollapseItemMe from '@/components/uni-collapse-item/uni-collapse-item-me.vue'
	import uniNavBar from "@/components/uni-nav-bar/uni-nav-bar.vue"
	var token;
	var postid;
	export default {
		components: {
			uniCollapse,
			UniCollapseItemMe
		},
		onLoad() {
			this.getMenuList()
		},
		data() {
			token = uni.getStorageSync("userInfo").ApiToken;
			postid = uni.getStorageSync("userInfo").Post_Id;
			return {
				MainMenuList:['入库相关','出库相关','质检相关'],
				MenuList:[],
				dataType: ""
			}
		},
		methods: {
			openPage(ind){this.MenuList[ind].Menu_Name
				this.dataType= this.MenuList[ind].Menu_Id
				getApp().globalData.SelType = this.MenuList[ind].Menu_Id
				getApp().globalData.SelName = this.MenuList[ind].Menu_Name
				console.log(this.MenuList[ind].View_Path)
				uni.navigateTo({
					url:this.MenuList[ind].View_Path+'?Menu_Name='+this.MenuList[ind].Menu_Name+'&&Menu_No='+this.MenuList[ind].Menu_No,
					fail:function(){
						uni.showToast({
							icon:'none',
							position:'bottom',
							title:"错误：打开界面失败！"
						})
					}
				})
			},
			getMenuList(){
				uni.request({
					url: this.web_url+'/ReportList/GetMenuList',
					data: {
						PostId:postid
					},
					method:'GET',
					success: data => {
						if (data.statusCode == 200) {
							console.log("----------")
							console.log(data);
							this.MenuList = data.data.Data
							//加载第一次的数据
							if(this.MenuList.length>0){
								this.dataType= this.MenuList[0].Menu_Id; 
								getApp().globalData.SelType = this.MenuList[0].Menu_Id
								getApp().globalData.SelName = this.MenuList[0].Menu_Name
							}
							
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

<style>
		.fun_btn_show{
			margin: 15rpx 5rpx;
			padding: 0 10rpx;
			height: 70rpx;
			line-height: 70rpx;
		
		}
		.fun_input_show{
			margin: 15rpx 5rpx;
			padding: 0 10rpx;
			background-color: #ebebeb;
			height: 70rpx;
			line-height: 70rpx;
			text-align: left;
			color: #777;
			font-size: 30rpx;
		}
		.flex-item-btn {
			width: 25%;
			height: 100rpx;
		}
		.flex-item-input {
			width: 75%;
			height: 50rpx;
			text-align: left;
		}
		.word-btn {
			/* #ifndef APP-NVUE */
			display: flex;
			/* #endif */
			flex-direction: row;
			align-items: center;
			justify-content: center;
			border-radius: 6px;
			height: 35px;
			margin: 3px;
			background-color: #B2B2B2;
		}
		.word-btn-close {
			/* #ifndef APP-NVUE */
			display: flex;
			/* #endif */
			flex-direction: row;
			align-items: center;
			justify-content: center;
			border-radius: 6px;
			height: 35px;
			margin: 3px;
			background-color: #FF3333;
		}
		.word-btn-select{
			background-color: #4ca2ff;
			/* #ifndef APP-NVUE */
			display: flex;
			/* #endif */
			flex-direction: row;
			align-items: center;
			justify-content: center;
			border-radius: 6px;
			height: 35px;
			margin: 3px;
			
		}
		.word-btn--hover {
			background-color: #B2B2B2;
		}
		.word-btn--close {
			background-color: #FF3333;
		}
		.word-btn-white {
			font-size: 18px;
			color: #FFFFFF;
		}
		.list-flew{
			border: 1px #d0dee5 solid;
			border-left: none;
			border-right: none;
			box-sizing: border-box;
		}
		.title-flex{
			display: flex;
			flex: 1;
			flex-direction:column;
			width: 200rpx;
			height: 220rpx;
			justify-content: center;
			align-items: center;
		}
		.note-flex{
			display: flex;
			flex: 3;
			padding-top: 20rpx;
			flex-direction: row;
			justify-content: flex-start;
			align-content: space-between;
			align-items: flex-start;
			flex-wrap: wrap;
		}
			
		.text-flex{
			padding-left: 30rpx;
			border: 1px #555500 solid;
			border-left: none;
			border-top: none;
			border-bottom: none;
			box-sizing: border-box;
			font-size: 30rpx;
			
			width: 180rpx;
		}
</style>
