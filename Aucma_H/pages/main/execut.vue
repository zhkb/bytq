<template>
	<view>
		<uni-nav-bar leftImage="../../static/bytq_logo.png" :title="title" ></uni-nav-bar>
		<view>
			<uni-list>
				<template v-for="(item,index) in listData">
					<view v-if="(index >= pageSize*(current-1) && index<pageSize*current )">
						<uni-list-item :title="item.Stock_Activity_No+'--'+item.Bill_No" :note="item.Bill_note"  :rightText="item.Status_Name" clickable @click="OpenDetail(item.Stock_Activity_Id,item.Status_Id)" />
					</view>
				</template>
			</uni-list>
		</view>
		<view style="padding-bottom: 100rpx;">
			<uni-pagination title="数据展示" show-icon="true" :total="total" :current="current" @change="change"></uni-pagination>
		</view>
	</view>
</template>

<script>
	import uniPagination from '@/components/uni-pagination/uni-pagination.vue'
	import uniNavBar from "@/components/uni-nav-bar/uni-nav-bar.vue"
	import uniDrawer from "@/components/uni-drawer/uni-drawer.vue"
	import uniPopup from '@/components/uni-popup/uni-popup.vue'
	import uniPopupMessage from '@/components/uni-popup/uni-popup-message.vue'
	import uniPopupDialog from '@/components/uni-popup/uni-popup-dialog.vue'
	var token;
	export default {
		components: {
			uniDrawer,
			uniPagination,
			uniPopup,
			uniPopupMessage,
			uniPopupDialog
		},
		onLoad() {
			this.getList()
		},
		onShow(){
			this.getList()
			this.dataType = getApp().globalData.SelType
			this.MenuNo=getApp().globalData.SelMenu
			this.title=getApp().globalData.SelTitle
		},
		data() {
			token = uni.getStorageSync("userInfo").ApiToken;
			return {
				dataType:getApp().globalData.SelType,
				MenuNo:getApp().globalData.SelMenu,
				current: 1,
				total: 50,
				pageSize: 10,
				listData:[],
				title:getApp().globalData.SelTitle
			}
		},
		methods: {
			getList() {
				// var data = {
				// 	column: 'Bill_Type_Id,Bill_Type_Name,Stock_In_No,Stock_In_Date,Supplier_Name' //需要的字段名
				// };
			    console.log(token)
				console.log(this.$data.MenuNo)
				if(this.$data.MenuNo=="CT0101005"){
					uni.request({
						url: this.web_url+'/StockActivityIn/GetStockActivityInList',
						data: {
							IsFinish:false,
							Token:token
						},
						method:'GET',
						success: data => {
							if (data.statusCode == 200) {
								console.log("In")
								console.log(data);
								let list = this.setTime(data.data.Data);
								this.listData = list;
								this.total = this.listData.length;
								console.log(this.listData);
							}
						},
						fail: (data, code) => {
							console.log('fail' + JSON.stringify(data));
						}
					});	
				}else if(this.$data.MenuNo=="CT0101007"){
					uni.request({
						url: this.web_url+'/StockActivityOut/GetStockActivityOutList',
						data: {
							IsFinish:false,
							Token:token
						},
						method:'GET',
						success: data => {
							if (data.statusCode == 200) {
								console.log("Out")
								console.log(data);
								let list = this.setTime(data.data.Data);
								this.listData = list;
								this.total = this.listData.length;
								console.log(this.listData);
							}
						},
						fail: (data, code) => {
							console.log('fail' + JSON.stringify(data));
						}
					});
				}else if(this.$data.MenuNo=="CT0101008"){
					
				}else if(this.$data.MenuNo=="CT0101009"){
					
				}
				
			},
			setTime(items) {
				var newItems = [];
				items.forEach(e => {
					newItems.push({
						Id:e.Id,
						Stock_Activity_Id: e.Stock_Activity_Id,//单据号（传输）
						Stock_Activity_No: e.Stock_Activity_No,//单据号（显示）
						Bill_No: e.Bill_No,//业务单号
						Bill_note: e.Warehouse_Name+" "+e.Bill_Type_Name+" "+e.Stock_Activity_Date,//仓库,业务类型，业务日期
						Status_Name:e.Status_Name,
						Status_Id:e.Status_Id
					});
				});
				return newItems;
			},
			format(dateStr) {
				var date = this.parse(dateStr)
				var diff = Date.now() - date.getTime();
				if (diff < this.UNITS['天']) {
					return this.humanize(diff);
				}
				var _format = function(number) {
					return (number < 10 ? ('0' + number) : number);
				};
				return date.getFullYear() + '/' + _format(date.getMonth() + 1) + '/' + _format(date.getDate()) + '-' +
					_format(date.getHours()) + ':' + _format(date.getMinutes());
			},
			parse(str) { //将"yyyy-mm-dd HH:MM:ss"格式的字符串，转化为一个Date对象
				var a = str.split(/[^0-9]/);
				return new Date(a[0], a[1] - 1, a[2], a[3], a[4], a[5]);
			},
			change(e) {
				console.log(e)
				this.current = e.current
			},
			OpenDetail(str,sid){

				var url = "";
				console.log(str)
				console.log(sid)
				url = getApp().globalData.SelUrl;
				// if(this.$data.dataType=="101"||this.$data.dataType=="102"){
				// 	url = '../Detail/In/In';
				// }else{
				// 	url = '../Detail/Out/Out';
				// }
				
				
				if(sid==1){
					url = url+'DraftDetail?Id='+str
				}else{
					url = url+'PickDetail?Id='+str
				}
				
				
				// if(dataT=="2"||dataT == "4"){
				// 	url='../Detail/NewDetail?Stock_Activity_Id='+str
				// }else{
				// 	url='../Detail/OutDetail?Stock_Activity_Id='+str
				// }
				console.log(url)
				uni.navigateTo({
					url:url
				})
			}
			
		}
	}
</script>

<style>

</style>
