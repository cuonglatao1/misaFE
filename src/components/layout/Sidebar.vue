<template>
  <aside class="sidebar" :class="{ collapsed: isCollapsed }">
    <div class="scroll-area--main-sidebar">
      <!-- Tổng quan -->
      <div
        class="vs-sidebar--item"
        :class="{ 'vs-sidebar-item-active': isActive('/dashboard') }"
      >
        <div
          class="flex item-sidebar"
          :class="{ active: isActive('/dashboard') }"
        >
          <router-link to="/dashboard">
            <div class="sidebar-icon mi-sidebar-dashboard"></div>
            <span class="truncate">Tổng quan</span>
          </router-link>
        </div>
      </div>

      <!-- Thành phần lương -->
      <div
        class="vs-sidebar--item"
        :class="{ 'vs-sidebar-item-active': isActive('/salarycomposition') }"
      >
        <div
          class="flex item-sidebar"
          :class="{ active: isActive('/salarycomposition') }"
        >
          <router-link to="/salarycomposition">
            <div class="sidebar-icon mi-sidebar-salary-composition"></div>
            <span class="truncate">Thành phần lương</span>
          </router-link>
        </div>
      </div>

      <!-- Mẫu bảng lương -->
      <div
        class="vs-sidebar--item"
        :class="{ 'vs-sidebar-item-active': isActive('/policy/salary') }"
      >
        <div
          class="flex item-sidebar"
          :class="{ active: isActive('/policy/salary') }"
        >
          <router-link to="/policy/salary">
            <div class="sidebar-icon mi-sidebar-salary-template"></div>
            <span class="truncate">Mẫu bảng lương</span>
          </router-link>
        </div>
      </div>

      <!-- Dữ liệu tính lương (Group) -->
      <div
        class="vs-sidebar-group"
        :class="{ 'vs-sidebar-item-active': isGroupActive(salaryDataRoutes) }"
      >
        <div
          class="group-header w-full"
          :class="{ active: isGroupActive(salaryDataRoutes) }"
          @click="toggleGroup(0)"
          ref="groupHeader0"
        >
          <div class="sidebar-icon mi-sidebar-salary-data"></div>
          <span class="truncate flex-1">Dữ liệu tính lương</span>
          <div class="mi-sidebar-dropdown"></div>
        </div>
        <ul
          v-if="openGroups.includes(0)"
          class="vs-sidebar-group-items vs-sidebar-flyout"
          :style="getGroupStyle(0)"
        >
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary-data/timekeeping') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary-data/timekeeping') }"
              >
                <router-link to="/salary-data/timekeeping">
                  <span class="truncate">Bảng lương</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary-data/advance') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary-data/advance') }"
              >
                <router-link to="/salary-data/advance">
                  <span class="truncate">Tạm ứng</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary-data/summary') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary-data/summary') }"
              >
                <router-link to="/salary-data/summary">
                  <span class="truncate">Tổng hợp lương</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary-data/allocation') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary-data/allocation') }"
              >
                <router-link to="/salary-data/allocation">
                  <span class="truncate">Phân bổ lương</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary-data/budget') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary-data/budget') }"
              >
                <router-link to="/salary-data/budget">
                  <span class="truncate">Ngân sách lương</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary-data/tax-table') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary-data/tax-table') }"
              >
                <router-link to="/salary-data/tax-table">
                  <span class="truncate">Bảng thuế</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary-data/tax-settlement') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary-data/tax-settlement') }"
              >
                <router-link to="/salary-data/tax-settlement">
                  <span class="truncate">Quyết toán thuế</span>
                </router-link>
              </div>
            </div>
          </li>
        </ul>
      </div>

      <!-- Tính lương (Group) -->
      <div
        class="vs-sidebar-group"
        :class="{ 'vs-sidebar-item-active': isGroupActive(salaryRoutes) }"
      >
        <div
          class="group-header w-full"
          :class="{ active: isGroupActive(salaryRoutes) }"
          @click="toggleGroup(1)"
          ref="groupHeader1"
        >
          <div class="sidebar-icon mi-sidebar-salary-table"></div>
          <span class="truncate flex-1">Tính lương</span>
          <div class="mi-sidebar-dropdown"></div>
        </div>
        <ul
          v-if="openGroups.includes(1)"
          class="vs-sidebar-group-items vs-sidebar-flyout"
          :style="getGroupStyle(1)"
        >
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary/payroll') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary/payroll') }"
              >
                <router-link to="/salary/payroll">
                  <span class="truncate">Bảng lương</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary/advance') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary/advance') }"
              >
                <router-link to="/salary/advance">
                  <span class="truncate">Tạm ứng</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary/summary') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary/summary') }"
              >
                <router-link to="/salary/summary">
                  <span class="truncate">Tổng hợp lương</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary/allocation') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary/allocation') }"
              >
                <router-link to="/salary/allocation">
                  <span class="truncate">Phân bổ lương</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary/budget') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary/budget') }"
              >
                <router-link to="/salary/budget">
                  <span class="truncate">Ngân sách lương</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary/tax-table') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary/tax-table') }"
              >
                <router-link to="/salary/tax-table">
                  <span class="truncate">Bảng thuế</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/salary/tax-settlement') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/salary/tax-settlement') }"
              >
                <router-link to="/salary/tax-settlement">
                  <span class="truncate">Quyết toán thuế</span>
                </router-link>
              </div>
            </div>
          </li>
        </ul>
      </div>

      <!-- Chi trả (Group) -->
      <div
        class="vs-sidebar-group"
        :class="{ 'vs-sidebar-item-active': isGroupActive(paymentRoutes) }"
      >
        <div
          class="group-header w-full"
          :class="{ active: isGroupActive(paymentRoutes) }"
          @click="toggleGroup(2)"
          ref="groupHeader2"
        >
          <div class="sidebar-icon mi-sidebar-payment"></div>
          <span class="truncate flex-1">Chi trả</span>
          <div class="mi-sidebar-dropdown"></div>
        </div>
        <ul
          v-if="openGroups.includes(2)"
          class="vs-sidebar-group-items vs-sidebar-flyout"
          :style="getGroupStyle(2)"
        >
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/payment') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/payment') }"
              >
                <router-link to="/payment">
                  <span class="truncate">Bảng chi trả</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/payment/payment-summary') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/payment/payment-summary') }"
              >
                <router-link to="/payment/payment-summary">
                  <span class="truncate">Tổng hợp chi trả</span>
                </router-link>
              </div>
            </div>
          </li>
        </ul>
      </div>

      <!-- Báo cáo -->
      <div
        class="vs-sidebar--item"
        :class="{ 'vs-sidebar-item-active': isActive('/report') }"
      >
        <div
          class="flex item-sidebar"
          :class="{ active: isActive('/report') }"
        >
          <router-link to="/report">
            <div class="sidebar-icon mi-sidebar-report"></div>
            <span class="truncate">Báo cáo</span>
          </router-link>
        </div>
      </div>

      <!-- Thiết lập (Group) -->
      <div
        class="vs-sidebar-group"
        :class="{ 'vs-sidebar-item-active': isGroupActive(settingRoutes) }"
      >
        <div
          class="group-header w-full"
          :class="{ active: isGroupActive(settingRoutes) }"
          @click="toggleGroup(3)"
          ref="groupHeader3"
        >
          <div class="sidebar-icon mi-sidebar-setting"></div>
          <span class="truncate flex-1">Thiết lập</span>
          <div class="mi-sidebar-dropdown"></div>
        </div>
        <ul
          v-if="openGroups.includes(3)"
          class="vs-sidebar-group-items vs-sidebar-flyout"
          :style="getGroupStyle(3)"
        >
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/employee') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/employee') }"
              >
                <router-link to="/setting/employee">
                  <span class="truncate">Nhân viên</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/default-param') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/default-param') }"
              >
                <router-link to="/setting/default-param">
                  <span class="truncate">Thông số mặc định</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/form') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/form') }"
              >
                <router-link to="/setting/form">
                  <span class="truncate">Biểu mẫu</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/customize') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/customize') }"
              >
                <router-link to="/setting/customize">
                  <span class="truncate">Tùy chỉnh</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/role') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/role') }"
              >
                <router-link to="/setting/role">
                  <span class="truncate">Vai trò</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/user') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/user') }"
              >
                <router-link to="/setting/user">
                  <span class="truncate">Người dùng</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/connection') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/connection') }"
              >
                <router-link to="/setting/connection">
                  <span class="truncate">Kết nối</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/system') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/system') }"
              >
                <router-link to="/setting/system">
                  <span class="truncate">Hệ thống</span>
                </router-link>
              </div>
            </div>
          </li>
          <li class="m-y-4">
            <div
              class="vs-sidebar--item"
              :class="{ 'vs-sidebar-item-active': isActive('/setting/trash') }"
            >
              <div
                class="flex item-sidebar"
                :class="{ active: isActive('/setting/trash') }"
              >
                <router-link to="/setting/trash">
                  <span class="truncate">Thùng rác</span>
                </router-link>
              </div>
            </div>
          </li>
        </ul>
      </div>

      <!-- Nút thu gọn -->
      <div class="sidebar-toggle-button" @click="toggleCollapse">
        <div class="toggle-icon mi-sidebar-zoom" :class="{ rotated: isCollapsed }"></div>
        <span class="toggle-text" v-if="!isCollapsed">Thu gọn</span>
      </div>
    </div>
  </aside>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const openGroups = ref<number[]>([])
const isCollapsed = ref(localStorage.getItem('sidebarCollapsed') === 'true')
const groupHeader0 = ref<HTMLElement | null>(null)
const groupHeader1 = ref<HTMLElement | null>(null)
const groupHeader2 = ref<HTMLElement | null>(null)
const groupHeader3 = ref<HTMLElement | null>(null)

// Định nghĩa các routes thuộc mỗi group
const salaryDataRoutes = [
  '/salary-data/timekeeping',
  '/salary-data/advance',
  '/salary-data/summary',
  '/salary-data/allocation',
  '/salary-data/budget',
  '/salary-data/tax-table',
  '/salary-data/tax-settlement'
]

const salaryRoutes = [
  '/salary/payroll',
  '/salary/advance',
  '/salary/summary',
  '/salary/allocation',
  '/salary/budget',
  '/salary/tax-table',
  '/salary/tax-settlement'
]

const paymentRoutes = [
  '/payment',
  '/payment/payment-summary'
]

const settingRoutes = [
  '/setting/employee',
  '/setting/default-param',
  '/setting/form',
  '/setting/customize',
  '/setting/role',
  '/setting/user',
  '/setting/connection',
  '/setting/system',
  '/setting/trash'
]

// Kiểm tra route hiện tại có active không
const isActive = (path: string) => {
  return route.path === path
}

// Kiểm tra group có active không (có bất kỳ route con nào active)
const isGroupActive = (routes: string[]) => {
  return routes.some(r => route.path === r)
}

const toggleCollapse = () => {
  isCollapsed.value = !isCollapsed.value
  localStorage.setItem('sidebarCollapsed', isCollapsed.value.toString())
  if (isCollapsed.value) {
    // Đóng tất cả flyout khi thu gọn
    openGroups.value = []
  }
}

const toggleGroup = (index: number) => {
  // Không cho mở group khi sidebar đang thu gọn
  if (isCollapsed.value) return

  console.log('Toggle group:', index)
  const idx = openGroups.value.indexOf(index)
  if (idx > -1) {
    // Nếu đã mở thì đóng
    openGroups.value.splice(idx, 1)
  } else {
    // Đóng tất cả flyout khác, chỉ mở flyout mới
    openGroups.value = [index]
  }
}

const getGroupStyle = (index: number) => {
  const headers = [groupHeader0, groupHeader1, groupHeader2, groupHeader3]
  const header = headers[index]?.value

  if (!header) {
    return { top: '100px' }
  }

  const rect = header.getBoundingClientRect()
  return {
    top: `${rect.top}px`,
  }
}

const handleClickOutside = (event: MouseEvent) => {
  const target = event.target as HTMLElement
  // Nếu click vào flyout menu thì không đóng
  if (target.closest('.vs-sidebar-group-items')) {
    return
  }
  // Nếu click vào group header thì không xử lý (vì toggleGroup sẽ xử lý)
  if (target.closest('.group-header')) {
    return
  }
  // Click bất kỳ đâu khác thì đóng tất cả flyout
  openGroups.value = []
}

onMounted(() => {
  document.addEventListener('click', handleClickOutside)
})

onUnmounted(() => {
  document.removeEventListener('click', handleClickOutside)
})
</script>

<style>
.sidebar {
  width: 220px;
  height: 100%;
  background-color: rgb(22, 26, 23);
  transition: width 0.3s ease;
  background-attachment: scroll;
  background-clip: border-box;
  background-image: none;
  background-origin: padding-box;
  background-position: 0% 0%;
  background-repeat: repeat;
  background-size: auto;

  box-sizing: border-box;
  color: rgb(33, 33, 33);
  direction: ltr;
  display: block;

  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;

  letter-spacing: 0.14px;
  line-height: 21px;

  margin: 0;

  outline: none;
  outline-color: rgb(33, 33, 33);
  outline-style: none;
  outline-width: 0;

  overflow-x: visible !important;
  overflow-y: visible !important;

  padding: 0;
  padding-top: 16px;

  text-decoration: none;
  text-decoration-color: rgb(33, 33, 33);
  text-decoration-line: none;
  text-decoration-style: solid;
  text-decoration-thickness: auto;
  text-size-adjust: 100%;
  text-transform: none;
  text-wrap-mode: nowrap;

  unicode-bidi: isolate;
  white-space-collapse: collapse;
}

.scroll-area--main-sidebar {
  height: 100%;
  overflow-y: auto;
  overflow-x: visible !important;
}

/* Sidebar Item */
.vs-sidebar--item {
  cursor: pointer;
}

.item-sidebar {
  display: flex;
  align-items: center;
  padding: 12px 16px;
  color: #ffffff;
  transition: background-color 0.2s;
}

.item-sidebar:hover {
  background-color: rgba(52, 176, 87, 0.25);
  border-radius: 8px;
  margin: 0 10px;
}

.item-sidebar.active {
  background-color: rgb(52, 176, 87);
  border-radius: 8px;
  font-weight: 700;
  margin: 0 10px;
  height: 36px;
}

.item-sidebar a {
  display: flex;
  align-items: center;
  width: 100%;
  text-decoration: none;
  color: inherit;
  gap: 12px;
}

/* Sidebar Icon */
.sidebar-icon {
  width: 20px;
  height: 20px;
  min-width: 20px;
  background-color: rgb(255, 255, 255);
  -webkit-mask-repeat: no-repeat;
  mask-repeat: no-repeat;
  -webkit-mask-size: auto;
  mask-size: auto;
  flex-shrink: 0;
  display: inline-block;
}

/* Icon 1: Tổng quan */
.mi-sidebar-dashboard {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position-x: 0px;
  -webkit-mask-position-y: -778px;
  mask-position: 0px -778px;
}

/* Icon 2: Thành phần lương */
.mi-sidebar-salary-composition {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position-x: -120px;
  -webkit-mask-position-y: -778px;
  mask-position: -120px -778px;
}

/* Icon 3: Mẫu bảng lương */
.mi-sidebar-salary-template {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position-x: -100px;
  -webkit-mask-position-y: -778px;
  mask-position: -100px -778px;
}

/* Icon 4: Dữ liệu tính lương */
.mi-sidebar-salary-data {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position-x: -20px;
  -webkit-mask-position-y: -778px;
  mask-position: -20px -778px;
}

/* Icon 5: Tính lương */
.mi-sidebar-salary-table {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position-x: -40px;
  -webkit-mask-position-y: -778px;
  mask-position: -40px -778px;
}

/* Icon 6: Chi trả */
.mi-sidebar-payment {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position-x: -60px;
  -webkit-mask-position-y: -778px;
  mask-position: -60px -778px;
}

/* Icon 7: Báo cáo */
.mi-sidebar-report {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position-x: -80px;
  -webkit-mask-position-y: -778px;
  mask-position: -80px -778px;
}

/* Icon 8: Thiết lập */
.mi-sidebar-setting {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position-x: -140px;
  -webkit-mask-position-y: -778px;
  mask-position: -140px -778px;
}

/* Sidebar Group */
.vs-sidebar-group {
  margin: 4px 0;
  position: static;
  overflow: visible !important;
}

.vs-sidebar-group .group-header {
  position: relative;
}

.group-header {
  padding: 12px 16px;
  cursor: pointer;
  color: #ffffff;
  transition: background-color 0.2s;
  display: flex;
  align-items: center;
  gap: 12px;
}

.group-header:hover {
  background-color: rgba(52, 176, 87, 0.25);
  border-radius: 8px;
  margin: 0 10px;
  width: calc(100% - 20px);
}

.group-header.active {
  background-color: rgb(52, 176, 87);
  border-radius: 8px;
  font-weight: 700;
  margin: 0 10px;
  height: 36px;
  padding: 0 16px;
  width: calc(100% - 20px);
}

.flex-1 {
  flex: 1;
}

.mi-sidebar-dropdown {
  width: 7.4625px;
  height: 12px;
  background-color: rgba(255, 255, 255, 0.7);
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-repeat: no-repeat;
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -186px;
  -webkit-mask-position-y: -781px;
  mask-position: -186px -781px;

  box-sizing: border-box;
  cursor: pointer;
  display: block;

  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;

  letter-spacing: 0.14px;
  line-height: 21px;

  margin: 0;
  margin-right: 4px;

  outline: none;

  padding: 0;

  text-decoration: none;
  text-wrap-mode: nowrap;
  text-size-adjust: 100%;
  text-transform: none;

  unicode-bidi: isolate;
  white-space-collapse: collapse;
}

.m-r-4 {
  margin-right: 4px;
}

/* Group Items */
.vs-sidebar-group-items {
  list-style: none;
  list-style-image: none;
  list-style-position: outside;
  list-style-type: none;

  margin: 0;
  margin-block-start: 0;
  margin-block-end: 0;

  padding: 0;
}

.vs-sidebar-group-items.vs-sidebar-flyout {
  position: fixed;
  display: block !important;
  background-color: rgb(22, 26, 23);
  border-radius: 8px;
  box-shadow: rgba(0, 0, 0, 0.1) 0px 2px 8px 0px;
  color: rgb(255, 255, 255);
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-weight: 400;
  left: 226px;
  letter-spacing: 0.14px;
  line-height: 21px;
  min-width: 200px;
  padding: 4px 8px 4px 10px;
  width: 200px;
  z-index: 1000;
}

.vs-sidebar-group:hover .vs-sidebar-group-items.vs-sidebar-flyout,
.vs-sidebar-group-items.vs-sidebar-flyout.is-open {
  opacity: 1 !important;
  visibility: visible !important;
  pointer-events: auto !important;
}

.vs-sidebar-group-items li {
  padding: 0;
  margin: 4px 0;
}

.vs-sidebar-group-items .item-sidebar {
  padding: 8px 12px;
  color: #ffffff;
  cursor: pointer;
  pointer-events: auto;
  margin: 0;
}

.vs-sidebar-group-items .item-sidebar.active {
  background-color: rgb(52, 176, 87);
  border-radius: 8px;
  font-weight: 700;
  margin: 0;
  height: auto;
  padding: 8px 12px;
}

.vs-sidebar-group-items .item-sidebar:hover {
  background-color: rgba(255, 255, 255, 0.1);
}

.vs-sidebar-group-items .item-sidebar a {
  gap: 0;
}

.m-y-4 {
  margin: 4px 0;
}

/* Utilities */
.w-full {
  width: 100%;
}

.flex {
  display: flex;
}

.items-center {
  align-items: center;
}

.justify-between {
  justify-content: space-between;
}

.truncate {
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

/* Nút thu gọn */
.sidebar-toggle-button {
  position: absolute;
  bottom: 16px;
  left: 22px;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
  width: 176px;
  height: 36px;
  padding: 0 12px;
  background-color: rgba(255, 255, 255, 0.08);
  border-radius: 8px;
  color: #ffffff;
  cursor: pointer;
  transition: all 0.3s ease;
}

.sidebar-toggle-button:hover {
  background-color: rgba(255, 255, 255, 0.15);
}

.toggle-icon {
  width: 20px;
  height: 20px;
  background-color: #ffffff;
  -webkit-mask-repeat: no-repeat;
  mask-repeat: no-repeat;
}

.mi-sidebar-zoom {
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-position: -160px -778px;
  mask-position: -160px -778px;
  transition: transform 0.3s ease;
}

.toggle-icon.rotated {
  transform: rotate(180deg);
}

/* Sidebar thu gọn */
.sidebar.collapsed {
  width: 56px;
}

.sidebar.collapsed .truncate,
.sidebar.collapsed .toggle-text {
  display: none;
}

.sidebar.collapsed .item-sidebar,
.sidebar.collapsed .group-header {
  padding: 12px 18px;
  justify-content: center;
}

.sidebar.collapsed .item-sidebar.active,
.sidebar.collapsed .group-header.active {
  margin: 0 8px;
  padding: 12px 10px;
  width: calc(100% - 16px);
}

.sidebar.collapsed .mi-sidebar-dropdown {
  display: none;
}

.sidebar.collapsed .sidebar-toggle-button {
  width: 40px;
  left: 8px;
  padding: 0;
}
</style>
