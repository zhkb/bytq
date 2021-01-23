<template>
	<view>
		<uni-nav-bar leftImage="../../static/bytq_logo.png" title="澳柯玛冷链仓储系统" ></uni-nav-bar>
		<view >
			<uni-list>
				<template v-for="(item,index) in MeList">
					<uni-list-item  :title="item.C_Name" :rightText="item.C_Result+''"></uni-list-item>
				</template>
			</uni-list>
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
			this.getMeList()
		},
		onShow(){
			this.getMeList()
		},
		data() {
			token = uni.getStorageSync("userInfo").ApiToken;
			postid = uni.getStorageSync("userInfo").Post_Id;
			return {
				MeList:[],
				dataType: ""
			}
		},
		methods: {
			openPage(ind){
				this.dataType= this.MenuList[ind].Menu_Id
				getApp().globalData.SelType = this.MenuList[ind].Menu_Id
				console.log(this.MenuList[ind].View_Path)
				uni.navigateTo({
					url:this.MenuList[ind].View_Path,
					fail:function(){
						uni.showToast({
							icon:'none',
							position:'bottom',
							title:"错误：打开界面失败！"
						})
					}
				})
			},
			getMeList(){
				uni.request({
					url: this.web_url+'/ReportList/GetMyPage',
					data: {
						BusinessId:1,
						Token:token
					},
					method:'GET',
					success: data => {
						if (data.statusCode == 200) {
							
							console.log(data);
							this.MeList = data.data.Data;
							
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
