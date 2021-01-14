<template>
	<view class="content">
		<view style="height: 150rpx;"></view>
		<view class="uni-flex uni-column">
			<image src="../../static/bytq_logo.png" class="flex-item flex-item-V " mode="aspectFit"></image>
			<view class="uni-flex uni-row">
			 	<view class="title-show">青岛北洋天青数联智能股份有限公司</view>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">用户工号</view>
				<input  name="account" placeholder="请输入工号" class="zh-text" v-model="account" style="-webkit-flex: 1;flex: 1;"/>
			</view>
			<view class="uni-flex uni-row">
				<view  class="text">用户密码</view>
				<input  name="password" placeholder="请输入工号" class="zh-text" password="showPassword" type="text" v-model="password" style="-webkit-flex: 1;flex: 1;"/>
				<!-- <view   :class="[!showPassword ? '' : 'icon iconfont iconcloseeye']"@click="showPwd">123</view> -->
			</view>
			<view class="uni-flex uni-row text-area">
				<button type="primary" @click="startLogin" size="mini">登录</button>
				<button type="primary" @click="closeApp" size="mini">退出</button>
			</view>
		</view>
	</view>
</template>

<script>
	import uniNavBar from "@/components/uni-nav-bar/uni-nav-bar.vue"
	export default {

		components: {uniNavBar},
		data() {
			return {
				account:'admin', //用户/电话
				password:'123', //密码 
				title: 'Hello'
			}
		},
		onLoad() {

		},
		methods: {
			startLogin(e){
							 
			    //console.log(e)
				//登录
				var that = this;
				if(this.isRotate){
					//判断是否加载中，避免重复点击请求
					return false;
				}
				if (this.account.length == "") {
				     uni.showToast({
				        icon: 'none',
						position: 'bottom',
				        title: '用户名不能为空'
				    });
				    return; 
				}
				console.log(this.$data.account)
				console.log(this.$data.password)
				uni.request({
					header: {
						"Content-Type":"application/json"
					}, 
					url:this.web_url+"/User/LoginNew",
					data:{  
					     userName: this.$data.account, 
					     password: this.$data.password

					}, 
					method:'POST',
					success(res){ 
						console.log(res);
						if(res.data==null){ 
							uni.showToast({
								icon: 'success',
								position: 'bottom',
								title: '登录失败'
							});		 
						}else{
							// // #ifdef APP-PLUS
							//     that.fileWriter()
							// // #endif
										 
							// getApp().globalData.username = 'zhkb'
							// getApp().globalData.useraccount = that.account
							// getApp().globalData.CLASS_CODE = that.classdata.code;
							// getApp().globalData.CLASS_NAME = that.classdata.name;
							// getApp().globalData.SHIFT_CODE = that.shiftdata.code;
							// getApp().globalData.SHIFT_NAME = that.shiftdata.name;
							uni.showToast({
									icon: 'success',
									position: 'bottom',
									title: '登录成功'
							});  
							uni.setStorage({
									key:'userInfo',
									data:res.data.Data
							})
									    
							uni.switchTab({
								url: '../main/wait'
							});
									
						}											
					},
					fail(){
						uni.showToast({
							   title: '接口关闭登录失败',
							   icon:"none",
							 
					    })
					
					}
					
				})
			
				
			},
			closeApp(){
				plus.runtime.quit();
			}
		}
	}
</script>

<style>
	.flex-item {
		width: 33.3%;
		height: 200rpx;
		text-align: center;
		line-height: 200rpx;
	}
	
	.flex-item-V {
		width: 100%;
		height: 150rpx;
		text-align: center;
		line-height: 150rpx;
	}
		
	.title-show{
		padding: 0 20rpx;
		height: 100rpx;
		line-height: 90rpx;
		text-align: center;
		color: #000000;
		font-size: 45rpx;
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
	.text-area{
		padding-top: 50rpx;
	}
</style>
