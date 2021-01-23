<template>
	<!-- 产品入库界面 -->
	<view>
		<uni-nav-bar leftImage="../../../static/bytq_logo.png" :title="title"></uni-nav-bar>
		<!-- 分段器（0-待执行，1-执行中，2-已完成） -->
		<view class="uni-padding-wrap uni-common-mt">
			<uni-segmented-control :current="current" :values="items" style-type="button" active-color="#007aff" @clickItem="onClickItem" />
		</view>
		<view class="content">
			<view v-if="current === 0" >
				<uni-list>
					<template v-for="(item,index) in Waitlist">
						<uni-list-item   :title="item.Bill_Type_Name"  :note="item.Supplier_Name+' '+item.Stock_In_Date"  :rightText="item.Stock_In_No"  clickable  @click="openMes(item.Stock_In_No)"></uni-list-item>
					</template>
				</uni-list>
			</view>
			<view v-if="current === 1" >
				<uni-list>
					<template v-for="(item,index) in Executlist">
						<uni-list-item   :title="item.Stock_Activity_No+'--'+item.Bill_No"  :note="item.Warehouse_Name+' '+item.Bill_Type_Name+' '+item.Stock_Activity_Date"  :rightText="item.Status_Name" link="navigateTo" clickable @click="openUrl(item.Stock_Activity_Id,item.Status_Id)"></uni-list-item>
					</template>
				</uni-list>
			</view>
			<view v-if="current === 2" >
				<uni-list>
					<template v-for="(item,index) in Performlist">
						<uni-list-item   :title="item.Stock_Activity_No+'--'+item.Bill_No"  :note="item.Warehouse_Name+' '+item.Bill_Type_Name+' '+item.Stock_Activity_Date"  :rightText="item.Status_Name" link="navigateTo" clickable @click="openUrl(item.Stock_Activity_Id,item.Status_Id)"></uni-list-item>
					</template>
				</uni-list>
			</view>
		</view>
		<uni-popup id="popupDialog" ref="popupDialog" type="dialog" >
			<uni-popup-dialog type="warning" title="警告"  :content="content" :before-close="true" @confirm="dialogConfirm" @close="dialogClose"></uni-popup-dialog>
		</uni-popup>
	</view>
</template>

<script>
	
	import uniPopup from '@/components/uni-popup/uni-popup.vue'
	import uniPopupDialog from '@/components/uni-popup/uni-popup-dialog.vue'
	var token;
	
	export default {
		components: {
			uniPopup,
			uniPopupDialog
		},
		onLoad: function (option) { 
			this.$data.title = option.Menu_Name;
			this.getWaitList();
			this.getExecutList();
			this.getPerformList();
		},
		onShow(){
			this.getWaitList();
			this.getExecutList();
			this.getPerformList();
		},
		data() {
			token = uni.getStorageSync("userInfo").ApiToken;
			return {
				items: ['待执行', '执行中','已完成'],
				current: 0,
				MenuNo:"CT0101005",
				content:"确定生成该单据吗?",
				Waitlist:[],
				Executlist:[],
				Performlist:[],
				title:'成品入库'
				
			}
		},
		methods: {
			//出库和入库区分开来不用一个界面
			//质检是另一种界面
			getWaitList(){
				//获取待执行的单据列表
				uni.request({
					url: this.web_url+'/StockActivityOut/GetStockActivityOutDataSource',
					data: {
						WarehouseNo:"",
						Token:token
					},
					method:'GET',
					success: data => {
						if (data.statusCode == 200) {
							console.log(data);
							this.Waitlist=data.data.Data;
							
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
				
			},
			getExecutList(){
				//获取执行中的单据列表
				uni.request({
					url: this.web_url+'/StockActivityOut/GetStockActivityOutList',
					data: {
						IsFinish:false,
						Token:token
					},
					method:'GET',
					success: data => {
						if (data.statusCode == 200) {
							console.log(data);
							this.Executlist = data.data.Data;
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
			},
			getPerformList(){
				//获取已完成的单据列表
				uni.request({
					url: this.web_url+'/StockActivityOut/GetStockActivityOutList',
					data: {
						IsFinish:true,
						Token:token
					},
					method:'GET',
					success: data => {
						if (data.statusCode == 200) {
							console.log(data);
							this.Performlist = data.data.Data;
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
			},
			onClickItem(e) {
				if (this.current !== e.currentIndex) {
					this.current = e.currentIndex
				}
			},
			
			openUrl(ssr,str){
				console.log(str)
				if(str == '1'){
					//草稿
					uni.navigateTo({
						url:"./OutDraftDetail"+'?Id='+ssr
					})
					
				}else if(str == '2'){
					//上架
					uni.navigateTo({
						url:"./OutPickDetail"+'?Id='+ssr
					})
				}else if(str == '3'){
					//完成
					uni.navigateTo({
						url:"./OutShowDetail"+'?Id='+ssr
					})
				}
				
			},
			openMes(str){
				console.log(str)
				this.$data.content = "确定执行业务号为【"+str+"】的单据吗？" 
				this.$refs.popupDialog.open()
			},
			dialogClose(done){
				done()
			},
			dialogConfirm(done,value){
			    this.$refs.popupDialog.open()
				console.log('点击确认');
				//将待执行的变成执行中
				
				// 需要执行 done 才能关闭对话框
			    done()
				
			}
			
		}
	}
</script>

<style>
	.uni-padding-wrap {
		padding-bottom: 0px;
	}
	.uni-common-mt {
		margin-top: 2px;
	}
	.uni-bottom-view{
		padding-top: 30rpx;
	}
	.content{
		padding-top:5rpx;
		height: 750rpx;
	}
	.content-text {
		font-size: 18px;
		color: #333;
	}
</style>
