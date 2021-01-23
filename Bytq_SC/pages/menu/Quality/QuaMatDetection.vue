<template>
	<!-- 原料入库界面 -->
	<view>
		<uni-nav-bar leftImage="../../../static/bytq_logo.png" :title="title" ></uni-nav-bar>
		<!-- 分段器（0-待执行，1-执行中，2-已完成） -->
		<view class="uni-padding-wrap uni-common-mt">
			<uni-segmented-control :current="current" :values="items" styleType="text" active-color="#ffffff" @clickItem="onClickItem"/>
		</view>
		<view class="content">
			<view v-if="current === 0" >
				
				<t-table border="2" border-color="#00266e" :is-check="true" @change="change">
					<t-tr font-size="14" color="#00007f" align="left" >
						<t-th align="left" >业务单号</t-th>
						<t-th align="left" >入库单号</t-th>
						<t-th align="left" >品名</t-th>
						<t-th align="left" >规格型号</t-th>
						<t-th align="left" >订单数量</t-th>
					</t-tr>
					<t-tr font-size="12" color="#000000" align="right" v-for="(item,index) in Waitlist" :key="index" >
						<t-td align="left">{{ item.Source_Bill_No }}</t-td>
						<t-td align="left">{{ item.Stock_Activity_No }}</t-td>
						<t-td align="left">{{ item.Part_Name }}</t-td>
						<t-td align="left">{{ item.Spection }}</t-td>
						<t-td align="left">{{ item.Order_Qty }}</t-td>
					</t-tr>
				</t-table>	
				<view class="uni-bottom-view">
					<view class="uni-flex uni-row">
						<button class="flex-item" type="primary" size="mini" @click="Submit">确认</button>
						<button class="flex-item" type="primary" size="mini" @click="ReSet">清空</button>
					</view>
				</view>
			</view>
			<view v-if="current === 1" >
				<uni-list>
					<template v-for="(item,index) in Executlist">
						<uni-list-item   :title="item.Quality_No+'--'+item.Bill_No"  :note="item.Warehouse_Name+' '+item.Bill_Type_Name+' '+item.Product_Date"  :rightText="item.Status_Name" link="navigateTo" clickable @click="openUrl(item.Quality_Id,item.Status_Name)"></uni-list-item>
					</template>
				</uni-list>
			</view>
			<view v-if="current === 2" >
				<uni-list>
					<template v-for="(item,index) in Performlist">
						<uni-list-item   :title="item.Quality_No+'--'+item.Bill_No"  :note="item.Warehouse_Name+' '+item.Bill_Type_Name+' '+item.Product_Date"  :rightText="item.Status_Name" link="navigateTo" clickable @click="openUrl(item.Quality_Id,item.Status_Name)"></uni-list-item>
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
	import tTable from '@/components/t-table/t-table.vue'
	import tTh from '@/components/t-table/t-th.vue'
	import tTr from '@/components/t-table/t-tr.vue'
	import tTd from '@/components/t-table/t-td.vue'
	var token;
	
	export default {
		components: {
			uniPopup,
			uniPopupDialog,
			tTable,
			tTh,
			tTr,
			tTd
		},
		onLoad: function (option) { //option为object类型，会序列化上个页面传递的参数
			this.$data.menu_no = option.Menu_No
			this.$data.title = option.Menu_Name
			console.log(this.$data.menu_no)
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
				menu_no:"",
				items: ['待执行', '执行中','已完成'],
				title:'',
				current: 0,
				MenuNo:"CT0101005",
				content:"确定生成该单据吗?",
				Waitlist:[],
				Executlist:[],
				Performlist:[],
				formData: [],
				condata:''
				
			}
		},
		methods: {
			//出库和入库区分开来不用一个界面
			//质检是另一种界面
			getWaitList(){
				//获取待执行的单据列表
				uni.request({
					url: this.web_url+'/StockQuality/GetQualityDataSource',
					data: {
						BusinessNo:this.$data.menu_no,
						Token:token
					},
					method:'GET',
					success: data => {
						if (data.statusCode == 200) {
							console.log(data)
							this.Waitlist = data.data.Data;
							console.log(this.Waitlist)
							
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
					url: this.web_url+'/StockQuality/GetQualityList',
					data: {
						BusinessNo:this.$data.menu_no,
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
					url: this.web_url+'/StockQuality/GetQualityList',
					data: {
						BusinessNo:this.$data.menu_no,
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
			setTime(items) {
				var newItems = [];
				var count = -1;
				items.forEach(e => {
					count = count+1
					newItems.push({
						value: count,//业务号
						text: e.Supplier_No,//业务类型
					});
				});
				return newItems;
			},
			onClickItem(e) {
				if (this.current !== e.currentIndex) {
					this.current = e.currentIndex
				}
			},
			
			openUrl(ssr,str){
				console.log(str)
				if(str == '草稿'){
					//草稿
					uni.navigateTo({
						url:"./QualityPickDetail"+'?Id='+ssr
					})
					
				}else if(str == '2'){
					//上架
					uni.navigateTo({
						url:"./QualityPickDetail"+'?Id='+ssr
					})
				}else if(str == '3'){
					//完成
					uni.navigateTo({
						url:"./QualityPickDetail"+'?Id='+ssr
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
			     console.log('点击确认')
			     this.condata = ''
			     for (let i = 0; i < this.formData.length; i++) {
					if(i==0){
						this.condata = this.$data.Waitlist[this.formData[i]].Stock_Activity_Detail_Id;
					}else{
						this.condata = this.condata +','+this.$data.Waitlist[this.formData[i]].Stock_Activity_Detail_Id;
					}
			     }
			     console.log(this.condata)
				//生成质检单据
				uni.request({
					url: this.web_url+'/StockQuality/StockQualityCreate',
					data: {
						BillTypeId:0,
						BillId:this.$data.condata,
						PartId:0,
						BusinessNo:this.$data.menu_no,
						Token:token
					},
					method:'GET',
					success: data => {
						console.log(data)
						if (data.statusCode == 200) {
							this.getExecutList();
							this.$data.current = 1;
							
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
				
				// 需要执行 done 才能关闭对话框
			    done()
				
			},
			change(e) {
				console.log(e.detail);
				this.formData = e.detail;
			},
				
			Submit(){
				this.$data.content = "确定生成质检单据吗？"
				this.$refs.popupDialog.open()
				
			},ReSet(){
				
				
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
	
	.text {
		font-size: 14px;
		color: #333;
		margin-bottom: 10px;
	}
	.scroll-show{
		padding-left: 20rpx;
		width: 100%;
	}
</style>
