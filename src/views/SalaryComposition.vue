<template>
  <div class="h-full container" style="padding: 16px 24px">
    <!-- Header -->
    <div class="content-header p-b-16">
      <div class="flex justify-between items-center">
        <div class="flex items-center">
          <h2>Thành phần lương</h2>
        </div>

        <div class="flex items-center" style="gap: 2px">
          <!-- Nút Danh mục của hệ thống -->
          <button class="btn-secondary" @click="showSystemCategories">
            <i class="icon-rule"></i>
            <span>Danh mục của hệ thống</span>
          </button>

          <!-- Group nút Thêm mới -->
          <div class="btn-group-primary">
            <!-- Nút Thêm mới -->
            <button class="btn-primary" @click="handleAdd">
              <i class="icon-plus"></i>
              <span>Thêm mới</span>
            </button>

            <!-- Dropdown button -->
            <button class="btn-primary-dropdown" @click="toggleAddMenu">
              <i class="icon-chevron-down"></i>
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Content -->
    <div
      id="content-main-id"
      class="content-main"
      style="background: transparent; height: calc(100vh - 132px)"
    >
      <div class="h-full w-full">
        <div class="w-full h-full flex">
          <div class="grid-container">
            <!-- Toolbar -->
            <div class="grid-options flex items-center">
              <div class="flex items-center justify-between w-full h-full">
                <!-- Left side: Search -->
                <div class="flex items-center">
                  <div class="search-box m-r-8">
                    <div style="height: 36px; width: 300px">
                      <div class="flex items-center w-full h-full">
                        <div class="ms-input flex w-full">
                          <div class="ms-icon-default flex items-center justify-center p-l-8">
                            <i class="ms-icon notranslate icon-scale mi-search"></i>
                          </div>
                          <input
                            v-model="searchText"
                            maxlength="255"
                            placeholder="Tìm kiếm"
                            tabindex="1"
                            autocomplete="on"
                            type="text"
                            class="ms-input-item"
                            @input="onSearch"
                          />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <!-- Right side: Tools -->
                <div class="flex items-center">
                  <!-- Dropdown Trạng thái -->
                  <select v-model="statusFilter" class="select-status">
                    <option value="">Tất cả trạng thái</option>
                    <option value="active">Đang sử dụng</option>
                    <option value="inactive">Ngừng sử dụng</option>
                  </select>

                  <!-- Dropdown Đơn vị -->
                  <select class="select-unit">
                    <option>Tất cả đơn vị</option>
                  </select>

                  <!-- Nút Bộ lọc -->
                  <button class="btn-icon btn-filter" @click="showFilter" title="Bộ lọc">
                    <i class="icon-filter"></i>
                  </button>

                  <!-- Nút Thiết lập -->
                  <button class="btn-icon btn-setting" @click="showSettings" title="Thiết lập">
                    <i class="icon-setting"></i>
                  </button>
                </div>
              </div>
            </div>

            <!-- DataGrid -->
            <div id="datagrid" class="h-full">
              <DxDataGrid
                :data-source="dataSource"
                :show-borders="true"
                :show-column-lines="true"
                :show-row-lines="true"
                :hover-state-enabled="true"
                :allow-column-reordering="true"
                :allow-column-resizing="true"
                :height="'100%'"
                key-expr="id"
                @selection-changed="onSelectionChanged"
                @row-dbl-click="onRowDblClick"
              >
                <DxSelection mode="multiple" show-check-boxes-mode="always" />
                <DxScrolling mode="virtual" show-scrollbar="always" :use-native="false" />
                <DxPaging :page-size="50" />
                <DxSorting mode="multiple" />

                <!-- Cột Checkbox -->
                <DxColumn type="selection" :width="55" :fixed="true" />

                <!-- Mã thành phần -->
                <DxColumn data-field="code" caption="Mã thành phần" :width="200" />

                <!-- Tên thành phần -->
                <DxColumn data-field="name" caption="Tên thành phần" :width="300" />

                <!-- Đơn vị áp dụng -->
                <DxColumn data-field="organizationUnit" caption="Đơn vị áp dụng" :width="200" />

                <!-- Loại thành phần -->
                <DxColumn data-field="type" caption="Loại thành phần" :width="200" />

                <!-- Tính chất -->
                <DxColumn data-field="nature" caption="Tính chất" :width="200" />

                <!-- Chịu thuế -->
                <DxColumn
                  data-field="taxable"
                  caption="Chịu thuế"
                  :width="150"
                  cell-template="yesNoTemplate"
                />

                <!-- Giảm trừ khi tính thuế -->
                <DxColumn data-field="taxDeduction" caption="Giảm trừ khi tính thuế" :width="200" />

                <!-- Định mức -->
                <DxColumn data-field="quota" caption="Định mức" :width="150" />

                <!-- Kiểu giá trị -->
                <DxColumn data-field="valueType" caption="Kiểu giá trị" :width="150" />

                <!-- Giá trị -->
                <DxColumn data-field="value" caption="Giá trị" :width="250" />

                <!-- Mô tả -->
                <DxColumn data-field="description" caption="Mô tả" :width="300" />

                <!-- Hiển thị trên phiếu lương -->
                <DxColumn
                  data-field="showOnPayslip"
                  caption="Hiển thị trên phiếu lương"
                  :width="200"
                  cell-template="yesNoTemplate"
                />

                <!-- Nguồn tạo -->
                <DxColumn data-field="source" caption="Nguồn tạo" :width="150" />

                <!-- Trạng thái -->
                <DxColumn
                  data-field="status"
                  caption="Trạng thái"
                  :width="150"
                  cell-template="statusTemplate"
                />

                <!-- Actions -->
                <DxColumn
                  caption=""
                  :width="200"
                  :fixed="true"
                  fixed-position="right"
                  cell-template="actionTemplate"
                />

                <!-- Templates -->
                <template #yesNoTemplate="{ data }">
                  <span>{{ data.value ? 'Có' : 'Không' }}</span>
                </template>

                <template #statusTemplate="{ data }">
                  <div class="flex items-center">
                    <i
                      :class="data.value === 'Đang sử dụng' ? 'icon-active' : 'icon-inactive'"
                      style="margin-right: 8px"
                    ></i>
                    <span>{{ data.value }}</span>
                  </div>
                </template>

                <template #actionTemplate="{ data }">
                  <div class="row-actions">
                    <button class="btn-action" @click="handleStop(data.data)" title="Ngừng sử dụng">
                      <i class="mi-circle-minus-yellow"></i>
                    </button>
                    <button class="btn-action" @click="handleCopy(data.data)" title="Nhân bản">
                      <i class="mi-copy"></i>
                    </button>
                    <button class="btn-action" @click="handleEdit(data.data)" title="Sửa">
                      <i class="mi-pencil"></i>
                    </button>
                    <button class="btn-action" @click="handleDelete(data.data)" title="Xóa">
                      <i class="mi-trash-red"></i>
                    </button>
                  </div>
                </template>
              </DxDataGrid>
            </div>

            <!-- Paging -->
            <div class="paging">
              <div class="grid-navigation" style="justify-content: space-between">
                <div class="page-total flex">
                  Tổng số bản ghi:
                  <b style="padding: 0px 6px">{{ totalRecords }}</b>
                </div>
                <div class="flex items-center">
                  <div class="page-size-selector flex items-center">
                    <div class="m-r-8 no-wrap">Số bản ghi/trang</div>
                    <div class="ms-con-dropdown parent-dropdown" style="position: relative">
                      <button
                        type="button"
                        class="ms-component ms-button flex justify-between items-center p-l-12 p-r-8 ms-button-secondary ms-button-filled ms-button-mi-chevron-down includeIcon"
                        style="width: 80px; height: 36px !important; border-radius: 4px; padding: 0px 8px 0px 12px; min-width: 0px !important"
                        @click="togglePageSizeDropdown"
                      >
                        <span class="ms-button-text ms-button--text">{{ pageSize }}</span>
                        <div class="tooltip-container" style="order: 2; margin-right: 0px; margin-left: 4px">
                          <div class="con-ms-tooltip">
                            <div class="ms-icon-default flex items-center justify-center ms-button--icon ms-icon-white" size="16px">
                              <i size="16px" class="ms-icon notranslate icon-scale mi-chevron-down"></i>
                            </div>
                          </div>
                        </div>
                      </button>
                      <!-- Dropdown menu -->
                      <div v-if="showPageSizeDropdown" class="page-size-dropdown">
                        <div
                          v-for="size in pageSizeOptions"
                          :key="size"
                          class="page-size-option"
                          :class="{ 'selected': size === pageSize }"
                          @click="selectPageSize(size)"
                        >
                          <span>{{ size }}</span>
                          <i v-if="size === pageSize" class="icon-check">✓</i>
                        </div>
                      </div>
                    </div>
                    <div class="page-info wrap-text">
                      <b>{{ pageStart }}</b>
                      -
                      <b>{{ pageEnd }}</b>
                      bản ghi
                    </div>
                  </div>
                  <div class="page-next-preview">
                    <div
                      class="ms-icon ms-icon-container flex items-center justify-center btn-icon-nav"
                      @click="prevPage"
                      :class="{ 'disabled': currentPage === 1 }"
                    >
                      <div class="tooltip-container">
                        <div class="con-ms-tooltip">
                          <i class="ms-icon notranslate icon-scale mi-chevron-left"></i>
                        </div>
                      </div>
                    </div>
                    <div
                      class="ms-icon ms-icon-container flex items-center justify-center btn-icon-nav"
                      @click="nextPage"
                      :class="{ 'disabled': currentPage >= totalPages }"
                    >
                      <div class="tooltip-container">
                        <div class="con-ms-tooltip">
                          <i class="ms-icon notranslate icon-scale mi-chevron-right"></i>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from 'vue'
import { useRouter } from 'vue-router'
import {
  DxDataGrid,
  DxColumn,
  DxSelection,
  DxScrolling,
  DxPaging,
  DxSorting,
} from 'devextreme-vue/data-grid'
import 'devextreme/dist/css/dx.common.css'
import 'devextreme/dist/css/dx.light.compact.css'

const router = useRouter()

const searchText = ref('')
const statusFilter = ref('')
const pageSize = ref(100)
const totalRecords = ref(0)
const selectedRows = ref([])
const currentPage = ref(1)
const showPageSizeDropdown = ref(false)
const pageSizeOptions = ref([15, 25, 50, 100])

// Computed properties for pagination
const totalPages = computed(() => Math.ceil(totalRecords.value / pageSize.value))
const pageStart = computed(() => (currentPage.value - 1) * pageSize.value + 1)
const pageEnd = computed(() => Math.min(currentPage.value * pageSize.value, totalRecords.value))

// Dữ liệu mẫu
const dataSource = ref([
  {
    id: 1,
    code: '123NN',
    name: 'NMU',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khác',
    nature: 'Cố định',
    taxable: true,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Hệ thống',
    status: 'Đang sử dụng',
  },
  {
    id: 2,
    code: 'PPPPPPP',
    name: 'ppppppp test fff',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thông tin nhân viên',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 3,
    code: '789LLLLO',
    name: '789LLLLO',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Lương',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 4,
    code: 'THAM_NIEN_THANG',
    name: 'Thâm niên (tháng)',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thông tin nhân viên',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: 'Tính bằng Tháng/năm của kỳ',
    valueType: 'Số',
    value: '-',
    description: '',
    showOnPayslip: false,
    source: 'Mặc định',
    status: 'Đang sử dụng',
  },
  {
    id: 5,
    code: 'TEST_LUC_12H03P',
    name: 'test luc 12h03p',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Chấm công',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '11111',
    valueType: 'Số',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 6,
    code: 'DOAN_TEST_HA',
    name: 'Doan Test Ha',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Doanh số',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '=SUM(LUONG_LAM_THEM_GIO,HHH...',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Anh Đoàn đã test ở đây!',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Ngừng sử dụng',
  },
  {
    id: 7,
    code: 'SSSSSSSSSSSSSSSS',
    name: 'ssssssssssssssss',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Doanh số',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 8,
    code: 'FDSFDSFDFFD_GFGFD',
    name: 'fdsfdsfdffd gfgfd',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Chấm công',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '100',
    valueType: 'Số',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 9,
    code: 'TEST_LUC_11H37P',
    name: 'test luc 11h37p',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Chấm công',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '=SUM(LUONG_CO_BAN, LUONG_NGA...',
    valueType: 'Tiền tệ',
    value: '=SUM(x1,x2)',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 10,
    code: 'FGFGFDG_GFDGDF',
    name: 'fgfgfdg gfdgdf',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thông tin nhân viên',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '=SUM(DOAN_TEST_HA,TOI_THEM)',
    valueType: 'Tiền tệ',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 11,
    code: 'TOI_THEM',
    name: 'toi thêm',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thông tin nhân viên',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 12,
    code: 'TY_LE_HOAN_THANH_DOANH_SO',
    name: 'Tỷ lệ hoàn thành doanh số',
    organizationUnit: '',
    type: 'Doanh số',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '=DOANH_SO_THUC_TE/DOANH_SO_M...',
    valueType: 'Phần trăm',
    value: '-',
    description: 'Sử dụng khi doanh nghiệp tính',
    showOnPayslip: true,
    source: 'Mặc định',
    status: 'Ngừng sử dụng',
  },
  {
    id: 13,
    code: 'PPPPPP',
    name: '00000000',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Doanh số',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 14,
    code: 'OOOOOOOOOOOOOOOO',
    name: 'oooooooooooooooooo',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Doanh số',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '=SUM(LUONG_LAM_THEM_GIO,HHH...',
    valueType: 'Tiền tệ',
    value: '-',
    description: '',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 15,
    code: 'BHXH',
    name: 'Bảo hiểm xã hội',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khấu trừ',
    nature: 'Theo công thức',
    taxable: false,
    taxDeduction: true,
    quota: '8%',
    valueType: 'Phần trăm',
    value: '8%',
    description: 'BHXH người lao động đóng',
    showOnPayslip: true,
    source: 'Hệ thống',
    status: 'Đang sử dụng',
  },
  {
    id: 16,
    code: 'BHYT',
    name: 'Bảo hiểm y tế',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khấu trừ',
    nature: 'Theo công thức',
    taxable: false,
    taxDeduction: true,
    quota: '1.5%',
    valueType: 'Phần trăm',
    value: '1.5%',
    description: 'BHYT người lao động đóng',
    showOnPayslip: true,
    source: 'Hệ thống',
    status: 'Đang sử dụng',
  },
  {
    id: 17,
    code: 'BHTN',
    name: 'Bảo hiểm thất nghiệp',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khấu trừ',
    nature: 'Theo công thức',
    taxable: false,
    taxDeduction: true,
    quota: '1%',
    valueType: 'Phần trăm',
    value: '1%',
    description: 'BHTN người lao động đóng',
    showOnPayslip: true,
    source: 'Hệ thống',
    status: 'Đang sử dụng',
  },
  {
    id: 18,
    code: 'LUONG_CB',
    name: 'Lương cơ bản',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: true,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '5,000,000',
    description: 'Lương cơ bản theo hợp đồng',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 19,
    code: 'PC_AN_TRUA',
    name: 'Phụ cấp ăn trưa',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '730000',
    valueType: 'Tiền tệ',
    value: '730,000',
    description: 'Phụ cấp ăn trưa theo tháng',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 20,
    code: 'PC_DI_LAI',
    name: 'Phụ cấp đi lại',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '500000',
    valueType: 'Tiền tệ',
    value: '500,000',
    description: 'Phụ cấp đi lại',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 21,
    code: 'PC_DIEN_THOAI',
    name: 'Phụ cấp điện thoại',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '300000',
    valueType: 'Tiền tệ',
    value: '300,000',
    description: 'Phụ cấp điện thoại',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 22,
    code: 'PC_TRACH_NHIEM',
    name: 'Phụ cấp trách nhiệm',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: true,
    taxDeduction: false,
    quota: '1000000',
    valueType: 'Tiền tệ',
    value: '1,000,000',
    description: 'Phụ cấp trách nhiệm',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 23,
    code: 'KHAU_TRU_DI_MUON',
    name: 'Khấu trừ đi muộn',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khấu trừ',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: true,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Khấu trừ đi muộn về sớm',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 24,
    code: 'THUONG_HIEU_SUAT',
    name: 'Thưởng hiệu suất',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '=LUONG_CO_BAN*0.05',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Thưởng hiệu suất',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 25,
    code: 'LUONG_TANG_CA',
    name: 'Lương tăng ca',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Lương làm thêm giờ',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 26,
    code: 'PC_XANG_XE',
    name: 'Phụ cấp xăng xe',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '200000',
    valueType: 'Tiền tệ',
    value: '200,000',
    description: 'Phụ cấp xăng xe',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 27,
    code: 'HT_DAO_TAO',
    name: 'Hỗ trợ đào tạo',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Hỗ trợ đào tạo',
    showOnPayslip: false,
    source: 'Tự thêm',
    status: 'Ngừng sử dụng',
  },
  {
    id: 28,
    code: 'LUONG_NGAY',
    name: 'Lương theo ngày',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '=LUONG_CO_BAN/22',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Lương theo ngày',
    showOnPayslip: false,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 29,
    code: 'THUONG_DU_AN',
    name: 'Thưởng dự án',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Thưởng dự án',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 30,
    code: 'THUE_TNCN',
    name: 'Thuế TNCN',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khấu trừ',
    nature: 'Theo công thức',
    taxable: false,
    taxDeduction: true,
    quota: '10%',
    valueType: 'Phần trăm',
    value: '10%',
    description: 'Thuế TNCN bậc 1',
    showOnPayslip: true,
    source: 'Hệ thống',
    status: 'Đang sử dụng',
  },
  {
    id: 31,
    code: 'PC_NHA_O',
    name: 'Phụ cấp nhà ở',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '400000',
    valueType: 'Tiền tệ',
    value: '400,000',
    description: 'Phụ cấp nhà ở',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 32,
    code: 'PC_LAM_DEM',
    name: 'Phụ cấp làm đêm',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '150000',
    valueType: 'Tiền tệ',
    value: '150,000',
    description: 'Phụ cấp làm đêm',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 33,
    code: 'HOA_HONG',
    name: 'Hoa hồng bán hàng',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Hoa hồng bán hàng',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 34,
    code: 'TONG_PHU_CAP',
    name: 'Tổng phụ cấp',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '=SUM(PC_AN_TRUA,PC_DI_LAI)',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Tổng phụ cấp',
    showOnPayslip: false,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 35,
    code: 'TC_SINH_NHAT',
    name: 'Trợ cấp sinh nhật',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Trợ cấp sinh nhật',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 36,
    code: 'THUONG_TET',
    name: 'Thưởng lễ tết',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '2000000',
    valueType: 'Tiền tệ',
    value: '2,000,000',
    description: 'Thưởng lễ tết',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 37,
    code: 'PHAT_VI_PHAM',
    name: 'Phạt vi phạm',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khấu trừ',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: true,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Phạt vi phạm nội quy',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 38,
    code: 'PC_CON_NHO',
    name: 'Phụ cấp con nhỏ',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '100000',
    valueType: 'Tiền tệ',
    value: '100,000',
    description: 'Phụ cấp con nhỏ',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 39,
    code: 'THUONG_SANG_KIEN',
    name: 'Thưởng sáng kiến',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Thưởng sáng kiến',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Ngừng sử dụng',
  },
  {
    id: 40,
    code: 'TONG_THU_NHAP',
    name: 'Tổng thu nhập',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '=LUONG_CO_BAN+THUONG_HS',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Tổng thu nhập',
    showOnPayslip: false,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 41,
    code: 'CONG_DOAN',
    name: 'Công đoàn',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khấu trừ',
    nature: 'Theo công thức',
    taxable: false,
    taxDeduction: true,
    quota: '1%',
    valueType: 'Phần trăm',
    value: '1%',
    description: 'Công đoàn',
    showOnPayslip: true,
    source: 'Hệ thống',
    status: 'Đang sử dụng',
  },
  {
    id: 42,
    code: 'PC_DOC_HAI',
    name: 'Phụ cấp độc hại',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '250000',
    valueType: 'Tiền tệ',
    value: '250,000',
    description: 'Phụ cấp độc hại',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 43,
    code: 'HT_HOC_PHI',
    name: 'Hỗ trợ học phí',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Hỗ trợ học phí',
    showOnPayslip: false,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 44,
    code: 'HH_DOANH_SO',
    name: 'Hoa hồng doanh số',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '=DOANH_SO*0.02',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Hoa hồng theo doanh số',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 45,
    code: 'PC_NGUOI_THAN',
    name: 'Phụ cấp người thân',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Cố định',
    taxable: false,
    taxDeduction: false,
    quota: '200000',
    valueType: 'Tiền tệ',
    value: '200,000',
    description: 'Phụ cấp người thân',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 46,
    code: 'THUONG_DOANH_SO',
    name: 'Thưởng doanh số',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: true,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Thưởng doanh số tháng',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 47,
    code: 'PC_CA_3',
    name: 'Phụ cấp ca 3',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '180000',
    valueType: 'Tiền tệ',
    value: '180,000',
    description: 'Phụ cấp ca 3',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 48,
    code: 'TAM_UNG',
    name: 'Tạm ứng',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Khấu trừ',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: true,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Tiền tạm ứng',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 49,
    code: 'LUONG_NET',
    name: 'Lương thực nhận',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Tổng lương thực nhận',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
  {
    id: 50,
    code: 'PC_CHUYEN_CAN',
    name: 'Phụ cấp chuyên cần',
    organizationUnit: 'Misa Test pdthien 2024',
    type: 'Thu nhập',
    nature: 'Biến đổi',
    taxable: false,
    taxDeduction: false,
    quota: '',
    valueType: 'Tiền tệ',
    value: '-',
    description: 'Phụ cấp chuyên cần',
    showOnPayslip: true,
    source: 'Tự thêm',
    status: 'Đang sử dụng',
  },
])

onMounted(() => {
  loadData()
})

const loadData = () => {
  totalRecords.value = dataSource.value.length
}

const onSearch = () => {
  console.log('Searching:', searchText.value)
}

const showFilter = () => {
  console.log('Show filter')
}

const showSettings = () => {
  console.log('Show settings')
}

const showSystemCategories = () => {
  console.log('Show system categories')
}

const handleAdd = () => {
  router.push('/salarycomposition/add')
}

const toggleAddMenu = () => {
  console.log('Toggle add menu')
}

const handleStop = (rowData: any) => {
  console.log('Stop:', rowData)
}

const handleCopy = (rowData: any) => {
  console.log('Copy:', rowData)
}

const handleEdit = (rowData: any) => {
  console.log('Edit:', rowData)
  router.push(`/salarycomposition/edit/${rowData.id}`)
}

const onRowDblClick = (e: any) => {
  console.log('Row double clicked:', e.data)
  router.push(`/salarycomposition/edit/${e.data.id}`)
}

const handleDelete = (rowData: any) => {
  console.log('Delete:', rowData)
}

const onSelectionChanged = (e: any) => {
  selectedRows.value = e.selectedRowsData
}

// Pagination functions
const togglePageSizeDropdown = () => {
  showPageSizeDropdown.value = !showPageSizeDropdown.value
}

const selectPageSize = (size: number) => {
  pageSize.value = size
  currentPage.value = 1 // Reset về trang 1 khi đổi số bản ghi/trang
  showPageSizeDropdown.value = false
}

const prevPage = () => {
  if (currentPage.value > 1) {
    currentPage.value--
  }
}

const nextPage = () => {
  if (currentPage.value < totalPages.value) {
    currentPage.value++
  }
}
</script>

<style scoped>
.h-full {
  height: 100%;
}
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
.justify-center {
  justify-content: center;
}
.p-b-16 {
  padding-bottom: 16px;
}
.m-r-8 {
  margin-right: 8px;
}
.container {
  background: #f2f2f2;
}
.content-header h2 {
  font-size: 20.5px;
  font-weight: 700;
  color: #212121;
  margin: 0;
}
.btn-primary {
  align-items: center;
  appearance: auto;
  background-color: rgb(52, 176, 87);
  border: 0.8px solid rgb(52, 176, 87);
  border-radius: 4px 0px 0px 4px;
  box-sizing: border-box;
  color: rgb(255, 255, 255);
  cursor: pointer;
  display: flex;
  gap: 5px;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 500;
  height: 36px;
  justify-content: center;
  outline: none;
  padding: 0px 16px 0px 17px;
  text-align: center;
  text-decoration: none;
  text-transform: none;
}
.btn-primary-dropdown {
  appearance: auto;
  background-color: rgba(0, 0, 0, 0);
  border: none;
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: pointer;
  display: block;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-size: 13.3333px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 36px;
  outline: none;
  padding: 0;
  position: relative;
  text-align: center;
  text-decoration: none;
  text-transform: none;
  width: 36px;
}
.btn-group-primary {
  display: flex;
  background-color: rgb(52, 176, 87);
  border-radius: 4px;
  overflow: hidden;
}
.btn-group-primary .btn-primary {
  border-radius: 4px 0px 0px 4px;
  position: relative;
}
.btn-group-primary .btn-primary::after {
  content: '';
  position: absolute;
  right: 0;
  top: 50%;
  transform: translateY(-50%);
  height: 20px;
  width: 1px;
  background-color: rgba(255, 255, 255, 1);
}
.btn-group-primary .btn-primary-dropdown {
  border-radius: 0px 4px 4px 0px;
  background-color: rgb(52, 176, 87);
  display: flex;
  align-items: center;
  justify-content: center;
}
.btn-primary:hover {
  background-color: #2d9a4a;
}
.btn-primary-dropdown:hover {
  background-color: #2d9a4a;
}
.btn-secondary {
  align-items: center;
  appearance: auto;
  background-color: rgb(255, 255, 255);
  border: 0.8px solid rgb(235, 235, 235);
  border-radius: 4px;
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: pointer;
  display: flex;
  gap: 5px;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 500;
  height: 36px;
  justify-content: center;
  margin-right: 8px;
  outline: none;
  padding: 0px 16px 0px 12px;
  text-align: center;
  text-decoration: none;
  text-transform: none;
}
.btn-secondary:hover {
  background-color: #f5f5f5;
}
.btn-icon {
  align-items: center;
  appearance: auto;
  background-color: rgb(255, 255, 255);
  border-radius: 4px;
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: pointer;
  display: flex;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 500;
  height: 36px;
  justify-content: center;
  outline: none;
  padding: 8px;
  position: relative;
  text-align: center;
  text-decoration: none;
  text-transform: none;
  width: 36px;
  min-width: 36px;
}
.btn-filter {
  border: 0.8px solid rgb(235, 235, 235);
  margin-right: 8px;
}
.btn-setting {
  border: none;
}
.btn-icon:hover {
  background-color: #f5f5f5;
}
.btn-filter:hover {
  border-color: #34b057;
  background-color: rgba(52, 176, 87, 0.1);
}
.btn-filter:hover .icon-filter {
  background-color: #34b057;
}
.btn-setting:hover .icon-setting {
  background-color: #34b057;
}
/* Row actions - hidden by default, shown on hover */
.row-actions {
  display: none;
  gap: 15px;
  align-items: center;
  justify-content: center;
}

:deep(.dx-datagrid-rowsview .dx-data-row:hover) .row-actions {
  display: flex !important;
}

.btn-action {
  background-color: transparent;
  border: none;
  cursor: pointer;
  padding: 0;
  width: 30px;
  height: 30px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 4px;
  transition: background-color 0.2s;
}

.btn-action:hover {
  background-color: rgba(0, 0, 0, 0.05);
}

.btn-icon-small {
  background: transparent;
  border: none;
  cursor: pointer;
  padding: 4px;
}

/* Override input background to white for this page */
.ms-input {
  background-color: #ffffff !important;
}

.ms-input-item {
  background-color: #ffffff !important;
}

.select-status {
  appearance: auto;
  background-color: rgba(0, 0, 0, 0);
  border: none;
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: pointer;
  display: inline-block;
  font-family: Inter, Roboto, Helvetica, Arial, sans-serif;
  font-size: 13.3333px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 20px;
  outline: none;
  padding: 0;
  position: relative;
  text-align: center;
  text-decoration: none;
  text-transform: none;
  width: 130.15px;
  margin-right: 16px;
}
.select-unit {
  align-items: center;
  border: 1px solid #d9d9d9;
  border-radius: 4px;
  box-sizing: border-box;
  color: #666666;
  cursor: pointer;
  display: flex;
  flex-basis: 100%;
  flex-grow: 1;
  flex-wrap: nowrap;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 34px;
  letter-spacing: 0.14px;
  line-height: 19.0001px;
  max-height: 180px;
  min-height: 34px;
  outline: none;
  padding-left: 8px;
  padding-right: 0;
  text-decoration: none;
  text-transform: none;
  width: 324.4px;
  margin-right: 8px;
  transition: border-color 0.2s;
}
.select-unit:hover {
  border-color: #34b057;
}
.grid-container {
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
}
.grid-options {
  align-items: center;
  background-color: rgb(255, 255, 255);
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  direction: ltr;
  display: flex;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 61px;
  letter-spacing: 0.14px;
  line-height: 21px;
  outline: none;
  padding: 12px 20px;
  position: relative;
  text-decoration: none;
  text-transform: none;
  z-index: 8;
}
.m-r-16 {
  margin-right: 16px;
}
#datagrid {
  flex: 1;
  overflow: auto;
  background: white;
}
.paging {
  height: 56px;
  border-top: 1px solid #e0e0e0;
  display: flex;
  align-items: center;
  padding: 0 16px;
  background: white;
}
.grid-navigation {
  width: 100%;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.page-total {
  font-size: 14px;
  color: rgb(33, 33, 33);
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-weight: 400;
  letter-spacing: 0.14px;
  line-height: 40px;
}
.no-wrap {
  white-space: nowrap;
}
.page-size-selector {
  gap: 8px;
}
.page-info {
  margin-left: 16px;
  font-size: 14px;
  color: #666;
}
.page-next-preview {
  margin-left: 16px;
  display: flex;
  gap: 8px;
  align-items: center;
}
.ms-button-secondary {
  border: 1px solid #d9d9d9;
  background: white;
  color: #212121;
  cursor: pointer;
  transition: all 0.2s;
}
.ms-button-secondary:hover {
  border-color: #34b057;
}
.ms-button-text {
  font-size: 14px;
  font-weight: 500;
}
.mi-chevron-down {
  width: 20px;
  height: 20px;
  background-color: rgb(110, 115, 122);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -140px;
  -webkit-mask-position-y: 0px;
  mask-position: -140px 0px;
  display: inline-block;
  min-width: 20px;
  min-height: 20px;
  transform: rotate(90deg);
}
/* Navigation button container */
.btn-icon-nav {
  align-items: center;
  background-color: rgba(0, 0, 0, 0);
  border: none;
  border-radius: 50%;
  box-sizing: border-box;
  color: rgb(175, 179, 193);
  cursor: pointer;
  direction: ltr;
  display: flex;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 16px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 36px;
  justify-content: center;
  letter-spacing: 0.14px;
  line-height: 35px;
  min-height: 20px;
  min-width: 36px;
  padding: 0;
  text-align: center;
  user-select: none;
  width: 36px;
  transition: background-color 0.2s;
}

.btn-icon-nav:hover:not(.disabled) {
  background-color: #f5f5f5;
}

.btn-icon-nav.disabled {
  opacity: 0.4;
  cursor: not-allowed;
  pointer-events: none;
}

.btn-icon-nav.disabled .mi-chevron-left,
.btn-icon-nav.disabled .mi-chevron-right {
  background-color: rgb(158, 158, 158);
}

/* Chevron left icon */
.mi-chevron-left {
  background-color: rgb(110, 115, 122);
  box-sizing: border-box;
  color: rgb(175, 179, 193);
  cursor: pointer;
  direction: ltr;
  display: block;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 16px;
  font-style: italic;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 20px;
  letter-spacing: 0.14px;
  line-height: 35px;
  margin: 0;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  min-height: 20px;
  min-width: 20px;
  padding: 0;
  text-align: center;
  text-indent: 0;
  user-select: none;
  width: 20px;
  -webkit-mask-position-x: -160px;
  -webkit-mask-position-y: 0px;
}

.mi-chevron-left::before {
  content: '';
}

/* Chevron right icon */
.mi-chevron-right {
  background-color: rgb(110, 115, 122);
  box-sizing: border-box;
  color: rgb(175, 179, 193);
  cursor: pointer;
  direction: ltr;
  display: block;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 16px;
  font-style: italic;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  height: 20px;
  letter-spacing: 0.14px;
  line-height: 35px;
  margin: 0;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  min-height: 20px;
  min-width: 20px;
  padding: 0;
  text-align: center;
  text-indent: 0;
  user-select: none;
  width: 20px;
  -webkit-mask-position-x: -140px;
  -webkit-mask-position-y: 0px;
}

.mi-chevron-right::before {
  content: '';
}
.page-size-selector select {
  border: 1px solid #e0e0e0;
  border-radius: 4px;
  padding: 0 8px;
}

/* Page size dropdown */
.page-size-dropdown {
  position: absolute;
  bottom: 100%;
  left: 0;
  margin-bottom: 4px;
  background: white;
  border: 1px solid #e0e0e0;
  border-radius: 4px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.15);
  z-index: 1000;
  min-width: 80px;
}

.page-size-option {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 8px 12px;
  cursor: pointer;
  font-size: 14px;
  color: #212121;
  transition: background-color 0.2s;
}

.page-size-option:hover {
  background-color: #f5f5f5;
}

.page-size-option.selected {
  background-color: #e8f5e9;
  color: #34b057;
}

.page-size-option .icon-check {
  color: #34b057;
  font-weight: bold;
  font-style: normal;
}

/* Custom Scrollbar Styles */
:deep(.dx-scrollable-scrollbar) {
  width: 8px !important;
  height: 8px !important;
}

:deep(.dx-scrollbar-vertical .dx-scrollable-scroll) {
  width: 8px !important;
  background-color: rgb(158, 158, 158) !important;
  border-radius: 10px !important;
}

:deep(.dx-scrollbar-horizontal .dx-scrollable-scroll) {
  height: 8px !important;
  background-color: rgb(158, 158, 158) !important;
  border-radius: 10px !important;
}

:deep(.dx-scrollable-scrollbar:hover .dx-scrollable-scroll) {
  background-color: rgb(120, 120, 120) !important;
}

/* Scrollbar for webkit browsers */
#datagrid :deep(*::-webkit-scrollbar) {
  width: 8px;
  height: 8px;
}

#datagrid :deep(*::-webkit-scrollbar-track) {
  background-color: rgba(0, 0, 0, 0);
}

#datagrid :deep(*::-webkit-scrollbar-thumb) {
  background-color: rgb(158, 158, 158);
  border-radius: 10px;
}

#datagrid :deep(*::-webkit-scrollbar-thumb:hover) {
  background-color: rgb(120, 120, 120);
}

/* DevExtreme DataGrid Table Styles */
:deep(.dx-datagrid-table) {
  background-color: rgba(0, 0, 0, 0);
  border-bottom-color: rgb(128, 128, 128);
  border-collapse: collapse;
  border-left-color: rgb(128, 128, 128);
  border-right-color: rgb(128, 128, 128);
  border-top-color: rgb(128, 128, 128);
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: default;
  direction: ltr;
  display: table;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 400;
  letter-spacing: 0.14px;
  line-height: 19.0001px;
  margin: 0;
  max-width: none;
  outline: none;
  padding: 0;
  table-layout: fixed;
  text-decoration: none;
  text-indent: 0;
  text-size-adjust: 100%;
  text-transform: none;
  text-wrap-mode: nowrap;
  unicode-bidi: isolate;
  white-space-collapse: collapse;
  -webkit-border-horizontal-spacing: 0px;
  -webkit-border-vertical-spacing: 0px;
  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
}

/* DevExtreme DataGrid Cell Styles */
:deep(.dx-datagrid td),
:deep(.dx-datagrid th) {
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  height: 38px;
  letter-spacing: 0.14px;
  line-height: 19.0001px;
  padding: 8px 12px;
  text-overflow: ellipsis;
  overflow: hidden;
  white-space: nowrap;
}

/* Data row height - Force 36px */
:deep(.dx-datagrid-rowsview .dx-data-row) {
  height: 36px !important;
  max-height: 36px !important;
  min-height: 36px !important;
}

:deep(.dx-datagrid-rowsview .dx-data-row td) {
  height: 36px !important;
  padding: 8px 12px !important;
  line-height: 20px !important;
  font-size: 14px !important;
  vertical-align: middle !important;
}

/* Header cells */
:deep(.dx-datagrid th) {
  font-weight: 700;
  cursor: pointer;
  background-color: #f6f6f6 !important;
}

/* Header row background */
:deep(.dx-datagrid-headers) {
  background-color: #f6f6f6 !important;
}

:deep(.dx-header-row) {
  background-color: #f6f6f6 !important;
}

:deep(.dx-header-row td) {
  background-color: #f6f6f6 !important;
}

/* Remove vertical borders except for checkbox column */
:deep(.dx-datagrid-borders > .dx-datagrid-total-footer),
:deep(.dx-datagrid-borders > .dx-datagrid-header-panel),
:deep(.dx-datagrid-borders > .dx-datagrid-headers),
:deep(.dx-datagrid-borders > .dx-datagrid-rowsview) {
  border-left: none !important;
  border-right: none !important;
}

:deep(.dx-datagrid td),
:deep(.dx-datagrid th) {
  border-left: none !important;
  border-right: none !important;
}

/* Keep border for checkbox column */
:deep(.dx-datagrid .dx-command-select) {
  border-right: 1px solid #e0e0e0 !important;
}

/* Hover and selected row background color */
:deep(.dx-datagrid-rowsview .dx-row:hover) {
  background-color: #e8f5e9 !important;
}

:deep(.dx-datagrid-rowsview .dx-row:hover td) {
  background-color: #e8f5e9 !important;
}

:deep(.dx-datagrid-rowsview .dx-selection.dx-row) {
  background-color: #e8f5e9 !important;
}

:deep(.dx-datagrid-rowsview .dx-selection.dx-row td) {
  background-color: #e8f5e9 !important;
}

/* Header cell title */
:deep(.dx-datagrid-text-content) {
  border-collapse: collapse;
  box-sizing: border-box;
  color: rgb(33, 33, 33);
  cursor: pointer;
  direction: ltr;
  display: block;
  font-family: Inter, Helvetica, Arial, sans-serif;
  font-size: 14px;
  font-variant-numeric: lining-nums tabular-nums;
  font-weight: 700;
  letter-spacing: 0.14px;
  line-height: 19.0001px;
  margin: 0;
  outline: none;
  padding: 0;
  print-color-adjust: exact;
  text-align: left;
  text-decoration: none;
  text-indent: 0;
  text-size-adjust: 100%;
  text-transform: none;
  text-wrap-mode: wrap;
  unicode-bidi: isolate;
  user-select: none;
  white-space-collapse: collapse;
  -webkit-border-horizontal-spacing: 0px;
  -webkit-border-vertical-spacing: 0px;
  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
}

/* Data row cells */
:deep(.dx-data-row td) {
  font-weight: 400;
  cursor: default;
}

/* Icons */
.icon-plus {
  background-color: rgb(255, 255, 255);
  color: rgb(175, 179, 193);
  display: block;
  font-size: 16px;
  font-style: italic;
  font-weight: 500;
  height: 20px;
  width: 20px;
  min-height: 20px;
  min-width: 20px;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -220px;
  -webkit-mask-position-y: 0px;
  mask-position: -220px 0px;
}
.icon-plus::before {
  content: '';
}
.icon-rule {
  background-color: rgb(110, 115, 122);
  color: rgb(175, 179, 193);
  display: block;
  font-size: 16px;
  font-style: italic;
  font-weight: 500;
  height: 20px;
  width: 20px;
  min-height: 20px;
  min-width: 20px;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -260px;
  -webkit-mask-position-y: -100px;
  mask-position: -260px -100px;
}
.icon-rule::before {
  content: '';
}
.icon-chevron-down {
  width: 7.4625px;
  height: 12px;
  background-color: rgba(255, 255, 255, 1);
  -webkit-mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  -webkit-mask-repeat: no-repeat;
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -186px;
  -webkit-mask-position-y: -781px;
  mask-position: -186px -781px;
  display: inline-block;
  transform: rotate(90deg);
}
.icon-chevron-down::before {
  content: '';
}
.icon-filter {
  background-color: rgb(110, 115, 122);
  color: rgb(175, 179, 193);
  display: block;
  font-size: 16px;
  font-style: italic;
  font-weight: 500;
  height: 20px;
  width: 20px;
  min-height: 20px;
  min-width: 20px;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -20px;
  -webkit-mask-position-y: 0px;
  mask-position: -20px 0px;
  text-align: center;
}
.icon-filter::before {
  content: '';
}
.icon-setting {
  background-color: rgb(102, 102, 102);
  color: rgb(175, 179, 193);
  display: block;
  font-size: 16px;
  font-style: italic;
  font-weight: 500;
  height: 24px;
  width: 24px;
  min-height: 24px;
  min-width: 24px;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -48px;
  -webkit-mask-position-y: -120px;
  mask-position: -48px -120px;
  text-align: center;
}
.icon-setting::before {
  content: '';
}
.icon-edit::before {
  content: '✎';
}
.icon-delete::before {
  content: '🗑';
}
.icon-active::before {
  content: '●';
  color: #34b057;
}
.icon-inactive::before {
  content: '●';
  color: #9e9e9e;
}

/* Action icons */
.mi-circle-minus-yellow {
  background-color: rgb(255, 153, 0);
  display: block;
  width: 20px;
  height: 20px;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -220px;
  -webkit-mask-position-y: -40px;
  mask-position: -220px -40px;
}

.mi-circle-minus-yellow::before {
  content: '';
}

.mi-copy {
  background-color: rgb(110, 115, 122);
  display: block;
  width: 20px;
  height: 20px;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -80px;
  -webkit-mask-position-y: 0px;
  mask-position: -80px 0px;
}

.mi-copy::before {
  content: '';
}

.mi-pencil {
  background-color: rgb(110, 115, 122);
  display: block;
  width: 20px;
  height: 20px;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -60px;
  -webkit-mask-position-y: 0px;
  mask-position: -60px 0px;
}

.mi-pencil::before {
  content: '';
}

.mi-trash-red {
  background-color: rgb(255, 97, 97);
  display: block;
  width: 20px;
  height: 20px;
  mask-image: url(https://testcdnamisapp.misacdn.net/apps/payroll/static/img/Icon.c487640.svg);
  mask-repeat: no-repeat;
  -webkit-mask-position-x: -120px;
  -webkit-mask-position-y: -20px;
  mask-position: -120px -20px;
}

.mi-trash-red::before {
  content: '';
}

/* Custom checkbox styles */
:deep(.dx-checkbox-icon) {
  background-color: rgb(255, 255, 255) !important;
  background-repeat: no-repeat !important;
  background-size: cover !important;
  background-position: 0 0 !important;
  border: 1.6px solid rgb(115, 120, 136) !important;
  border-radius: 4px !important;
  width: 16px !important;
  height: 16px !important;
  box-sizing: border-box !important;
  position: relative !important;
}

/* Hide default DevExtreme checkmark icon */
:deep(.dx-checkbox-icon::before) {
  display: none !important;
  content: none !important;
}

/* Checkbox checked state - green background with white bold checkmark */
:deep(.dx-checkbox-checked .dx-checkbox-icon) {
  background-color: rgb(52, 176, 87) !important;
  border-color: rgb(52, 176, 87) !important;
  background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 16 16'%3E%3Cpath fill='white' stroke='white' stroke-width='0.5' d='M13 4.5L6.5 11 3 7.5l1-1 2.5 2.5 5.5-5.5z'/%3E%3C/svg%3E") !important;
  background-repeat: no-repeat !important;
  background-position: center !important;
  background-size: 15px 15px !important;
}

/* Hide default checkmark on checked state */
:deep(.dx-checkbox-checked .dx-checkbox-icon::before) {
  display: none !important;
  content: none !important;
}

/* Fix header checkbox - hide indeterminate state icon */
:deep(.dx-header-row .dx-checkbox-icon::after) {
  display: none !important;
  content: none !important;
}

:deep(.dx-checkbox-indeterminate .dx-checkbox-icon::before) {
  display: none !important;
  content: none !important;
}
</style>
