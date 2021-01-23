<template>
	<view>
		<uni-nav-bar leftImage="../../static/bytq_logo.png" title="澳柯玛冷链仓储系统" ></uni-nav-bar>
		<view>
			<view v-for="(it, ind) in MainMenuList" :key="ind">
				<uni-collapse ref="add" class="warp" >
					<uni-collapse-item-me :title="it">
						<view v-for="(item, index) in MenuList" :key="index" >
							<view v-if="item.Menu_Type == it">
								<view class="word-btn-select" hover-class="word-btn--hover"v-show="dataType==item.Menu_Id" :hover-start-time="20" :hover-stay-time="70" @click="openPage(index)">
									<text class="word-btn-white">{{item.Menu_Name}}</text>
								</view>
								<view class="word-btn" hover-class="word-btn--hover" v-show="dataType!=item.Menu_Id" :hover-start-time="20" :hover-stay-time="70" @click="openPage(index)">
									<text class="word-btn-white">{{item.Menu_Name}}</text>
								</view>	
							</view>
						</view>
					</uni-collapse-item-me>
				</uni-collapse>
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
			openPage(ind){
				this.dataType= this.MenuList[ind].Menu_Id
				getApp().globalData.SelType = this.MenuList[ind].Menu_Id
				getApp().globalData.SelName = this.MenuList[ind].Menu_Name
				console.log(this.MenuList[ind].View_Path)
				uni.navigateTo({
					url:this.MenuList[ind].View_Path+'?Menu_Name='+this.MenuList[ind].Menu_Name,
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
</style>
