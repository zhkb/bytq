<template>
	<view>
		<uni-nav-bar leftImage="../../static/bytq_logo.png"  @clickLeft="showDrawer('showLeft')"  :title="title" ></uni-nav-bar>
		<view class="uni-padding-wrap uni-common-mt">
			<view class="uni-flex uni-row">
				<view class="flex-item-input">
					<input class="fun_input_show" type="text" @confirm="InputFun" placeholder="请输入数据" maxlength="20" v-model="inputValue" />
				</view>
				<view class="flex-item-btn">
					<button class="fun_btn_show" size="mini" type="primary" >查询</button>
				</view>
			</view>
		</view>
		<view class="example-body">
			<uni-drawer ref="showLeft" mode="left" :width="250" >
				<view v-for="(it, ind) in MainMenuList" :key="ind">
					<uni-collapse ref="add" class="warp" >

						<uni-collapse-item-me :title="it">
							<view v-for="(item, index) in MenuList" :key="index" >
								<view v-if="item.Menu_Type == it">
									<view class="word-btn-select" hover-class="word-btn--hover"v-show="dataType==item.Menu_Id" :hover-start-time="20" :hover-stay-time="70" @click="updData(index)">
										<text class="word-btn-white">{{item.Menu_Name}}</text>
									</view>
									<view class="word-btn" hover-class="word-btn--hover" v-show="dataType!=item.Menu_Id" :hover-start-time="20" :hover-stay-time="70" @click="updData(index)">
										<text class="word-btn-white">{{item.Menu_Name}}</text>
									</view>	
								</view>
							</view>
						</uni-collapse-item-me>
					</uni-collapse>
				</view>
				<view class="word-btn-close" hover-class="word-btn--close" :hover-start-time="20" :hover-stay-time="70" @click="closeDrawer('showLeft')"><text class="word-btn-white">关闭</text></view>	
			</uni-drawer>	
	    </view>
		<view>
			<uni-list>
				<template v-for="(item,index) in listData">
					<view v-if="(index >= pageSize*(current-1) && index<pageSize*current )">
						<uni-list-item :title="item.Bill_Type_Name" :note="item.note"  :rightText="item.Stock_In_No" clickable  @click="openPopup(item.Stock_In_No)"/>
					</view>
				</template>
			</uni-list>
		</view>
		<view style="padding-bottom: 100rpx;">
			<uni-pagination title="数据展示" show-icon="true" :total="total" :current="current" @change="change"></uni-pagination>
		</view>
	    <uni-popup id="popupDialog" ref="popupDialog" type="dialog" >
	    	<uni-popup-dialog type="warning" title="警告"  :content="content" :before-close="true" @confirm="dialogConfirm" @close="dialogClose"></uni-popup-dialog>
	    </uni-popup>
	</view>
</template>

<script>
	import uniCollapse from '@/components/uni-collapse/uni-collapse.vue'
	import UniCollapseItemMe from '@/components/uni-collapse-item/uni-collapse-item-me.vue'
	import uniPagination from '@/components/uni-pagination/uni-pagination.vue'
	import uniNavBar from "@/components/uni-nav-bar/uni-nav-bar.vue"
	import uniDrawer from "@/components/uni-drawer/uni-drawer.vue"
	import uniPopup from '@/components/uni-popup/uni-popup.vue'
	import uniPopupMessage from '@/components/uni-popup/uni-popup-message.vue'
	import uniPopupDialog from '@/components/uni-popup/uni-popup-dialog.vue'
	var token;
	var postid;
	export default {
		components: {
			uniCollapse,
			UniCollapseItemMe,
			uniDrawer,
			uniPagination,
			uniPopup,
			uniPopupMessage,
			uniPopupDialog
		},
		onLoad() {
			
			this.getMenuList()
			this.getList()
		},
		onShow(){
			this.getList()
		},
		data() {
			token = uni.getStorageSync("userInfo").ApiToken;
			postid = uni.getStorageSync("userInfo").Post_Id;
			
			return {
				MenuList:[],
				showLeft: false,
				dataType: "",
				MenuNo:"",
				current: 1,
				total: 50,
				pageSize: 10,
				listData: [],
				UNITS: {
					'年': 31557600000,
					'月': 2629800000,
					'天': 86400000,
					'小时': 3600000,
					'分钟': 60000,
					'秒': 1000
				},
				content:"确定生成该单据吗?",
				title:"WMS系统",
				inputValue:"1",
				MainMenuList:['入库相关','出库相关','质检相关']
				
			}
		},
		methods: {
			confirm() {},
			InputFun(){
				console.log(this.$data.inputValue)
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
								console.log(this.MenuList[0])
								getApp().globalData.SelType = this.MenuList[0].Menu_Id;
								getApp().globalData.SelMenu = this.MenuList[0].Menu_No;
								getApp().globalData.SelUrl = this.MenuList[0].View_Path;
								getApp().globalData.SelTitle = "WMS系统-"+this.MenuList[0].Menu_Name;
								this.dataType= this.MenuList[0].Menu_Id; 
								this.MenuNo=this.MenuList[0].Menu_No;
								this.title = "WMS系统-"+this.MenuList[0].Menu_Name;
							}
							
						}
					},
					fail: (data, code) => {
						console.log('fail' + JSON.stringify(data));
					}
				});
			},
			getList() {
				var data = {
					column: 'Bill_Type_Id,Bill_Type_Name,Stock_In_No,Stock_In_Date,Supplier_Name' //需要的字段名
				};
			    console.log(token)
				if(this.$data.MenuNo=="CT0101005"){
					uni.request({
						url: this.web_url+'/StockActivityIn/GetStockActivityInDataSource',
						data: {
							WarehouseNo:"",
							Token:token
						},
						method:'GET',
						success: data => {
							if (data.statusCode == 200) {
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
						url: this.web_url+'/StockActivityOut/GetStockActivityOutDataSource',
						data: {
							WarehouseNo:"",
							Token:token
						},
						success: data => {
							if (data.statusCode == 200) {
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
				}else if(this.$data.MenuNo=="CT0104005"){
					
				}else if(this.$data.MenuNo=="CT0104006"){
					
				}else if(this.$data.MenuNo=="CT0104007"){
					
				}
				
			},
			setTime(items) {
				var newItems = [];
				items.forEach(e => {
					newItems.push({
						Bill_Type_Id: e.Bill_Type_Id,//业务号
						Bill_Type_Name: e.Bill_Type_Name,//业务类型
						Stock_In_No: e.Stock_In_No,//业务单号
						note: e.Supplier_Name+"  "+e.Stock_In_Date//供应商,业务日期
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
			// 打开窗口
			showDrawer(e) {
			
				this.$refs[e].open()
				
			},
			// 关闭窗口
			closeDrawer(e) {
				this.getList()
				this.$refs[e].close()
			},
			updData(sindex){
				
				this.$data.dataType = this.MenuList[sindex].Menu_Id
				getApp().globalData.SelType = this.MenuList[sindex].Menu_Id
				getApp().globalData.SelUrl = this.MenuList[sindex].View_Path
				this.$data.MenuNo = this.MenuList[sindex].Menu_No
				getApp().globalData.SelMenu = this.MenuList[sindex].Menu_No
				this.title = "WMS系统-"+ this.MenuList[sindex].Menu_Name
				getApp().globalData.SelTitle = "WMS系统-"+this.MenuList[sindex].Menu_Name;
				this.getList();
				var kref = this.$refs
				setTimeout(function(){
					kref.showLeft.close();
				},500)
				
			},
			// 抽屉状态发生变化触发
			change(e, type) {
				console.log((type === 'showLeft' ? '左窗口' : '右窗口') + (e ? '打开' : '关闭'));
				this[type] = e
			},
			change(e) {
				console.log(e)
				this.current = e.current
			},
				
			openPopup(str){
				console.log(str)
				this.$data.content = "确定执行业务号为【"+str+"】的单据吗？" 
				this.$refs.popupDialog.open()
			},
			dialogClose(done){
			           this.msgType = 'info'
			           this.message = '点击了对话框的取消按钮'
			           this.$refs.popupDialog.open()
			           // 需要执行 done 才能关闭对话框
			           done()
			},
			dialogConfirm(done,value){
			         this.$refs.popupDialog.open()
			         console.log('点击确认');
					 
			         // 需要执行 done 才能关闭对话框
			         done()
					 uni.switchTab({
					 	url:"./execut"
						// success: (res) => {
						// 	 let page = getCurrentPages().pop();
						// 	 if (page == undefined || page == null) return;
						// 	 page.onLoad();
						// }
					 })
			}
		},
		onNavigationBarButtonTap(e) {
			if (this.showLeft) {
				this.$refs.showLeft.close()
			} else {
				this.$refs.showLeft.open()
			}
		},
		// app端拦截返回事件 ，仅app端生效
		onBackPress() {
			if (this.showRight || this.showLeft) {
				this.$refs.showLeft.close()
				this.$refs.showRight.close()
				return true
			}
		},
		
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
